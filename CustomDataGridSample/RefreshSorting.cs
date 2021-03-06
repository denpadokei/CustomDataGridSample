using System.Windows;
using System.Windows.Controls;

namespace CustomDataGridSample
{
    public class RefreshSorting
    {
        public static readonly DependencyProperty CanRefreshSorting = DependencyProperty.RegisterAttached(
            "CanRefreshProperty",
            typeof(bool),
            typeof(RefreshSorting),
            new PropertyMetadata(OnCanRefreshSprtingChanged));

        public static bool GetCanRefreshSorting(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(CanRefreshSorting);
        }

        public static void SetCanRefreshSorting(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(CanRefreshSorting, value);
        }

        private static void OnCanRefreshSprtingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid) {
                if ((bool)e.OldValue == true) {
                    dataGrid.Sorting -= OnDataGridSorting;
                }
                if ((bool)e.NewValue == true) {
                    dataGrid.Sorting += OnDataGridSorting;
                }
            }
        }

        private static void OnDataGridSorting(object sender, DataGridSortingEventArgs e)
        {
            if (sender is DataGrid dataGrid) {
                if (e.Column.SortDirection == System.ComponentModel.ListSortDirection.Descending) {
                    e.Handled = true;
                    e.Column.SortDirection = null;
                    dataGrid.Items.SortDescriptions.Clear();
                }
            }
        }
    }
}
