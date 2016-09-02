namespace VkazoMaterial.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Contraction { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public Rank Rank { get; set; }
        public bool IsAuthorized { get; set; }
    }
}