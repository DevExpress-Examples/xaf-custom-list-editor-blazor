using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using MySolution.Module.BusinessObjects;

namespace CustomEditor.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        CreateCustomListEditorObjects();
        
    }
    private void CreateCustomListEditorObjects() {
        PictureItem image1 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Green'"));
        if (image1 == null) {
            image1 = ObjectSpace.CreateObject<PictureItem>();
            image1.Text = "Green";
            image1.Image = GetImageFromResource("MySolution.Module.ListEditorImages.green.png");
            image1.Save();
        }
        PictureItem image2 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Red'"));
        if (image2 == null) {
            image2 = ObjectSpace.CreateObject<PictureItem>();
            image2.Text = "Red";
            image2.Image = GetImageFromResource("MySolution.Module.ListEditorImages.red.png");
            image2.Save();
        }
        PictureItem image3 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Blue'"));
        if (image3 == null) {
            image3 = ObjectSpace.CreateObject<PictureItem>();
            image3.Text = "Blue";
            image3.Image = GetImageFromResource("MySolution.Module.ListEditorImages.blue.png");
            image3.Save();
        }
        PictureItem image4 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Black'"));
        if (image4 == null) {
            image4 = ObjectSpace.CreateObject<PictureItem>();
            image4.Text = "Black";
            image4.Save();
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
