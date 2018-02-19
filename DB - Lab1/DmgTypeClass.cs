using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB___Lab1
{
    public class DmgTypeClass: MasterClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DmgType { get; set; }
        public int HealthDmgModifyer { get; set; }
        public int ManaDmgModifyer { get; set; }
        public int StaminaDmgModifyer { get; set; }

        public DmgTypeClass(string name, string dmgType, int healthDmgModifyer, int manaDmgModifyer, int staminaDmgModifyer)
        {
            //behöver trys för att inte få massa goa buggar
            this.Name = name;
            this.DmgType = dmgType;
            this.HealthDmgModifyer = healthDmgModifyer;
            this.ManaDmgModifyer = manaDmgModifyer;
            this.StaminaDmgModifyer = staminaDmgModifyer;

            //get the last id and add one to make the id
        }
    }
}
