using iEAS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Orgnization
{
    /// <summary>
    /// 员工信息
    /// </summary>
    public class Employee : IdentityEntity
    {
        private List<Title> _Titles = new List<Title>();
        private List<EmployeePosition> _DepartmentPostions = new List<EmployeePosition>();
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNumber { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public string ChineseName { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public string EnglishName { get; set; }
        /// <summary>
        /// 雇佣日期
        /// </summary>
        public DateTime? HiredDate { get; set; }
        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? TerminatedDate { get; set; }
        /// <summary>
        /// 性别(0:女，1：男)
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        #region 家庭信息
        public string HomeCountry { get; set; }
        public string HomeCountryName { get; set; }
        public string HomeProvince { get; set; }
        public string HomeProvinceName { get; set; }
        public string HomeCity { get; set; }
        public string HomeCityName { get; set; }
        public string HomeCounty { get; set; }
        public string HomeCountyName { get; set; }
        public string HomeAddress { get; set; }
        public string HomePhone { get; set; }
        public string HomeZipCode { get; set; }
        #endregion
        #region 工作信息
        /// <summary>
        /// 办公室电话
        /// </summary>
        public string OfficePhone { get; set; }
        /// <summary>
        /// 移动电话1
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 移动电话2
        /// </summary>
        public string MobilePhone2 { get; set; }
        /// <summary>
        /// 邮箱1
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 邮箱2
        /// </summary>
        public string Email2 { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 工作所在国家
        /// </summary>
        public string WorkCountry { get; set; }
        /// <summary>
        /// 工作所在国家
        /// </summary>
        public string WorkCountryName { get; set; }
        /// <summary>
        /// 工作所在省份
        /// </summary>
        public string WorkProvince { get; set; }
        /// <summary>
        /// 工作所在省份
        /// </summary>
        public string WorkProvinceName { get; set; }
        /// <summary>
        /// 工作所在市
        /// </summary>
        public string WorkCity { get; set; }
        /// <summary>
        /// 工作所在市
        /// </summary>
        public string WorkCityName { get; set; }
        /// <summary>
        /// 工作所在县
        /// </summary>
        public string WorkCounty { get; set; }
        /// <summary>
        /// 工作所在县
        /// </summary>
        public string WorkCountyName { get; set; }
        /// <summary>
        /// 工作邮编
        /// </summary>
        public string WorkZipCode { get; set; }
        /// <summary>
        /// 工作地址
        /// </summary>
        public string WorkAddress { get; set; }
        /// <summary>
        /// 工作所属地
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 工作所属地名称
        /// </summary>
        public string LocationName { get; set; }
        /// <summary>
        /// 所属区域
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 所属区域
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 职级
        /// </summary>
        public string JobGrade { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 工作状态（1：在职，2：离职，3：试用，4：临聘,5:实习）
        /// </summary>
        public int WorkStatus { get; set; }

        public string WorkStatsDisplayName
        {
            get 
            {
                switch (WorkStatus)
                {
                    case 1:
                        return "在职";
                    case 2:
                        return "离职";
                    case 3:
                        return "试用";
                    case 4:
                        return "临聘";
                    case 5:
                        return "实习";
                }
                return String.Empty;
            }
        }

        public Guid? ReportLine { get; set; }
        #endregion
        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual User User { get; set; }

        public virtual Employee ReportLineUser { get; set; }

        public virtual List<Title> Titles
        {
            get { return _Titles; }
            set { _Titles = value; }
        }

        public virtual List<EmployeePosition> DepartmentPostions
        {
            get { return _DepartmentPostions; }
            set { _DepartmentPostions = value; }
        }
    }
}
