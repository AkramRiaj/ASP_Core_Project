using ASP_Core_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Core_Project.Models
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Company.
            if (context.Company.Any())
            {
                return;
            }

            var company = new Company[]
            {
                new Company{Branch_Name="Branch-1", Location="Paltan" },
                new Company{Branch_Name="Branch-2", Location="Banani" },
                new Company{Branch_Name="Branch-3", Location="Narayanganj" },

            };

            foreach (Company c in company)
            {
                context.Company.Add(c);
            }
            context.SaveChanges();


            // Look for any Department.
            if (context.Department.Any())
            {
                return;
            }

            var depertment = new Department[]
            {
                new Department{DepartmentName="HR & Admin Department"},
                new Department{DepartmentName="Marketing Department"},
                new Department{DepartmentName="Accounts Department"},
                new Department{DepartmentName="Production Department"}


            };
            foreach (Department d in depertment)
            {
                context.Department.Add(d);
            }
            context.SaveChanges();



            // Look for any Job.
            if (context.Job.Any())
            {
                return;
            }

            var job = new Job[]
            {
                new Job{JobTitle="Manager", Salary= "90000" },
                new Job{JobTitle="Senior officer", Salary= "60000" },
                new Job{JobTitle="Officer", Salary= "40000" },
                new Job{JobTitle="Junior Officer", Salary= "30000" }



            };
            foreach (Job j in job)
            {
                context.Job.Add(j);
            }
            context.SaveChanges();


            // Look for any Certificate.
            if (context.Certificate.Any())
            {
                return;   // DB has been seeded
            }

            var certificate = new Certificate[]
            {
                new Certificate{CertificateName="SSC" },
                new Certificate{CertificateName="HSC" },
                new Certificate{CertificateName="Honours" }

            };
            foreach (Certificate c in certificate)
            {
                context.Certificate.Add(c);
            }
            context.SaveChanges();


            // Look for any Institute.
            if (context.Institute.Any())
            {
                return; 
            }

            var institute = new Institute[]
            {

                new Institute{InstituteName="Govt boys High School", Address="Adamjee", City="Narayanganj" },
                new Institute{InstituteName="Kurmitula Model High School", Address="Airport", City="Dhaka" },
                new Institute{InstituteName="Khilkhet Model High School", Address="Khilkhet", City="Dhaka" },
                new Institute{InstituteName="Jagannath University", Address="Sadarghat", City="Dhaka" },
                new Institute{InstituteName="Tongi Govt. College", Address="Tongi", City="Gazipur" },
                new Institute{InstituteName="Govt Bangla College", Address="Mirpur", City="Dhaka" },
                new Institute{InstituteName="Uttara Model College", Address="Uttara", City="Dhaka" },
                new Institute{InstituteName="Dhaka College", Address="New Market", City="Dhaka" },
                new Institute{InstituteName="Govt Tularam College", Address="Chasara", City="Narayanganj" },
                new Institute{InstituteName="Dhaka University", Address="Shahbag", City="Dhaka" }


        };
            foreach (Institute i in institute)
            {
                context.Institute.Add(i);
            }
            context.SaveChanges();


            // Look for any Employee.
            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }

            var employee = new Employee[]
            {
                new Employee{FirstName="Akram", Lastname="Hossain", Address ="Zigatola, Mohammadpur", Contact="01725-874598" , JobID = job.Single(f => f.JobID == 2).JobID, DepartmentID = depertment.Single(f => f.DepartmentID == 1).DepartmentID, ImageFile="~/Employees/333.jpg" },
                new Employee{FirstName="Sharmin", Lastname="Akter", Address ="Adomzi, Narayanganj", Contact="01758-446898" , JobID = job.Single(f => f.JobID == 1).JobID, DepartmentID = depertment.Single(f => f.DepartmentID == 2).DepartmentID, ImageFile="~/Employees/111.jpg" },
                new Employee{FirstName="Imran", Lastname="Hossain", Address ="Demra, Dhaka", Contact="01725-875988" , JobID = job.Single(f => f.JobID == 3).JobID, DepartmentID = depertment.Single(f => f.DepartmentID == 3).DepartmentID, ImageFile="~/Employees/222.jpg" },
                new Employee{FirstName="Robiul", Lastname="Hossain", Address ="Malibag, Dhaka", Contact="01758-223498" , JobID = job.Single(f => f.JobID == 4).JobID, DepartmentID = depertment.Single(f => f.DepartmentID == 4).DepartmentID, ImageFile="~/Employees/444.jpg" },
                new Employee{FirstName="Obidul", Lastname="Limon", Address ="Chasara, Narayanganj", Contact="01725-846978" , JobID = job.Single(f => f.JobID == 2).JobID, DepartmentID = depertment.Single(f => f.DepartmentID == 1).DepartmentID, ImageFile="~/Employees/555.jpg" },
                new Employee{FirstName="Israt Jahan", Lastname="Sharna", Address ="Saignboard, Narayanganj", Contact="01725-876488" , JobID = job.Single(f => f.JobID == 3).JobID, DepartmentID = depertment.Single(f => f.DepartmentID == 2).DepartmentID, ImageFile="~/Employees/666.jpg" },
                new Employee{FirstName="Zulhas", Lastname="Uddin", Address ="Ghatarchar, Mohammadpur", Contact="01725-874598" , JobID = job.Single(f => f.JobID == 3).JobID, DepartmentID = depertment.Single(f => f.DepartmentID == 3).DepartmentID, ImageFile="~/Employees/777.jpg" },
                new Employee{FirstName="Kawser", Lastname="Ahmed", Address ="Badda, Dhaka", Contact="01758-446898" , JobID = job.Single(f => f.JobID == 3).JobID, DepartmentID = depertment.Single(f => f.DepartmentID == 4).DepartmentID, ImageFile="~/Employees/888.jpg" },
                new Employee{FirstName="Rokeya", Lastname="Akter", Address ="Saignboard, Narayanganj", Contact="01725-875988" , JobID = job.Single(f => f.JobID == 4).JobID, DepartmentID = depertment.Single(f => f.DepartmentID == 1).DepartmentID, ImageFile="~/Employees/999.jpg" },

            };
            foreach (Employee e in employee)
            {
                context.Employee.Add(e);
            }
            context.SaveChanges();



            // Look for any EmploymentHistory

            if(context.EmploymentHistory.Any())
            {
                return;   // DB has been seeded
            }

            var empHistory = new EmploymentHistory[]
            {
                new EmploymentHistory{ EmployeeID = employee.Single(f => f.EmployeeID == 1).EmployeeID, CompanyId = company.Single(f => f.CompanyId == 1).CompanyId, CertificateID = certificate.Single(f => f.CertificateID == 3).CertificateID, InstituteID = institute.Single(f => f.InstituteID == 7).InstituteID, JobStarttDate= DateTime.Parse("2015-04-30"), JobEndDate= DateTime.Parse("2018-04-30"), },
                new EmploymentHistory{ EmployeeID = employee.Single(f => f.EmployeeID == 2).EmployeeID, CompanyId = company.Single(f => f.CompanyId == 2).CompanyId, CertificateID = certificate.Single(f => f.CertificateID == 3).CertificateID, InstituteID = institute.Single(f => f.InstituteID == 8).InstituteID, JobStarttDate= DateTime.Parse("2010-04-30"), JobEndDate= DateTime.Parse("2019-04-30"), },
                new EmploymentHistory{ EmployeeID = employee.Single(f => f.EmployeeID == 3).EmployeeID, CompanyId = company.Single(f => f.CompanyId == 3).CompanyId, CertificateID = certificate.Single(f => f.CertificateID == 3).CertificateID, InstituteID = institute.Single(f => f.InstituteID == 10).InstituteID, JobStarttDate= DateTime.Parse("2015-04-30"), JobEndDate= DateTime.Parse("2018-04-30"), },
                new EmploymentHistory{ EmployeeID = employee.Single(f => f.EmployeeID == 4).EmployeeID, CompanyId = company.Single(f => f.CompanyId == 1).CompanyId, CertificateID = certificate.Single(f => f.CertificateID == 3).CertificateID, InstituteID = institute.Single(f => f.InstituteID == 6).InstituteID, JobStarttDate= DateTime.Parse("2010-04-30"), JobEndDate= DateTime.Parse("2019-04-30"), },
                new EmploymentHistory{ EmployeeID = employee.Single(f => f.EmployeeID == 5).EmployeeID, CompanyId = company.Single(f => f.CompanyId == 2).CompanyId, CertificateID = certificate.Single(f => f.CertificateID == 3).CertificateID, InstituteID = institute.Single(f => f.InstituteID == 5).InstituteID, JobStarttDate= DateTime.Parse("2015-04-30"), JobEndDate= DateTime.Parse("2018-04-30"), },
                new EmploymentHistory{ EmployeeID = employee.Single(f => f.EmployeeID == 6).EmployeeID, CompanyId = company.Single(f => f.CompanyId == 3).CompanyId, CertificateID = certificate.Single(f => f.CertificateID == 3).CertificateID, InstituteID = institute.Single(f => f.InstituteID == 3).InstituteID, JobStarttDate= DateTime.Parse("2010-04-30"), JobEndDate= DateTime.Parse("2019-04-30"), },
                new EmploymentHistory{ EmployeeID = employee.Single(f => f.EmployeeID == 7).EmployeeID, CompanyId = company.Single(f => f.CompanyId == 1).CompanyId, CertificateID = certificate.Single(f => f.CertificateID == 3).CertificateID, InstituteID = institute.Single(f => f.InstituteID == 4).InstituteID, JobStarttDate= DateTime.Parse("2010-04-30"), JobEndDate= DateTime.Parse("2018-04-30"), },
                new EmploymentHistory{ EmployeeID = employee.Single(f => f.EmployeeID == 8).EmployeeID, CompanyId = company.Single(f => f.CompanyId == 2).CompanyId, CertificateID = certificate.Single(f => f.CertificateID == 3).CertificateID, InstituteID = institute.Single(f => f.InstituteID == 7).InstituteID, JobStarttDate= DateTime.Parse("2015-04-30"), JobEndDate= DateTime.Parse("2019-04-30"), },
                new EmploymentHistory{ EmployeeID = employee.Single(f => f.EmployeeID == 9).EmployeeID, CompanyId = company.Single(f => f.CompanyId == 3).CompanyId, CertificateID = certificate.Single(f => f.CertificateID == 3).CertificateID, InstituteID = institute.Single(f => f.InstituteID == 4).InstituteID, JobStarttDate= DateTime.Parse("2010-04-30"), JobEndDate= DateTime.Parse("2018-04-30"), }
            };
            foreach (EmploymentHistory e in empHistory)
            {
                context.EmploymentHistory.Add(e);
            }
            context.SaveChanges();



        }
    }
}
