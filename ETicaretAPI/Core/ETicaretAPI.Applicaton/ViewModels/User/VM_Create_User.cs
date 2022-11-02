using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Applicaton.ViewModels.User
{
    public class VM_Create_User
    {
        public string UserName{ get; set; }

        public string Email{ get; set; }
        public string Password{ get; set; }

        public string PasswordConfirm { get; set; }
    }
}
