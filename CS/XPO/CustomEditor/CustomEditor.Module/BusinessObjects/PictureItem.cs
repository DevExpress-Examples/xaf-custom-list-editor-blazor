using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace CustomEditor.Module.BusinessObjects {
    [DefaultClassOptions]
    public class PictureItem : BaseObject, IPictureItem {
        private byte[] image;
        private string text;
        public PictureItem(Session session) : base(session) { }
        [ImageEditor]
        public byte[] Image {
            get { return image; }
            set { SetPropertyValue(nameof(Image), ref image, value); }
        }
        public string Text {
            get { return text; }
            set { SetPropertyValue(nameof(Text), ref text, value); }
        }
    }
}
