using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class InvocationPurpose
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvocationPurposeId { get; set; }

        public string InvocationPurposeCode { get; set; }

        public string InvocationPurposeName { get; set; }
    }
}