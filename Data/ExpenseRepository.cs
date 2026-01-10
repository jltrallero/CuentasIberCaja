using CuentasIbercaja.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CuentasIbercaja.Data
{
    public class ExpenseRepository
    {
        private readonly string _connectionString;

        public ExpenseRepository(string databaseFile = "Movimientos.db")
        {
            _connectionString = $"Data Source={databaseFile}";
            EnsureCreated();
        }

        private void EnsureCreated()
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var sql = @"
                CREATE TABLE IF NOT EXISTS Expenses (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NumOrden INTEGER,
                    Fecha TEXT NOT NULL,
                    Concepto TEXT,
                    Descripcion TEXT,
                    Referencia TEXT,
                    Importe FLOAT,
                    TipoCuenta TEXT,
                    EsIngreso INTEGER DEFAULT 0
                );";
            conn.Execute(sql);
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            using var conn = new SqliteConnection(_connectionString);
            return await conn.QueryAsync<Expense>("SELECT * FROM Expenses ORDER BY Fecha DESC");
        }

        public async Task<long> InsertAsync(Expense e)
        {
            using var conn = new SqliteConnection(_connectionString);
            var sql = @"
                INSERT INTO Expenses
                    (NumOrden, Fecha, Concepto, Descripcion, Referencia, Importe, TipoCuenta, EsIngreso)
                VALUES
                    (@NumOrden, @Fecha, @Concepto, @Descripcion, @Referencia, @Importe, @TipoCuenta, @EsIngreso);
                SELECT last_insert_rowid();";
            return await conn.ExecuteScalarAsync<long>(sql, e);
        }

        public async Task UpdateAsync(Expense e)
        {
            using var conn = new SqliteConnection(_connectionString);
            var sql = @"
                UPDATE Expenses SET
                     NumOrden = @NumOrden,
                     Fecha = @Fecha,
                     Concepto = @Concepto,
                     Descripcion = @Descripcion,
                     Referencia = @Referencia,
                     Importe = @Importe,
                     TipoCuenta = @TipoCuenta,
                     EsIngreso = @EsIngreso
                WHERE Id = @Id;";
            await conn.ExecuteAsync(sql, e);
        }

        public async Task DeleteAsync(long id)
        {
            using var conn = new SqliteConnection(_connectionString);
            await conn.ExecuteAsync("DELETE FROM Expenses WHERE Id = @Id", new { Id = id });
        }

        public async Task DeleteAllAsync()
        {
            using var conn = new SqliteConnection(_connectionString);
            await conn.ExecuteAsync("DELETE FROM Expenses");
            await conn.ExecuteAsync("VACUUM");
        }

        public async Task DeleteCategoryAsync(TipoCuenta tipocuenta)
        {
            var tipocuentastr = tipocuenta.ToString();

            using var conn = new SqliteConnection(_connectionString);
            await conn.OpenAsync();

            await conn.ExecuteAsync(
                "DELETE FROM Expenses WHERE TipoCuenta = @tipoCuenta",
                new { tipoCuenta = tipocuentastr }
            );

            await conn.ExecuteAsync("VACUUM");
        }
    }
}