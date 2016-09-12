using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VkazoMaterial.Models
{
    public class UserHasMaterial
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        [DisplayName("Erhalten am")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReceiveDate { get; set; }
    }
}