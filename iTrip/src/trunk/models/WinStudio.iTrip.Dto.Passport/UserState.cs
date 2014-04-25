using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStudio.iTrip.Dto.Passport
{
    //public class UserState : UIBaseEntity
    //{
    //    public string Code { get; set; }

    //    public string Name { get; set; }
    //}

    public enum UserState
    {
        [Description("新注册")]
        Registerd = 0,
        [Description("已激活")]
        Activated = 1,
        [Description("已冻结")]
        Frozen = 2
    }
}
