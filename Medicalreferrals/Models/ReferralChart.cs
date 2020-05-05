using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralChart")]
    public class ReferralChart
    {
        [Key]
        public int ReferralStatusId { get; set; }

        public string ReferralName { get; set; }

        public string ReferralStatusName { get; set; }

        public int? CNT { get; set; }

    }
}