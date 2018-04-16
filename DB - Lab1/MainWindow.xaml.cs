using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;

namespace DB___Lab1
{
    
    public partial class MainWindow : Window
    {
        DataHandlers dh = new DataHandlers();

        public MainWindow()
        {
            InitializeComponent();
            UpdateLists();
        }

        List<WeaponClass> WeaponList = new List<WeaponClass>();
        List<DmgTypeClass> DmgTypeList = new List<DmgTypeClass>();
        

        public void UpdateLists()
        {
            //Clear the lists
            ListBox_WeaponList.Items.Clear();
            ListBox_DmgTypes.Items.Clear();

            //Fetch the fresh data
            WeaponList = dh.ReadWeapon().ToList();
            DmgTypeList = dh.ReadDmgType().ToList();

            //Put data in respective list and set the display
            foreach (WeaponClass weapon in WeaponList)
            {
                ListBox_WeaponList.Items.Add(weapon);
            }
            ListBox_WeaponList.DisplayMemberPath = "WeaponClassString";

            foreach (DmgTypeClass dmgType in DmgTypeList)
            {
                ListBox_DmgTypes.Items.Add(dmgType);
            }
            ListBox_DmgTypes.DisplayMemberPath = "DmgTypeClassString";
        }

        
    }
    public static class Globals
    {
        public const string connectionString = "@Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Lab1db; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
