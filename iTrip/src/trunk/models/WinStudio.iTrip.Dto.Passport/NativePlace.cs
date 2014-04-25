using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WinStudio.iTrip.Dto.Passport
{
    /// <summary>
    /// 户籍
    /// </summary>
    public class NativePlace : UIBaseEntity
    {
        public NativePlace() { Children = new List<NativePlace>(); }

        public string Code { get; set; }

        public string Name { get; set; }

        public List<NativePlace> Children { get; set; }
    }

    /// <summary>
    /// 国籍
    /// </summary>
    public class Nationality : UIBaseEntity
    {
        public Nationality() { NativePlaces = new List<NativePlace>(); }

        public string Name { get; set; }

        public string Code { get; set; }

        public List<NativePlace> NativePlaces { get; set; }
    }

    /// <summary>
    /// 洲际
    /// </summary>
    public class GlobalRegion : UIBaseEntity
    {
        public GlobalRegion() { Nationalities = new List<Nationality>(); }

        public string Name { get; set; }

        public string Code { get; set; }

        public List<Nationality> Nationalities { get; set; }
    }
}
