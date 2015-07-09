using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Orgnization
{
    public class EmployeeMapping : IdentityEntityMapping<Employee>
    {
        public EmployeeMapping()
        {
            this.ToTable("EMPLOYEE");

            this.Property(m => m.UserID, "User_ID");
            this.Property(m => m.EmployeeNumber, "EMPLOYEE_NUMBER", 50);
            this.Property(m => m.ChineseName, "CHINESE_NAME", 50);
            this.Property(m => m.EnglishName, "ENGLISH_NAME", 50);
            this.Property(m => m.HiredDate, "HIRED_DATE");
            this.Property(m => m.TerminatedDate, "TERMINATED_DATE");
            this.Property(m => m.Gender, "GENDER");
            this.Property(m => m.Birthday, "BIRTHDAY");
            this.Property(m => m.HomeCountry, "HOME_COUNTRY",50);
            this.Property(m => m.HomeCountryName, "HOME_COUNTRYNAME", 50);
            this.Property(m => m.HomeProvince, "HOME_PROVINCE",50);
            this.Property(m => m.HomeProvinceName, "HOME_PROVINCE_NAME", 50);
            this.Property(m => m.HomeCity, "HOME_CITY", 50);
            this.Property(m => m.HomeCityName, "HOME_CITY_NAME", 50);
            this.Property(m => m.HomeCounty, "HOME_COUNTY", 50);
            this.Property(m => m.HomeCountyName, "HOME_COUNTY_NAME", 50);
            this.Property(m => m.HomeAddress, "HOME_ADDRESS", 500);
            this.Property(m => m.HomePhone, "HOME_PHONE", 50);
            this.Property(m => m.HomeZipCode, "HOME_ZIP_CODE", 50);
            this.Property(m => m.OfficePhone, "OFFICE_PHONE", 50);
            this.Property(m => m.MobilePhone, "MOBILE_PHONE", 50);
            this.Property(m => m.MobilePhone2, "MOBILE_PHONE2", 50);
            this.Property(m => m.Email, "EMAIL", 50);
            this.Property(m => m.Email2, "EMAIL2", 50);
            this.Property(m => m.Fax, "FAX", 50);
            this.Property(m => m.WorkCountry, "WORK_COUNTRY", 50);
            this.Property(m => m.WorkCountryName, "WORK_COUNTRY_NAME", 50);
            this.Property(m => m.WorkProvince, "WORK_PROVINCE", 50);
            this.Property(m => m.WorkProvinceName, "WORK_PROVINCE_NAME", 50);
            this.Property(m => m.WorkCity, "WORK_CITY", 50);
            this.Property(m => m.WorkCityName, "WORK_CITY_NAME", 50);
            this.Property(m => m.WorkCounty, "WORK_COUNTY", 50);
            this.Property(m => m.WorkCountyName, "WORK_COUNTY_NAME", 50);
            this.Property(m => m.WorkZipCode, "WORK_ZIP_CODE", 50);
            this.Property(m => m.WorkAddress, "WORK_ADDRESS", 500);
            this.Property(m => m.Location, "LOCATION", 50);
            this.Property(m => m.LocationName, "LOCATION_NAME", 50);
            this.Property(m => m.Area, "AREA", 50);
            this.Property(m => m.AreaName, "AREA_NAME", 50);
            this.Property(m => m.JobGrade, "JOB_GRADE", 50);
            this.Property(m => m.Desc, "DESC", 500);
            this.Property(m => m.WorkStatus, "WORK_STATUS");

            this.HasRequired(m => m.User).WithMany().HasForeignKey(m => m.UserID);
        }
    }
}
