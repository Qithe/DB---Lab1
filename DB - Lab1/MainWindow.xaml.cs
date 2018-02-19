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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Data Source=(localdb)\ProjectsV13;Initial Catalog=DIE_MAINFRAME;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        List<WeaponClass> WeaponList = new List<WeaponClass>();
        List<DmgTypeClass> DmgTypeList = new List<DmgTypeClass>();
        static SqlConnection conString = new SqlConnection(  @"Data Source = (localdb)\ProjectsV13; 
                                                Initial Catalog = Lab1_Database;
                                                Integrated Security = True;
                                                Connect Timeout = 30;
                                                Encrypt=False;
                                                TrustServerCertificate=True;
                                                ApplicationIntent=ReadWrite;
                                                MultiSubnetFailover=False");
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void UppdateWeaponList()
        {
            //Töm listan

            //Öppna connection
            //Loop
                //Välj rad X ur databasen
                //Lägg till de olika datan i ett object
                //Lägg objectet i listan
            //Stäng connection

        }

        private void ListBox_WeaponList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Go thru Types list to find the corresponding type
        }

        private void Button_WeaponList_Create_Click(object sender, RoutedEventArgs e)
        {
            AddWeaponTypeToTable(new WeaponClass(TextBox_WeaponList_Name.Text, 
                                            TextBox_WeaponList_BaseDmg.Text, 
                                            ComboBox_WeaponList_DmgType.SelectedValue.ToString()));
        }

        private void Button_DmgTypes_Create_Click(object sender, RoutedEventArgs e)
        {
            AddDmgTypeToTable(new DmgTypeClass(TextBox_DmgTypes_DmgType.Text,
                                            TextBox_DmgTypes_Name.Text,
                                            int.Parse(TextBox_DmgTypes_HpDmg.Text),
                                            int.Parse(TextBox_DmgTypes_MpDmg.Text),
                                            int.Parse(TextBox_DmgTypes_SpDmg.Text)));
        }

        public static void AddDmgTypeToTable(DmgTypeClass dtc)
        {
            string sqlQuery = $"INSERT INTO AttackTypeTable (name, DamageType, HealthDamage, ManaDamage, StaminaDamage) VALUES ('{dtc.Name}', '{dtc.DmgType}','{dtc.HealthDmgModifyer}', '{dtc.ManaDmgModifyer}, '{dtc.StaminaDmgModifyer}');";
            SqlCommand command = new SqlCommand(sqlQuery, conString);
            try
            {
                conString.Open();  // kan kasta exception
            }
            catch (SqlException ex) { Console.WriteLine("Something went horrible wrong"); }
            UpdateLists();

        }

        public static void AddWeaponTypeToTable(WeaponClass wc)
        {
            string sqlQuery = $"INSERT INTO WeaponTable (name, BaseAttack, AttackType) VALUES ('{wc.Name}', '{wc.DmgType}','{wc.DmgType}');";
            SqlCommand command = new SqlCommand(sqlQuery, conString);
            try
            {
                conString.Open();  // kan kasta exception
            }
            catch (SqlException ex) { Console.WriteLine("Something went horrible wrong"); }
            UpdateLists();

        }

        public static void UpdateLists()
        {

        }
    }
}
