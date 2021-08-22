using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SalesManagementSystem.Models
{
    public class ConsultantEntity
    {
        [Key]
        [Required]
        [Remote("IsConsultantIdAvialable", "Validation", HttpMethod = "POST", ErrorMessage = "Customer with specified id already exists")]
        public int Id { get => id; set => id = value; }

        [Required]
        [StringLength(20)]
        public string Name { get => name; set => name = value; }

        [Required]
        [StringLength(30)]
        public string Surname { get => surname; set => surname = value; }

        [Required]
        [Display(Name = "Id Number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Id number must be numeric")]
        public string IdNumber { get => idNumber; set => idNumber = value; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The Sex field is required.")]
        public SexEnum Sex { get => sex; set => sex = value; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        [Display(Name = "Referrer Id")]
        [Remote("IsReferrerIdValid", "Validation", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Referrer with specified id does not exist")]
        public int? ReferrerId { get => referrerId; set => referrerId = value; }

        private int id;
        private string name;
        private string surname;
        private string idNumber;
        private SexEnum sex;
        private DateTime dateOfBirth;
        private int? referrerId;

        public ConsultantEntity()
        {
        }

        public ConsultantEntity(int id,
                                string name,
                                string surname,
                                string idNumber,
                                SexEnum sex,
                                DateTime dateOfBirth,
                                int? referrerId)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.idNumber = idNumber;
            this.sex = sex;
            this.dateOfBirth = dateOfBirth;
            this.referrerId = referrerId;
        }
    }
}