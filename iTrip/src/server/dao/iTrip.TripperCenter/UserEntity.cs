using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;

namespace iTrip.TripperCenter
{
    public class UEntity : MEntity
    {
        public UEntity()
        {
            Gender = Gender.Unknown;
        }

        public string Account { get; set; }
        /// <summary>
        /// 性别（默认Gender.Unknown）
        /// </summary>
        public Gender Gender { get; set; }

    }
}
