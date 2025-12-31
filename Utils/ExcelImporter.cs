using ClosedXML.Excel;
using CuentasIbercaja.Models;
using System.Globalization;

namespace CuentasIbercaja.Utils
{
    public static class ExcelImporter
    {
        private static void AnadirElementos(TipoCuenta cuenta, List<Expense> list, IEnumerable<IXLRow> rows)
        {
            foreach (var r in rows)
            {
                try
                {
                    var importe = ParseDecimalSafe(r.Cell(7).GetString()); // Importe

                    var e = new Expense
                    {
                        NumOrden = int.Parse(r.Cell(1).GetString()),   // Nº Orden
                        Fecha = ParseDate(r.Cell(2).GetString()),      // Fecha Operación
                        Concepto = r.Cell(4).GetString(),              // Concepto
                        Descripcion = r.Cell(5).GetString(),           // Descripción
                        Referencia = r.Cell(6).GetString(),            // Referencia
                        Importe = (float)importe,                      // Importe
                        TipoCuenta = cuenta
                    };
                    list.Add(e);
                }
                catch
                {
                    // ignorar filas mal formadas
                }
            }
        }

        public static IEnumerable<Expense> Import(TipoCuenta cuenta, string fileName)
        {
            var list = new List<Expense>();
            using var wb = new XLWorkbook(fileName);

            var ws = wb.Worksheets.ElementAt(0);
            var rows = ws.RowsUsed().Skip(1); // saltar cabeceras

            AnadirElementos(cuenta, list, rows);

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