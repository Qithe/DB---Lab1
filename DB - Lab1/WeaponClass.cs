using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB___Lab1
{
    public class WeaponClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseDmg { get; set; }
        public string DmgType { get; set; }

        public string WeaponClassString => $"Id:{Id}, Name:{Name}, BaseDmg:{BaseDmg}, DmgType:{DmgType}";
    }
}
