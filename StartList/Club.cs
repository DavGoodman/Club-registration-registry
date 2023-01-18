using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartList
{
    internal class Club
    {
        public string ClubName { get; set; }
        public List<Registration> Registrations { get; set; }

        public Club(string name)
        {
            ClubName = name;
            Registrations = new List<Registration>();
        }
    }
}
