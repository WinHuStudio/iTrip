using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Service.Business.Status.ITripperStatusReception;
using iTrip.Service.Business.Status.TripperStatusReception;
using iTrip.Service.Common.Wcf;
using iTrip.Service.Wcf.Message.IPublisherIM;
using iTrip.Service.Wcf.Status.ITripperStatusResolver;

namespace iTrip.Service.Wcf.Status.TripperStatusResolver
{
    [WinWcfService]
    public class TripperStatusParser : SuperWcfService, ITripperStatusParser
    {
        public bool CanBePush(string account, int settingType)
        {
            ITripperStatusManager statusManager = new TripperStatusManager();
            return statusManager.CanBePush(account, settingType);
        }

        public void SwitchStatus(string account, bool state)
        {
            ITripperStatusManager statusManager = new TripperStatusManager();
            var lpt = statusManager.SwitchStatus(account, state);
            if (lpt < DateTime.MaxValue)
            {
                IPackageDelivery delivery = GetService<IPackageDelivery>();
                delivery.PackageDeliveryToClient(account, lpt);
            }
        }

        public void SwitchSetting(string account, int settingType)
        {
            ITripperStatusManager statusManager = new TripperStatusManager();
            statusManager.SwitchSetting(account, settingType);
        }

        public void RegisterTripper(string account, string ticket)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(ticket)) return;
            ITripperStatusManager manager = new TripperStatusManager();
            manager.RegisterTripper(account, ticket);
        }
    }
}
