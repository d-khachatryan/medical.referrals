using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class Community
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommunityId { get; set; }

        public string CommunityCode { get; set; }

        public string CommunityName { get; set; }

        public int? RegionId { get; set; }
    }
}