# How to: Use a Custom Component to Implement List Editor (Blazor)

This example demonstrates how to implement a custom List Editor that shows images in an ASP.NET Core Blazor application. 
The List Editor displays a Razor component with custom objects. These objects implement a custom [IPictureItem](./CS/MySolution.Module/BusinessObjects/IPictureItem.cs) interface to store images and their captions.

![](custom-list-editor.png)

To add a custom List Editor to your ASP.NET Core Blazor application, define the required [data model](./CS/MySolution.Module/BusinessObjects/PictureItem.cs) and implement the following components in the _MySolution.Module.Blazor_ project:

* [Razor Component](./CS/MySolution.Module.Blazor/PictureItemListView.razor) - to define the required markup;
* [Component Model](./CS/MySolution.Module.Blazor/PictureItemListViewModel.cs) - to change the state of the component;
* [Component Renderer](./CS/MySolution.Module.Blazor/PictureItemListViewRenderer.razor) - to bind the component model with the component;
* [List Editor](./CS/MySolution.Module.Blazor/BlazorCustomListEditor.cs) - to integrate the component into your XAF application.

See the following help topic for more information: [How to: Use a Custom Component to Implement List Editor (Blazor)](https://docs.devexpress.com/eXpressAppFramework/403258/ui-construction/list-editors/how-to-use-a-custom-component-to-implement-list-editor-blazor)

<!-- default file list -->
*Files to look at*:

* [PictureItemListView.razor](./CS/MySolution.Module.Blazor/PictureItemListView.razor)
* [PictureItemListViewModel.cs](./CS/MySolution.Module.Blazor/PictureItemListViewModel.cs)
* [PictureItemListViewRenderer.razor](./CS/MySolution.Module.Blazor/PictureItemListViewRenderer.razor)
* [BlazorCustomListEditor.cs](./CS/MySolution.Module.Blazor/BlazorCustomListEditor.cs)
<!-- default file list end -->

## Related Documentation Topics
* [List Editors](https://docs.devexpress.com/eXpressAppFramework/113189/ui-construction/list-editors?p=netframework)
* [Using a Custom Control that is not Integrated by Default](https://docs.devexpress.com/eXpressAppFramework/113610/ui-construction/using-a-custom-control-that-is-not-integrated-by-default/using-a-custom-control-that-is-not-integrated-by-default)

## Related Examples
[XAF Blazor - Use a Custom View Item to Add a Button to a Detail View](https://github.com/DevExpress-Examples/xaf-custom-view-item-blazor)
