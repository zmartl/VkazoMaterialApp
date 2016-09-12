using System.ComponentModel;

namespace VkazoMaterial.Models
{
    public class Rank
    {
        public int Id { get; set; }
        [DisplayName("Rang")]
        public string RankName { get; set; }
    }
}