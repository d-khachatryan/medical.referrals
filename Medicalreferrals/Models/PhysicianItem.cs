using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicalreferrals.Models
{
    [Table("vwPhysician")]
    public class PhysicianItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhysicianId { get; set; }

        [Display(Name = "Կոդ")]
        public string PhysicianCode { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Հայրանուն")]
        public string PatronymicName { get; set; }

        [Display(Name = "Հիմնարկ")]
        public int OrganizationID { get; set; }

        [Display(Name = "Հիմնարկ")]
        public string OrganizationName { get; set; }
    }
}