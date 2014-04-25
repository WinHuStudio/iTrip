using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Repository;

namespace WinStudio.iTrip.Dto.Passport
{
    public class Profile : UIBaseEntity
    {
        [BsonIndex]
        public string Account { get; set; }

        [BsonIndex]
        public string Name { get; set; }

        [BsonIndex]
        public string SecurityKey { get; set; }

        [BsonIndex]
        public string Email { get; set; }

        public string UserIconId { get; set; }

        public Nationality Nationality { get; set; }

        public NativePlace Native { get; set; }

        public GlobalRegion Region { get; set; }

        private IMongoFile _usericon;

        [BsonIgnore]
        public IMongoFile UserIcon
        {
            get
            {
                if (_usericon != null)
                    return _usericon;
                if (UserIconId == null)
                    return null;
                _usericon = iTripFile.Instance<UserIcon>(UserIconId);
                return _usericon;
            }
            set
            {
                if (value == null)
                    UserIconId = null;
                else
                {
                    _usericon = value;
                    UserIconId = value.Id;
                }
            }
        }
    }
}
