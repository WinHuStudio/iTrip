using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace iTrip
{

    [ServiceContract]
    public class StandardResult
    {
        public StandardResult() { }
        public StandardResult(bool ret = true) : this(ret, string.Empty) { }
        public StandardResult(string err) : this(false, err) { }
        public StandardResult(bool ret, string err)
        {
            Ret = ret;
            Msg = err;
        }
        public StandardResult(int num)
        {
            Ret = num > 0;
            Num = num;
        }
        public StandardResult(object t)
        {
            Ret = t != null;
            Obj = t;
        }
        [DataMember]
        public virtual bool Ret { get; set; }

        [DataMember]
        public virtual string Msg { get; set; }

        [DataMember]
        public virtual int Num { get; set; }

        [DataMember]
        public virtual object Obj { get; set; }

        public virtual string GetMsg(string code)
        {
            throw new NotImplementedException();
        }

        public virtual void AddMsg(string msg, string code)
        {
            throw new NotImplementedException();
        }
    }
}
