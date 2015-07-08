using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace iEAS.Model.UI
{
    public class UxModelPager:UserControl
    {
        private UxModelPagedControl _PagedControl;
        private int _NumericButtonCount = 5;

        public string RelatedID { get; set; }

        public UxModelPagedControl PagedControl
        {
            get
            {
                if(_PagedControl==null)
                {
                    _PagedControl = this.NamingContainer.FindControl(RelatedID) as UxModelPagedControl;
                    if (_PagedControl == null)
                    {
                        throw new SystemException("控件不存在或类型不正确:[RelatedID=" + RelatedID + "]");
                    }
                }
                return _PagedControl;
            }
        }

        public int PageSize
        {
            get { return PagedControl.PageSize; }
        }
        
        public int CurrentPageIndex
        {
            get { return PagedControl.PageIndex; }
        }

        public int RecordCount
        {
            get { return PagedControl.RecordCount; }
        }

        public int PageCount
        {
            get { return RecordCount / PageSize + (RecordCount % PageSize == 0 ? 0 : 1); }
        }

        public int NextPageIndex
        {
            get
            {
                return HasNextPageIndex ? CurrentPageIndex + 1 : PageCount;
            }
        }

        public int PrevPageIndex
        {
            get
            {
                return HasPrevPageIndex ? CurrentPageIndex - 1 : 1;
            }
        }

        public bool HasNextPageIndex
        {
            get { return CurrentPageIndex < PageCount; }
        }

        public bool HasPrevPageIndex
        {
            get { return CurrentPageIndex > 1; }
        }

        public int NumericButtonCount
        {
            get { return _NumericButtonCount; }
            set { _NumericButtonCount = value; }
        }

        public int StartPageIndex
        {
            get
            {
                return (CurrentPageIndex / NumericButtonCount - (CurrentPageIndex % NumericButtonCount == 0 ? 1 : 0)) * NumericButtonCount + 1;
            }
        }

        public int EndPageIndex
        {
            get
            {
                int endPageIndex = StartPageIndex + NumericButtonCount - 1;
                return endPageIndex > PageCount ? PageCount : endPageIndex;
            }
        }
    }
}
