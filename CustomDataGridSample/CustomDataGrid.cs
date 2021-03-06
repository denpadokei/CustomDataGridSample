using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace CustomDataGridSample
{
    public class CustomDataGrid : DataGrid
    {
        protected override void OnSorting(DataGridSortingEventArgs eventArgs)
        {
            if (eventArgs.Column.SortDirection == System.ComponentModel.ListSortDirection.Descending) {
                eventArgs.Handled = true;
                eventArgs.Column.SortDirection = null;
                this.Items.SortDescriptions.Clear();
                return;
            }
            base.OnSorting(eventArgs);
        }
    }
}
