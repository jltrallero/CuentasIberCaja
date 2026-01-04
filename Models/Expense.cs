namespace CuentasIbercaja.Models
{
    public class Expense
    {
        public long Id { get; set; }

        public DateTime Fecha { get; set; }

        public int NumOrden { get; set; }

        public TipoCuenta TipoCuenta { get; set; } = TipoCuenta.None;

        public string NDocumento { get; set; } = string.Empty;

        public string Concepto { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Referencia { get; set; } = string.Empty;

        public float Importe { get; set; } = 0f;

        public bool EsIngreso => Importe > 0f;
    }
}