using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB___Lab1
{
    public class DmgTypeClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DmgType { get; set; }
        public int HealthDmgModifyer { get; set; }
        public int ManaDmgModifyer { get; set; }
        public int StaminaDmgModifyer { get; set; }

        public string DmgTypeClassString => $"Id:{Id}, Name:{Name}, DmgType:{DmgType}, HealthDmgModifyer:{HealthDmgModifyer}, ManaDmgModifyer:{ManaDmgModifyer}, StaminaDmgModifyer:{StaminaDmgModifyer}";
    }
}
