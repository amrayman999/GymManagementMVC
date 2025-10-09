using GymManagementDAL.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.MemberViewModels
{
    public class CreateMemberViewModel
    {
        [Required(ErrorMessage ="Name is Required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage ="Name must contain only letters and single space between characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone is Required")]
        [Phone(ErrorMessage ="Invalid Phone Number")]
        [RegularExpression(@"(010|011|012|015)\d{8}", ErrorMessage = "Phone number must be a valid egyptian number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Date of Birth is Required")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage ="Gender is Required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Building Number is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Building Number must be a positive number")]
        public int BuildingNumber { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City must be between 2 and 100 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "City must contain only letters and spaces")]
        public string City { get; set; } = null!;


        [Required(ErrorMessage = "Street is Required")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Street must be between 2 and 150 characters")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Street must contain only letters, numbers and spaces")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "Health Record is Required")]
        public HealthRecordViewModel HealthRecordViewModel { get; set; } = null!;

    }
}
