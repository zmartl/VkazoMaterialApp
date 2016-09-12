using System.ComponentModel;

namespace VkazoMaterial.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("Kürzel")]
        public string Contraction { get; set; }
        [DisplayName("Vorname")]
        public string Surname { get; set; }
        [DisplayName("Nachname")]
        public string Name { get; set; }
        public int RankId { get; set; }
        [DisplayName("Rang")]
        public virtual Rank Rank { get; set; }
        [DisplayName("Berechtigt")]
        public bool IsAuthorized { get; set; }
    }
}