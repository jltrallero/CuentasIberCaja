using System.Windows.Forms.DataVisualization.Charting;

namespace CuentasIbercaja.Frm
{
    public enum TipoGrafico
    {
        Linea,        // Gráfico de líneas
        Barra,        // Barras horizontales
        Columna,      // Barras verticales
        Circular,     // Gráfico circular (Pie)
        Area,         // Gráfico de áreas
        Punto,        // Gráfico de dispersión (Scatter)
        Radar,        // Gráfico tipo radar
        Burbuja       // Gráfico de burbujas
    }

    public static class GraficosHelpers
    {
        public static void ConfigurarChart(Chart chart, TipoGrafico tipo, string titulo, Dictionary<string, float> datos)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            ChartArea area = new("MainArea");
            chart.ChartAreas.Add(area);

            Series serie = new("Datos");

            // Configuración según el tipo
            switch (tipo)
            {
                case TipoGrafico.Linea:
                    serie.ChartType = SeriesChartType.Line;
                    serie.Color = Color.Blue;
                    serie.BorderWidth = 3;
                    break;

                case TipoGrafico.Barra:
                    serie.ChartType = SeriesChartType.Bar;
                    serie.Color = Color.DarkGreen;
                    break;

                case TipoGrafico.Columna:
                    serie.ChartType = SeriesChartType.Column;
                    serie.Color = Color.Orange;
                    break;

                case TipoGrafico.Circular:
                    serie.ChartType = SeriesChartType.Pie;
                    break;

                case TipoGrafico.Area:
                    serie.ChartType = SeriesChartType.Area;
                    serie.Color = Color.LightSkyBlue;
                    break;

                case TipoGrafico.Punto:
                    serie.ChartType = SeriesChartType.Point;
                    serie.MarkerStyle = MarkerStyle.Circle;
                    serie.Color = Color.Red;
                    serie.MarkerSize = 10;
                    break;

                case TipoGrafico.Radar:
                    serie.ChartType = SeriesChartType.Radar;
                    serie.Color = Color.Purple;
                    break;

                case TipoGrafico.Burbuja:
                    serie.ChartType = SeriesChartType.Bubble;
                    serie.Color = Color.Magenta;
                    break;
            }

            // Añadir datos
            int i = 0;
            Color[] colores = [Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Red];
            foreach (var item in datos)
            {
                DataPoint punto = new()
                {
                    AxisLabel = item.Key,
                    YValues = [(double)item.Value]
                };

                // 👇 Colorear cada barra/punto si no es Pie
                if (tipo != TipoGrafico.Circular)
                    punto.Color = colores[i % colores.Length];

                serie.Points.Add(punto);
                i++;
            }

            chart.Series.Add(serie);
            chart.Titles.Add(titulo);
        }
    }
}