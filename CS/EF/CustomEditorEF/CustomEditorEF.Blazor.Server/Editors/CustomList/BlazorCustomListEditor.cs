using CustomEditorEF.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.ComponentModel;

namespace CustomEditorEF.Blazor.Server.Editors.CustomList {
    [ListEditor(typeof(IPictureItem))]
    public class BlazorCustomListEditor : ListEditor {
        public class PictureItemListViewHolder : IComponentContentHolder {
            private RenderFragment componentContent;
            public PictureItemListViewHolder(PictureItemListViewModel componentModel) {
                ComponentModel =
                    componentModel ?? throw new ArgumentNullException(nameof(componentModel));
            }
            private RenderFragment CreateComponent() =>
                ComponentModelObserver.Create(ComponentModel,
                                                PictureItemListViewRenderer.Create(ComponentModel));
            public PictureItemListViewModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent =>
                componentContent ??= CreateComponent();
        }
        private IPictureItem[] selectedObjects = Array.Empty<IPictureItem>();
        public BlazorCustomListEditor(IModelListView model) : base(model) { }
        protected override object CreateControlsCore() =>
            new PictureItemListViewHolder(new PictureItemListViewModel());
        protected override void AssignDataSourceToControl(object dataSource) {
            if (Control is PictureItemListViewHolder holder) {
                if (holder.ComponentModel.Data is IBindingList bindingList) {
                    bindingList.ListChanged -= BindingList_ListChanged;
                }
                holder.ComponentModel.Data =
                    (dataSource as IEnumerable)?.OfType<IPictureItem>().OrderBy(i => i.Text);
                if (dataSource is IBindingList newBindingList) {
                    newBindingList.ListChanged += BindingList_ListChanged;
                }
            }
        }
        protected override void OnControlsCreated() {
            if (Control is PictureItemListViewHolder holder) {
                holder.ComponentModel.ItemClick += ComponentModel_ItemClick;
                holder.ComponentModel.SelectionChanged += ComponentModel_SelectionChanged;
            }
            base.OnControlsCreated();
        }
        private void ComponentModel_SelectionChanged(object sender,
                                                        PictureItemListViewModelSelectionChangedEventArgs e) {
            selectedObjects = e.SelectedItems.ToArray();
            OnSelectionChanged();
        }
        public override void BreakLinksToControls() {
            if (Control is PictureItemListViewHolder holder) {
                holder.ComponentModel.ItemClick -= ComponentModel_ItemClick;
                holder.ComponentModel.SelectionChanged -= ComponentModel_SelectionChanged;
            }
            AssignDataSourceToControl(null);
            base.BreakLinksToControls();
        }
        public override void Refresh() {
            if (Control is PictureItemListViewHolder holder) {
                holder.ComponentModel.Refresh();
            }
        }
        private void BindingList_ListChanged(object sender, ListChangedEventArgs e) {
            Refresh();
        }
        private void ComponentModel_ItemClick(object sender,
                                                PictureItemListViewModelItemClickEventArgs e) {
            selectedObjects = new IPictureItem[] { e.Item };
            OnSelectionChanged();
            OnProcessSelectedItem();
        }
        public override SelectionType SelectionType => SelectionType.Full;
        public override IList GetSelectedObjects() => selectedObjects;
    }
}
