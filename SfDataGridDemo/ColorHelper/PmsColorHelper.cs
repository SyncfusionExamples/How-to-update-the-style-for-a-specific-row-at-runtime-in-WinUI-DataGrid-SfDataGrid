// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SfDataGridDemo
{
    public static class PmsColorHelper
    {
        public static (string Name, string Hex) GetPmsInfo(int pms)
        {
            return pms switch
            {
                //Reds
                185 => ("Red", "#E4002B"),
                186 => ("Dark Red", "#C8102E"),

                // Yellows
                109 => ("Yellow", "#FFD100"),
                123 => ("Golden Yellow", "#FFC72C"),

                //Blues
                300 => ("Blue", "#0072CE"),
                286 => ("Dark Blue", "#0033A0"),

                //Greens
                354 => ("Green", "#00B140"),
                348 => ("Dark Green", "#006A52"),

                //Oranges
                165 => ("Orange", "#FF671F"),

                //Black
                419 => ("Black", "#212721"),

                // fallback
                _ => ("Unknown", "#CCCCCC")
            };
        }
    }
}
