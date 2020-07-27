using System;

namespace PropertyServices.Funda.Models
{
    public partial class PromoLabel
    {
        public bool HasPromotionLabel { get; set; }
        public Uri[] PromotionPhotos { get; set; }
        public string[] PromotionPhotosSecure { get; set; }
        public long PromotionType { get; set; }
        public long RibbonColor { get; set; }
        public object RibbonText { get; set; }
        public string Tagline { get; set; }
    }
}
