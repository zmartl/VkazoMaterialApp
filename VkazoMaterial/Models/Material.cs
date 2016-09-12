using System.ComponentModel;

namespace VkazoMaterial.Models
{
    public class Material
    {
        public int Id { get; set; }
        [DisplayName("Seriennummer")]
        public string SerialNumber { get; set; }
        [DisplayName("Beschreibung")]
        public string Description { get; set; }
        [DisplayName("Grösse")]
        public int SizeId { get; set; }
        [DisplayName("Grösse")]
        public virtual Size Size { get; set; }
    }
}