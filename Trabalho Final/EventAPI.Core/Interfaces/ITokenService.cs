using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAPI.Core.Interfaces
{
    public interface ITokenService
    {
        public string GenerateTokenEventAPI(string Name, string Permission);
    }
}
