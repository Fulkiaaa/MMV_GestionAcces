using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MMV_CSharp
{
    public class Personne
    {
        public int? PER_ID { get; set; }
        public int HAB_ID { get; set; }
        public string PER_NOM { get; set; }
        public string PER_PRENOM { get; set; }
        public string HAB_NOM { get; set; }
        public string PER_PHOTO { get; set; }
    }
}
