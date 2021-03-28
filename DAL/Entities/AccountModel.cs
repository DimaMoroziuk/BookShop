using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AccountModel
    {
        public string UserName {get;set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string LoggedOn { get; set; }
    }
}
