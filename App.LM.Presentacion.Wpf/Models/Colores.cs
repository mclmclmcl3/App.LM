using System.ComponentModel;
using System;

namespace MiApp.LM.Presentacion.Wpf.Models
{
    public enum Colores
    {
        [Description("#0275d8")] Primary,
        [Description("#555555")] Secondary,
        [Description("#5cb85c")] Success,
        [Description("#5bc0de")] Info,
        [Description("#f0ad4e")] Warning,
        [Description("#d9534f")] Danger,
        [Description("#292b2c")] Negro,
        [Description("#f7f7f7")] Blanco,
        [Description("#FFD0D0D0")] Claro,
        [Description("#FF3E3E3E")] Oscuro,
        [Description("#F7323232")] DarkGrey,
        [Description("Gray")] Gray,
        [Description("#FFD0D0D0")] LightGray
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
