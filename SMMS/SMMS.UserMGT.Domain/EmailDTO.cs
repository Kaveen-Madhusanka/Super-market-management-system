using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.UserMGT.Domain
{
    public class EmailDTO
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string host { get; set; }
        public int ssl { get; set; }
    }
}
