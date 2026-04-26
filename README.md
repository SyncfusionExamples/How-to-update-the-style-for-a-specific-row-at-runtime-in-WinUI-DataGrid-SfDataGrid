# How to update the style for a specific row at runtime in WinUI DataGrid (SfDataGrid)?

In [WinUI DataGrid](https://www.syncfusion.com/winui-controls/datagrid) (SfDataGrid), the style of a specific row can be updated using the **UpdateDataRow** method in the [CurrentCellEndEdit](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_CurrentCellEndEdit) event handler. In this customization, the InkColor and ColorPreview properties are updated based on the PMS number by passing the current row index to the UpdateDataRow method.

**C#**
```
dataGrid.CurrentCellEndEdit += DataGrid_CurrentCellEndEdit;

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
```

![Update style at runtime](Update%20style%20at%20runtime.gif)

Take a moment to peruse the [WinUI DataGrid - Conditional styling](https://help.syncfusion.com/winui/datagrid/conditional-styling) documentation, to learn more about conditional styling.