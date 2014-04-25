using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.DeliveryCenter
{
    public enum PackageContentType
    {
        [Description("Text")]
        T = 20,
        [Description("Image")]
        I = 9,
        [Description("Audio")]
        A = 1,
        [Description("Video")]
        V = 22,
        [Description("File")]
        F = 6,
        [Description("Location")]
        L = 12
    }
}
