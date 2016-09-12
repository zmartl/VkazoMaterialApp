using System.ComponentModel;

using VkazoMaterial.Resources;

namespace VkazoMaterial.Models
{
    public class Size
    {
        public int Id { get; set; }
        [DisplayName("Grösse")]
        public string Description { get; set; }
    }
}