using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Core.Abstract
{
    public interface ITimeInfoModel
    {
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        DateTime DeleteDate { get; set; }
    }
}
