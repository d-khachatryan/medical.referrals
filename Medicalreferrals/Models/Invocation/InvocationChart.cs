using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwInvocationChart")]
    public class InvocationChart
    {
        [Key]
        public int InvocationStatusId { get; set; }

        public string InvocationName { get; set; }

        public string InvocationStatusName { get; set; }

        public int? CNT { get; set; }

    }
}