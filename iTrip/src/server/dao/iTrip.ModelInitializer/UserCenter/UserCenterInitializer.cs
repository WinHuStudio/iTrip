using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;
using iTrip.TripperCenter;
using MongoDB.Repository;

namespace iTrip.ModelInitializer
{
    public class UserCenterInitializer
    {
        private string _default_password = "888888".ToMD5();
        public void Init()
        {
            new List<Passport> { 
                new Passport{ Account="huyunfeng",Password=_default_password},
                new Passport{ Account="xionglin",Password=_default_password},
                new Passport{ Account="wangsheng",Password=_default_password},
                new Passport{ Account="chengxiaoxue",Password=_default_password},
            }.ForEach(p => p.Save());


            new List<Profile> { 
                new Profile{ Account="huyunfeng", Name="胡云丰", Client=ClientType.Android, Gender= Gender.Male, ClientSN="Android-123456"},
                new Profile{ Account="xionglin", Name="熊林", Client=ClientType.iOS, Gender= Gender.Male, ClientSN="iOS-123456"},
                new Profile{ Account="wangsheng", Name="王胜", Client=ClientType.Android, Gender= Gender.Male, ClientSN="Android-234567"},
                new Profile{ Account="chengxiaoxue", Name="程晓雪", Client=ClientType.iOS, Gender= Gender.Male, ClientSN="iOS-234567"}
            }.ForEach(p => p.Save());
        }

        public void Remove()
        {
            MongoEntity.RemoveAll<Passport>();
            MongoEntity.RemoveAll<Profile>();
        }
    }
}
