using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using iTrip.Web.Common.Security.Validator;

namespace iTrip.Web.Common.Security
{
    public interface IContextValidator
    {
        int Order { get; }
        WebRequestFilterType FilterType { get; }
        bool Validate(IWebController context);
    }

    public class ValidatorFactory
    {
        private List<IContextValidator> _validators = new List<IContextValidator>();

        private static ValidatorFactory _factory = new ValidatorFactory();
        public static ValidatorFactory Instance { get { return _factory; } }

        public void PushValidator(IContextValidator validator)
        {
            if (_validators.Exists(v => v.FilterType == validator.FilterType && v.Order == validator.Order)) return;
            _validators.Add(validator);
            _validators.Sort(ValidatorComparison);
        }
        public void PopValidator(WebRequestFilterType filterType, int order = 0)
        {
            if (order == 0)
                _validators.RemoveAll(v => v.FilterType == filterType);
            else _validators.RemoveAll(v => v.FilterType == filterType && v.Order == order);
        }
        public void PopValidator()
        {
            _validators.Clear();
        }
        private int ValidatorComparison(IContextValidator a, IContextValidator b)
        {
            if (a.FilterType == b.FilterType)
                return a.Order - b.Order;
            return a.FilterType - b.FilterType;
        }

        public List<IContextValidator> GetValidator(WebRequestFilterType filterType)
        {
            if (filterType == 0) return _validators;
            var ret= _validators.Where(v => (filterType & v.FilterType) != 0).ToList();
            return ret;
        }

        public bool Validate(IWebController context, WebRequestFilterType level)
        {
            foreach (var validator in GetValidator(level))
            {
                if (!validator.Validate(context)) return false;
            }
            return true;
        }

        public void LoadDefaultValidator()
        {
            ValidatorFactory.Instance.PushValidator(new RequestAuthenticationValidator());
            ValidatorFactory.Instance.PushValidator(new RequestDeviceSNValidator());
            ValidatorFactory.Instance.PushValidator(new RequestVersionValidator());
            ValidatorFactory.Instance.PushValidator(new RequestAccountValidator());
            ValidatorFactory.Instance.PushValidator(new RequestDeviceTypeValidator());
            ValidatorFactory.Instance.PushValidator(new RequestTicketValidator());
            ValidatorFactory.Instance.PushValidator(new RequestWebMethodValidator());
        }
    }
    public class test
    {
        public void run()
        {
            ValidatorFactory.Instance.PushValidator(new RequestVersionValidator());
            ValidatorFactory.Instance.PushValidator(new RequestTicketValidator());
            ValidatorFactory.Instance.PushValidator(new RequestAccountValidator());
            ValidatorFactory.Instance.PushValidator(new RequestDeviceSNValidator());
            ValidatorFactory.Instance.PushValidator(new RequestWebMethodValidator());
            ValidatorFactory.Instance.PushValidator(new RequestAuthenticationValidator());
            ValidatorFactory.Instance.PushValidator(new RequestDeviceTypeValidator());


            var ret = ValidatorFactory.Instance.GetValidator(
                (WebRequestFilterType.Version |
                WebRequestFilterType.Account |
                WebRequestFilterType.DeviceType));
            if (ret.Count == 0) Console.WriteLine("Null Validator");
            ret.ForEach(v => Console.WriteLine(v.FilterType));
        }
    }
}
