using System;

namespace VkazoMaterial.Models
{
    public class UserHasMaterial
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Material Material { get; set; }
        public DateTime ReceiveDate { get; set; }
    }
}