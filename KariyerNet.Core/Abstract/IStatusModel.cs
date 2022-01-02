using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Core.Abstract
{
    public interface IStatusModel
    {
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
    }
}
