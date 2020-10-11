using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Core_Project.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Display(Name = "Branch Name")]
        public string Branch_Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; }
    }


    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Display(Name = "Name of Department")]
        public string DepartmentName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }

    public class Job
    {
        [Key]
        public int JobID { get; set; }
        
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        //[Required]
        //[StringLength(6, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Salary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }

    public class Certificate
    {
        [Key]
        public int CertificateID { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Display(Name = "Certificate Name")]
        public string CertificateName { get; set; }

        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; }

    }

    public class Institute
    {
        [Key]
        public int InstituteID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Display(Name = "Name of Institute")]
        public string InstituteName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; }

    }

    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int DepartmentID { get; set; }
        public int JobID { get; set; }

        [Display(Name = "Photo")]
        public string ImageFile { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get { return FirstName + " " + Lastname; } }

        public virtual Department Department { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; }

    }

    public class EmploymentHistory
    {
        [Key]
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int CompanyId { get; set; }
        public int CertificateID { get; set; }
        public int InstituteID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Job start from")]
        public DateTime JobStarttDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Job end date")]
        public DateTime JobEndDate { get; set; }

        public virtual Certificate Certificate { get; set; }
        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Institute Institute { get; set; }

    }

    public class Notice
    {
        [Key]
        public int NoticeID { get; set; }


        public string Discription { get; set; }
    }

    public class MenuHelperModel
    {
        [Key]
        public int Id { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        [NotMapped]
        public string Con_Act_Name
        {
            get
            {
                return ControllerName + "_" + ActionName;
            }
        }

        public virtual MenuModel MenuModel { get; set; }

    }

    public class MenuModel
    {
        [Key]
        public int Id { get; set; }

        public int MenuHelperModelId { get; set; }

        public string RollId { get; set; }

        [NotMapped]
        public string MenuHelperModelIdText { get; set; }

        public string RollIdText { get; set; }

        public virtual ICollection<MenuHelperModel> MenuHelperModel { get; set; }

        public virtual MenuModelManage MenuModelManage { get; set; }


    }


    public class MenuModelManage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MenuModel")]
        public int MenuModelId { get; set; }

        [NotMapped]
        public string Con_Act_Roll { get; set; }
        public bool Retrive { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }

        public virtual MenuModel MenuModel { get; set; }




    }

    public class DropDownListValue
    {

        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ViewDropDown
    {
        public string DropdownName { get; set; }
        public List<DropDownListValue> DropDownListValues { get; set; }
    }

}
