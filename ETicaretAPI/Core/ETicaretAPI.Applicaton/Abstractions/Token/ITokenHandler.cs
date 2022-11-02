using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Applicaton.Abstractions.Token
{
    public interface ITokenHandler
    {
       DTOs.Token CreateAccessToken();

       string CreateRefreshToken();

    }
}
