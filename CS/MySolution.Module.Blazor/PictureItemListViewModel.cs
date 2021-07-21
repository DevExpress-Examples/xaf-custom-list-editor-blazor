using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.Blazor.Components.Models;
using MySolution.Module.BusinessObjects;

namespace MySolution.Module.Blazor {
    public class PictureItemListViewModel : ComponentModelBase {
        public IEnumerable<IPictureItem> Data {
            get => GetPropertyValue<IEnumerable<IPictureItem>>();
            set => SetPropertyValue(value);
        }
        public void Refresh() => RaiseChanged();
        public void OnItemClick(IPictureItem item) =>
            ItemClick?.Invoke(this, new PictureItemListViewModelItemClickEventArgs(item));
        public event EventHandler<PictureItemListViewModelItemClickEventArgs> ItemClick;
    }
    public class PictureItemListViewModelItemClickEventArgs : EventArgs {
        public PictureItemListViewModelItemClickEventArgs(IPictureItem item) {
            Item = item;
        }
        public IPictureItem Item { get; }
    }
}
