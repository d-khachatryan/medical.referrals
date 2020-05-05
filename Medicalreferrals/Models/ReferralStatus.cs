using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class ReferralStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralStatusId { get; set; }

        public string ReferralStatusCode { get; set; }

        public string ReferralStatusName { get; set; }

        public int? ReferralStatusTypeId { get; set; }
    }
}