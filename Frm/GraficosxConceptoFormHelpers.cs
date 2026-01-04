using System.Windows.Forms.DataVisualization.Charting;

namespace CuentasIbercaja.Frm
{
    public static class GraficosxConceptoFormHelpers
    {
        public static SeriesChartType MapearTipoGrafico(TipoGrafico tipo)
        {
            return tipo switch
            {
                TipoGrafico.Linea => SeriesChartType.Line,
                TipoGrafico.Barra => SeriesChartType.Column,
                TipoGrafico.Columna => SeriesChartType.Column,
                TipoGrafico.Circular => SeriesChartType.Pie,
                TipoGrafico.Area => SeriesChartType.Area,
                TipoGrafico.Punto => SeriesChartType.Point,
                TipoGrafico.Radar => SeriesChartType.Radar,
                TipoGrafico.Burbuja => SeriesChartType.Bubble,
                _ => SeriesChartType.Column // Valor predeterminado
            };
        }
    }
}