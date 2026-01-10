using ClosedXML.Excel;
using CuentasIbercaja.Models;
using System.Data;
using System.Globalization;

namespace CuentasIbercaja.Utils
{
    public static class ExcelImporterGastos
    {
        // Asume la primera hoja y fila de cabecera. Intenta mapear por columnas aproximadas.
        private static List<Expense> ImportIngresos(string filePath)
        {
            var list = new List<Expense>();
            using var wb = new XLWorkbook(filePath);
            if (wb.Worksheets.Count < 2)
                return list;

            var ws = wb.Worksheets.ElementAt(1);
            AnadirElementos(list, ws, true);

            return list;
        }

        // Asume la primera hoja y fila de cabecera. Intenta mapear por columnas aproximadas.
        private static List<Expense> ImportGastos(string filePath)
        {
            var list = new List<Expense>();
            using var wb = new XLWorkbook(filePath);
            var ws = wb.Worksheets.First();
            AnadirElementos(list, ws, false);
            return list;
        }

        private static void AnadirElementos(List<Expense> list, IXLWorksheet worksheet, bool esIngreso)
        {
            // 1. Encontrar la fila de encabezados
            var headerRow = FindHeaderRow(worksheet);
            if (headerRow == null)
                return; // No se puede procesar

            // 2. Obtener índices de columnas
            var fechaIndex = GetColumnIndex(headerRow, "Fecha y hora");
            var conceptoIndex = GetColumnIndex(headerRow, "Categoría");
            var descripcionIndex = GetColumnIndex(headerRow, "Comentario");
            var referenciaIndex = GetColumnIndex(headerRow, "Etiquetas");
            var importeIndex = GetColumnIndex(headerRow, "Cantidad en la divisa predeterminada");

            // 3. Filas de datos: todas las que están debajo del encabezado
            var dataRows = worksheet.RowsUsed().Where(r => r.RowNumber() > headerRow.RowNumber());

            // 4. Procesar datos
            var numOrdenId = 0;
            foreach (var r in dataRows)
            {
                try
                {
                    decimal importe = ParseDecimalSafe(r.Cell(importeIndex).GetString());
                    if (!esIngreso)
                        importe = -1 * importe;

                    var e = new Expense
                    {
                        NumOrden = numOrdenId,
                        Fecha = ParseDate(r.Cell(fechaIndex).GetString()),
                        Concepto = r.Cell(conceptoIndex).GetString(),
                        TipoCuenta = TipoCuenta.Ingresos_Gastos,
                        Importe = (float)importe,
                        Descripcion = r.Cell(descripcionIndex).GetString(),
                        Referencia = r.Cell(referenciaIndex).GetString()
                    };
                    list.Add(e);
                    numOrdenId++;
                }
                catch
                {
                    // ignorar filas mal formadas
                }
            }
        }

        private static IXLRow? FindHeaderRow(IXLWorksheet sheet)
        {
            return sheet.RowsUsed()
                .FirstOrDefault(row =>
                {
                    var cells = row.Cells().Select(c => c.GetString().Trim()).ToList();
                    return cells.Any(c =>
                        c.Equals("Fecha y hora", StringComparison.OrdinalIgnoreCase) ||
                        c.Equals("Categoría", StringComparison.OrdinalIgnoreCase)
                        );
                });
        }

        private static int GetColumnIndex(IXLRow headerRow, params string[] names)
        {
            return headerRow.Cells()
                .Where(cell => names.Any(name => string.Equals(cell.GetString().Trim(), name, StringComparison.OrdinalIgnoreCase)))
                .Select(cell => cell.Address.ColumnNumber)
                .DefaultIfEmpty(-1)
                .First();
        }

        public static IEnumerable<Expense> Import(string fileName)
        {
            var gastos = ImportGastos(fileName);
            var ingresos = ImportIngresos(fileName);
            return gastos.Concat(ingresos);
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