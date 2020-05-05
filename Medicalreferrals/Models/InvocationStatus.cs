using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class InvocationStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvocationStatusId { get; set; }

        public string InvocationStatusCode { get; set; }

        public string InvocationStatusName { get; set; }

        public int? InvocationStatusTypeId { get; set; }
    }
}