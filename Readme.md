# XAF Blazor - Use a Custom Component to Implement List Editor

This example demonstrates how to implement a custom List Editor that shows images in an ASP.NET Core Blazor application. 
The List Editor displays a Razor component with custom objects. These objects implement a custom [IPictureItem](./CS/MySolution.Module/BusinessObjects/IPictureItem.cs) interface to store images and their captions.

See the following help topic for more information: [How to: Use a Custom Component to Implement List Editor (Blazor)](https://docs.devexpress.com/eXpressAppFramework/403258/ui-construction/list-editors/how-to-use-a-custom-component-to-implement-list-editor-blazor).

![](custom-list-editor.png)

<!-- default file list -->
## Files to Look at

* [PictureItemListView.razor](./CS/MySolution.Module.Blazor/PictureItemListView.razor)
* [PictureItemListViewModel.cs](./CS/MySolution.Module.Blazor/PictureItemListViewModel.cs)
* [PictureItemListViewRenderer.razor](./CS/MySolution.Module.Blazor/PictureItemListViewRenderer.razor)
* [BlazorCustomListEditor.cs](./CS/MySolution.Module.Blazor/BlazorCustomListEditor.cs)
<!-- default file list end -->

## Documentation
* [List Editors](https://docs.devexpress.com/eXpressAppFramework/113189/ui-construction/list-editors?p=netframework)
* [Using a Custom Control that is not Integrated by Default](https://docs.devexpress.com/eXpressAppFramework/113610/ui-construction/using-a-custom-control-that-is-not-integrated-by-default/using-a-custom-control-that-is-not-integrated-by-default)

## More GitHub Examples
[XAF Blazor - Use a Custom View Item to Add a Button to a Detail View](https://github.com/DevExpress-Examples/xaf-custom-view-item-blazor)
