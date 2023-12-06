using CustomEditorEF.Module.BusinessObjects;
using DevExpress.ExpressApp.Blazor.Components.Models;

namespace CustomEditorEF.Blazor.Server.Editors.CustomList {
    public class PictureItemListViewModel : ComponentModelBase {
        public IEnumerable<IPictureItem> Data {
            get => GetPropertyValue<IEnumerable<IPictureItem>>();
            set => SetPropertyValue(value);
        }
        public void Refresh() => RaiseChanged();
        public void OnItemClick(IPictureItem item) =>
            ItemClick?.Invoke(this, new PictureItemListViewModelItemClickEventArgs(item));
        public event EventHandler<PictureItemListViewModelItemClickEventArgs> ItemClick;
        public void OnSelectionChanged(IEnumerable<IPictureItem> selectedItems) =>
            SelectionChanged?.Invoke(this, new PictureItemListViewModelSelectionChangedEventArgs(selectedItems));
        public event EventHandler<PictureItemListViewModelSelectionChangedEventArgs> SelectionChanged;
    }
    public class PictureItemListViewModelItemClickEventArgs : EventArgs {
        public PictureItemListViewModelItemClickEventArgs(IPictureItem item) {
            Item = item;
        }
        public IPictureItem Item { get; }
    }
    public class PictureItemListViewModelSelectionChangedEventArgs : EventArgs {
        public PictureItemListViewModelSelectionChangedEventArgs(IEnumerable<IPictureItem> selectedItems) {
            SelectedItems = selectedItems;
        }
        public IEnumerable<IPictureItem> SelectedItems { get; }
    }
}
