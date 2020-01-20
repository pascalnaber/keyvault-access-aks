using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyVaultReader.Models
{
    public class SecretsViewModel
    {
        public string KeyVaultName { get; set; }
        public string SecretName { get; set; }
        public string Secret { get; set; }
    }
}
