using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.DataGrid;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SfDataGridDemo
{
    public class PmsSelectorClass : StyleSelector
    {
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            if (item is not InkColorRow data ||
                container is not GridCell cell ||
                cell.ColumnBase?.GridColumn?.MappingName != "ColorPreview")
            {
                return base.SelectStyleCore(item, container);
            }

            if (data.PMSNumber <= 0)
            {
                return base.SelectStyleCore(item, container);
            }

            var pmsInfo = PmsColorHelper.GetPmsInfo(data.PMSNumber);

            var style = new Style(typeof(GridCell));
            style.Setters.Add(
                new Setter(
                    GridCell.BackgroundProperty,
                    ColorHelper.GetColorFromHex(pmsInfo.Hex))
            );
            return style;
        }
    }
}
