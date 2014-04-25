using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Core.Security;
using iTrip.iPP.IProxy;
using iTrip.iPP.Proxy;
using iTrip.Service.Wcf.Message.IPublisherIM;
using iTrip.Service.Wcf.Status.ITripperStatusResolver;
using SuperSocket.SocketBase;
using SuperWebSocket;
using SuperWebSocket.SubProtocol;
using WinStudio.Msmq.Client;
using WinStudio.WcfManager;

namespace iTrip.Push.iTripSession
{
    public class TripSession : WebSocketSession<TripSession>
    {

        DateTime _lastime = DateTime.Now;
        IMClient client;

        public TripSession()
        {
            _lastime = DateTime.Now;
        }

        public string Ticket { get; set; }

        public string Account { get; set; }

        public string DeviceSN { get; set; }

        public DateTime LastTime { get { return _lastime; } }

        public void RefreshTime()
        {
            _lastime = DateTime.Now;
        }

        public void ExcuteRequestPackage(SubRequestInfo requestInfo)
        {
            try
            {
                ExcuteRequestPackage(new ipp_Package(requestInfo.Body));
            }
            catch (Exception e)
            {
                this.Send(Encoding.Default.GetBytes("Error"), 0, 5);
            }
        }
        public void ExcuteRequestPackage(ipp_Package package)
        {
            byte[] result = package.ToServerResultBytes();
            this.Send(result, 0, result.Length);
            if (package.IsValid())
            {
                WcfFactory.PackageDeliveryHost.GetService<IPackageDelivery>().PackageDeliveryToServer(package);
                byte[] bytes = package.ToServerResultBytes();
                Send(bytes, 0, bytes.Length);
                //todo:DeliveryPackage
            }
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            if (!string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(Ticket))
                WcfFactory.PackageDeliveryHost.GetService<ITripperStatusParser>().SwitchStatus(Account, false);
            //if (client != null)
            //    client.Close();
            base.OnSessionClosed(reason);
        }

        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
            //Read auther info from path
            var auther = Path;

            //验证用户合法性
            if (string.IsNullOrEmpty(auther) || auther.Length == 1)
            {
                this.Send("denied for anoy");
                this.Close();
            }
            else
                auther = Path.TrimStart('/');

            var autherinfo = auther.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            if (autherinfo.Length != 3)
            {
                this.Send("illegal user");
                this.Close();
            }

            if (!TicketGenerator.Instance.ValidTicket(autherinfo[0], autherinfo[1], autherinfo[2]))
            {
                this.Send("illegal user");
                this.Close();
            }

            Account = autherinfo[0];
            DeviceSN = autherinfo[1];
            Ticket = autherinfo[2];
            WcfFactory.PackageDeliveryHost.GetService<ITripperStatusParser>().SwitchStatus(Account, true);

            this.Send("Welcome to iTrip again");

            //this.Logger.Error("init msmq");
            ////注册MSMQ
            //try
            //{
            //    //ClientFactory.SetMsmqServer("WIN-FQFQV3GJ0Q2");
            //    client = ClientFactory.CreateClient(Account);
            //    client.HandlMessage += HandleReceivedPackage;
            //    this.Logger.Error("beginreceive");
            //    client.BeginReceive();
            //}
            //catch (Exception e)
            //{
            //    this.Logger.Error(e);
            //    this.Close(CloseReason.Unknown);
            //}

        }

        public void HandleReceivedPackage(object message)
        {
            this.Logger.Error("HandleReceivedPackage");
            IPackage package = message as IPackage;
            var bytes = package.ToClientBytes();
            this.Send(bytes, 0, bytes.Length);
            //this.Send(string.Format("Whisper from {0}:{1}", package.PS, package.PC));
        }
    }
}
