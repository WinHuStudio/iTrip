using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Common.Wcf
{

    public abstract class SuperStandardResultService
    {
        /// <summary>
        /// 根据异常编码生成结果（当编码值小于Error_UnKnown(即9999)时，为正确，否则为错误）
        /// </summary>
        /// <param name="code">异常编码</param>
        /// <returns></returns>
        public virtual StandardResult Result(iTripExceptionCode code)
        {
            return new StandardResult(code < iTripExceptionCode.Error_UnKnown, code.ToString());
        }

        public virtual StandardResult Result(bool ret = true)
        {
            return new StandardResult(ret);
        }
        public virtual StandardResult Result(string err)
        {
            return new StandardResult(err);
        }
        public virtual StandardResult Result(int num)
        {
            return new StandardResult(num);
        }
        public virtual StandardResult Result(bool ret, string msg)
        {
            return new StandardResult(ret, msg);
        }
        public virtual StandardResult Result(object obj)
        {
            return new StandardResult(obj);
        }
    }
}
