using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;

namespace CustomEditor.Module.BusinessObjects {
    [DefaultClassOptions]
    public class PictureItem : BaseObject, IPictureItem {
        [ImageEditor]
        public virtual byte[] Image { get; set; }
        public virtual string Text { get; set; }
    }
}
