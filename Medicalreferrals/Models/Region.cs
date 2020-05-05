using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Մարզի ID")]
        public int RegionId { get; set; }

        [Display(Name = "Մարզի կոդ")]
        public string RegionCode { get; set; }

        [Display(Name = "Մարզի անվանում")]
        public string RegionName { get; set; }
    }
}