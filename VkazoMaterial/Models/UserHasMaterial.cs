using System;

namespace VkazoMaterial.Models
{
    public class UserHasMaterial
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public DateTime ReceiveDate { get; set; }
    }
}