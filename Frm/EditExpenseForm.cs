using CuentasIbercaja.Models;

namespace GestorGastos
{
    public partial class EditExpenseForm : Form
    {
        private readonly Expense exp;

        public EditExpenseForm()
        {
            InitializeComponent();
        }

        public EditExpenseForm(Expense exp)
        {
            this.exp = exp;
        }
    }
}