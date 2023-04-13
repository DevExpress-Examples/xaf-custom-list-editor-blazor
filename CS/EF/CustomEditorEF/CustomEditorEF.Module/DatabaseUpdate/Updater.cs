using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.EF;
using DevExpress.Persistent.BaseImpl.EF;
using CustomEditorEF.Module.BusinessObjects;

namespace CustomEditorEF.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        CreateCustomListEditorObjects();
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
    }
    private void CreateCustomListEditorObjects() {
        PictureItem image1 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Green'"));
        if (image1 == null) {
            image1 = ObjectSpace.CreateObject<PictureItem>();
            image1.Text = "Green";
            image1.Image = GetImageFromResource("CustomEditorEF.Module.ListEditorImages.green.png");
        }
        PictureItem image2 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Red'"));
        if (image2 == null) {
            image2 = ObjectSpace.CreateObject<PictureItem>();
            image2.Text = "Red";
            image2.Image = GetImageFromResource("CustomEditorEF.Module.ListEditorImages.red.png");
        }
        PictureItem image3 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Blue'"));
        if (image3 == null) {
            image3 = ObjectSpace.CreateObject<PictureItem>();
            image3.Text = "Blue";
            image3.Image = GetImageFromResource("CustomEditorEF.Module.ListEditorImages.blue.png");
        }
        PictureItem image4 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Black'"));
        if (image4 == null) {
            image4 = ObjectSpace.CreateObject<PictureItem>();
            image4.Text = "Black";
        }
        ObjectSpace.CommitChanges();
    }

    private byte[] GetImageFromResource(string name) {
        UnmanagedMemoryStream stream = (UnmanagedMemoryStream)GetType().Assembly.GetManifestResourceStream(name);
        stream.Position = 0;
        byte[] result = new byte[stream.Length];
        stream.Read(result, 0, (Int32)stream.Length);
        return result;
    }
}
