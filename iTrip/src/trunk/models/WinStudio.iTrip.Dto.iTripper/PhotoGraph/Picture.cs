using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace WinStudio.iTrip.Dto.iTripper.PhotoGraph
{
    public class Picture : Entity
    {
        public string Name { get; set; }
        public string LocalPath { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }
    }
}
