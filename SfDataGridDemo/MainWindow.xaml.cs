using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.DataGrid;
using Syncfusion.UI.Xaml.DataGrid.Helpers;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SfDataGridDemo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            dataGrid.ItemsSource = new ObservableCollection<InkColorRow>
            {
                new InkColorRow { ThisComp = true,  InkColor = "Green", PMSNumber = 354 },
                new InkColorRow { ThisComp = false, InkColor = "Blue",   PMSNumber = 300 },
                new InkColorRow { ThisComp = true,  InkColor = "None",   PMSNumber = 0 }
            };

            dataGrid.CurrentCellEndEdit += DataGrid_CurrentCellEndEdit;
        }

        private void DataGrid_CurrentCellEndEdit(object? sender, CurrentCellEndEditEventArgs e)
        {
            var index = e.RowColumnIndex.RowIndex;
            var gridModel = this.dataGrid.GetType().GetProperty("GridModel", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(this.dataGrid);
            if (gridModel != null)
            {
                var updateDataRow = gridModel.GetType().GetMethod("UpdateDataRow", BindingFlags.Instance | BindingFlags.Public);
                if (updateDataRow != null)
                    updateDataRow.Invoke(gridModel, new object[] { index });
            }
        }
    }
}
