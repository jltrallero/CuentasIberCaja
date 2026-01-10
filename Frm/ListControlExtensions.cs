using System.Data;

namespace GestorGastos
{
    public static class ListControlExtensions
    {
        public static void BindEnum<TEnum>(
            this ListControl control,
            params TEnum[] exclude
        ) where TEnum : struct, Enum
        {
            IEnumerable<TEnum> values = Enum.GetValues<TEnum>();

            if (exclude?.Length > 0)
                values = values.Where(v => !exclude.Contains(v));

            control.DataSource = values.ToList();
        }
    }
}