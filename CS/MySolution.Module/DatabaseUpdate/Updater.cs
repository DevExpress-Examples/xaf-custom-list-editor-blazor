using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using MySolution.Module.BusinessObjects;
using System.IO;

namespace MySolution.Module.DatabaseUpdate {
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
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }

        private void CreateCustomListEditorObjects() {
            PictureItem image1 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Eternally Yours by Tay Garnett'"));
            if (image1 == null) {
                image1 = ObjectSpace.CreateObject<PictureItem>();
                image1.Text = "Eternally Yours by Tay Garnett";
                image1.Image = GetImageFromResource("MySolution.Module.ListEditorImages.EternallyYours.png");
                image1.Save();
            }
            PictureItem image2 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Sherlock Holmes - Dressed to Kill by Roy William Neill'"));
            if (image2 == null) {
                image2 = ObjectSpace.CreateObject<PictureItem>();
                image2.Text = "Sherlock Holmes - Dressed to Kill by Roy William Neill";
                image2.Image = GetImageFromResource("MySolution.Module.ListEditorImages.DressedToKill.png");
                image2.Save();
            }
            PictureItem image3 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='The Last Time I Saw Paris by Richard Brooks'"));
            if (image3 == null) {
                image3 = ObjectSpace.CreateObject<PictureItem>();
                image3.Text = "The Last Time I Saw Paris by Richard Brooks";
                image3.Image = GetImageFromResource("MySolution.Module.ListEditorImages.TheLastTimeISawParis.png");
                image3.Save();
            }
            PictureItem image4 = ObjectSpace.FindObject<PictureItem>(CriteriaOperator.Parse("Text='Teenagers from Outer Space by Tom Graeff'"));
            if (image4 == null) {
                image4 = ObjectSpace.CreateObject<PictureItem>();
                image4.Text = "Teenagers from Outer Space by Tom Graeff";
                image4.Save();
            }

        }

        private byte[] GetImageFromResource(string name) {
            UnmanagedMemoryStream stream = (UnmanagedMemoryStream)GetType().Assembly.GetManifestResourceStream(name);
            stream.Position = 0;
            byte[] result = new byte[stream.Length];
            stream.Read(result, 0, (Int32)stream.Length);
            return result;
        }

    }


}
