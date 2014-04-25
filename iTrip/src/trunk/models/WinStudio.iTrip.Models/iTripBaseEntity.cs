using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace WinStudio.iTrip.Models
{
    public abstract class iTripBaseEntity : Entity
    {
        public abstract string LoggerCode { get; }
    }
}
