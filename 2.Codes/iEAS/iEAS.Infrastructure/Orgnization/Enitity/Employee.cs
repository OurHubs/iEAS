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
        private IEnumerable<EmployeeTitle> _EmployeeTitles;
        private IEnumerable<ReportLine> _ReportLines;
        private IEnumerable<EmployeePosition> _EmployeePositions;

        /// <summary>
        /// 用户信息ID
        /// </summary>
        public int UserID { get; set; }
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
        public DateTime? TerminatedDate  { get; set; }
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
        /// 工作状态（1：正式员工，2：离职员工，3：试用期，4：临时工）
        /// </summary>
        public int WorkStatus { get; set; }
        #endregion
        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// 获取Title信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeTitle> GetTitles()
        {
            if (_EmployeeTitles == null)
            {
                IEmployeeTitleService employeeTitleService = ObjectContainer.GetService<IEmployeeTitleService>();
                _EmployeeTitles = employeeTitleService.Query(m => m.EmployeeID == ID && m.Status == 1);
            }
            return _EmployeeTitles;
        }

        public IEnumerable<ReportLine> GetReportLines()
        {
            if(_ReportLines==null)
            {
                IReportLineService reportLineService = ObjectContainer.GetService<IReportLineService>();
                _ReportLines = reportLineService.Query(m =>m.EmployeeID==ID && m.Status == 1);
            }
            return _ReportLines;
        }

        public IEnumerable<EmployeePosition> GetPositions()
        {
            if(_EmployeePositions==null)
            {
                IEmployeePositionService EPService = ObjectContainer.GetService<IEmployeePositionService>();
                _EmployeePositions = EPService.Query(m => m.EmployeeID == ID && m.Status == 1);
            }
            return _EmployeePositions;
        }
    }
}
