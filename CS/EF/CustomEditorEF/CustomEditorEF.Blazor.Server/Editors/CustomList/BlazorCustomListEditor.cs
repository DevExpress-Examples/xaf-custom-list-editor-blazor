using CustomEditorEF.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.ComponentModel;

namespace CustomEditorEF.Blazor.Server.Editors.CustomList {
    [ListEditor(typeof(IPictureItem))]
    public class BlazorCustomListEditor : ListEditor, IComponentContentHolder {
        private RenderFragment _componentContent;
        private IPictureItem[] selectedObjects = Array.Empty<IPictureItem>();

        public PictureItemListViewModel ComponentModel { get; private set; }

        public RenderFragment ComponentContent {
            get {
                _componentContent ??= ComponentModelObserver.Create(ComponentModel, ComponentModel.GetComponentContent());
                return _componentContent;
            }
        }

        public BlazorCustomListEditor(IModelListView model) : base(model) { }

        private void BindingList_ListChanged(object sender, ListChangedEventArgs e) {
            UpdateDataSource(DataSource);
        }

        private void UpdateDataSource(object dataSource) {
            if(ComponentModel is not null) {
                ComponentModel.Data = (dataSource as IEnumerable)?.OfType<IPictureItem>().OrderBy(i => i.Text);
            }
        }

        protected override object CreateControlsCore() {
            ComponentModel = new PictureItemListViewModel();
            ComponentModel.ItemClick = EventCallback.Factory.Create<IPictureItem>(this, (item) => {
                selectedObjects = new IPictureItem[] { item };
                OnSelectionChanged();
                OnProcessSelectedItem();
            });
            ComponentModel.SelectionChanged = EventCallback.Factory.Create<IEnumerable<IPictureItem>>(this, (items) => {
                selectedObjects = items.ToArray();
                OnSelectionChanged();
            });
            return ComponentModel;
        }

        protected override void AssignDataSourceToControl(object dataSource) {
            if(ComponentModel is not null) {
                if(ComponentModel.Data is IBindingList bindingList) {
                    bindingList.ListChanged -= BindingList_ListChanged;
                }
                UpdateDataSource(dataSource);
                if(dataSource is IBindingList newBindingList) {
                    newBindingList.ListChanged += BindingList_ListChanged;
                }
            }
        }

        public override void BreakLinksToControls() {
            AssignDataSourceToControl(null);
            base.BreakLinksToControls();
        }

        public override void Refresh() => UpdateDataSource(DataSource);

        public override SelectionType SelectionType => SelectionType.Full;

        public override IList GetSelectedObjects() => selectedObjects;

    }
}
