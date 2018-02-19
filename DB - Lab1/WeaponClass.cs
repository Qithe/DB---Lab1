using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB___Lab1
{
    public class WeaponClass: MasterClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseDmg { get; set; }
        public string DmgType { get; set; }

        public WeaponClass(string name, string baseDmg, string dmgType)
        {
            this.Name = name;
            this.DmgType = dmgType;
            int temp=0;
            try
            {
                temp = int.Parse(baseDmg);
            }
            catch (Exception)
            {
                
            }
            finally
            {
                this.BaseDmg = temp;
            }
            //sätta ett id likt i dmgtypeclass
        }
    }
}
