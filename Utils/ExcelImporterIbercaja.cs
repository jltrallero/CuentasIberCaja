using ClosedXML.Excel;
using CuentasIbercaja.Models;
using System.Globalization;

namespace CuentasIbercaja.Utils
{
    public static class ExcelImporterIbercaja
    {
        private static int SafeInt(IXLRow row, int index)
        {
            if (index > 0)
            {
                var text = row.Cell(index).GetString();
                if (int.TryParse(text, out int value))
                    return value;
            }
            return 0;
        }

        private static string SafeString(IXLRow row, int index)
        {
            return index > 0 ? row.Cell(index).GetString() : string.Empty;
        }

        private static int GetColumnIndex(IXLRow headerRow, params string[] names)
        {
            return headerRow.Cells()
                .Where(cell => names.Any(name => string.Equals(cell.GetString().Trim(), name, StringComparison.OrdinalIgnoreCase)))
                .Select(cell => cell.Address.ColumnNumber)
                .DefaultIfEmpty(-1)
                .First();
        }

        private static void AnadirElementos(TipoCuenta cuenta, List<Expense> list, IXLWorksheet worksheet)
        {
            // 1. Encontrar la fila de encabezados
            var headerRow = FindHeaderRow(worksheet);
            if (headerRow == null)
                return; // No se puede procesar

            // 2. Obtener índices de columnas
            var numOrdenIndex = GetColumnIndex(headerRow, "Nº Orden");
            var fechaIndex = GetColumnIndex(headerRow, "F.Operación", "Fecha Operación", "Fecha Oper");
            var conceptoIndex = GetColumnIndex(headerRow, "Concepto");
            var descripcionIndex = GetColumnIndex(headerRow, "Descripción");
            var referenciaIndex = GetColumnIndex(headerRow, "N.Documento", "Referencia");
            var importeIndex = GetColumnIndex(headerRow, "Importe");

            // 3. Filas de datos: todas las que están debajo del encabezado
            var dataRows = worksheet.RowsUsed().Where(r => r.RowNumber() > headerRow.RowNumber());

            var indexnumorden = 1;
            var numorden = 1;
            var conceptoBuilder = new System.Text.StringBuilder();

            // 4. Procesar datos
            foreach (var r in dataRows)
            {
                try
                {
                    decimal importe = 0;
                    if (importeIndex > 0)
                        importe = ParseDecimalSafe(r.Cell(importeIndex).GetString());

                    // Acumular descripción
                    conceptoBuilder.Append(" ");
                    conceptoBuilder.Append(SafeString(r, conceptoIndex));

                    // Si el importe es 0, concatenamos concepto y pasamos al siguiente registro
                    if (importe == 0)
                        continue;

                    numorden = SafeInt(r, numOrdenIndex);
                    if (numorden == 0)
                        numorden = indexnumorden;

                    var e = new Expense
                    {
                        NumOrden = numorden,
                        Fecha = ParseDate(r.Cell(fechaIndex).GetString()),
                        Concepto = conceptoBuilder.ToString(),
                        Descripcion = SafeString(r, descripcionIndex),
                        Referencia = SafeString(r, referenciaIndex),
                        Importe = (float)importe,
                        TipoCuenta = cuenta
                    };

                    list.Add(e);
                    conceptoBuilder.Clear();
                }
                catch
                {
                    // ignorar filas mal formadas
                }

                indexnumorden++;
            }
        }

        private static IXLRow? FindHeaderRow(IXLWorksheet sheet)
        {
            return sheet.RowsUsed()
                .FirstOrDefault(row =>
                {
                    var cells = row.Cells().Select(c => c.GetString().Trim()).ToList();
                    return cells.Any(c =>
                        c.Equals("Nº Orden", StringComparison.OrdinalIgnoreCase) ||
                        c.Equals("F.Operación", StringComparison.OrdinalIgnoreCase) ||
                        c.Equals("Concepto", StringComparison.OrdinalIgnoreCase) ||
                        c.Equals("Importe", StringComparison.OrdinalIgnoreCase));
                });
        }

        public static IEnumerable<Expense> Import(TipoCuenta cuenta, string fileName)
        {
            var list = new List<Expense>();
            using var wb = new XLWorkbook(fileName);

            var ws = wb.Worksheets.ElementAt(0);

            AnadirElementos(cuenta, list, ws);

            return list;
        }

        private static DateTime ParseDate(string s)
        {
            if (DateTime.TryParse(s, CultureInfo.GetCultureInfo("es-ES"), DateTimeStyles.None, out var dt)) return dt;
            if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var oa)) // Excel serial
            {
                return DateTime.FromOADate(oa);
            }
            return DateTime.Now;
        }

        private static decimal ParseDecimalSafe(string s)
        {
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.GetCultureInfo("es-ES"), out var d)) return d;
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out d)) return d;
            // eliminar posibles caracteres no numéricos (puntos, comas)
            var cleaned = new string([.. s.Where(ch => char.IsDigit(ch) || ch == ',' || ch == '.' || ch == '-')]);
            if (decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.GetCultureInfo("es-ES"), out d)) return d;
            if (decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out d)) return d;
            return 0m;
        }
    }
}