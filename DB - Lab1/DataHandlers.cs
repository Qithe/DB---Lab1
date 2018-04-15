using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB___Lab1
{
    public class DataHandlers
    {
        //Read
        public List<WeaponClass> FetchWeaponClasses()
        {
            //lists to store in
            List<WeaponClass> weaponClassesResult = new List<WeaponClass>();

            //Create SQL querys
            string weaponQuery = String.Format("select * from WeaponTable");

            //Create and open a connection to SQL server
            SqlConnection conn = new SqlConnection(Globals.connectionString);

            //Try to fetch data for weapons
            try
            {
                conn.Open();


                SqlCommand commandWeapons = new SqlCommand(weaponQuery, conn);

                //Create DataReader for storing the returning table into server memory
                SqlDataReader dataReader = commandWeapons.ExecuteReader();

                WeaponClass weaponClass = null;

                //load into the result object the returned row from the database
                if (dataReader.HasRows())
                {
                    while (dataReader.Read())
                    {
                        weaponClass = new WeaponClass();

                        weaponClass.Id = Convert.ToInt32(dataReader["Id"]);
                        weaponClass.Name = dataReader["Name"].ToString();
                        weaponClass.BaseDmg = Convert.ToInt32(dataReader["BaseDmg"]);
                        weaponClass.DmgType = dataReader["DmgType"].ToString();

                        weaponClassesResult.Add(weaponClass);
                    }
                }
                return weaponClassesResult;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<DmgTypeClass> FetchDmgTypeClasses()
        {
            //lists to store in
            List<DmgTypeClass> dmgTypeClassesResult = new List<DmgTypeClass>();

            //Create SQL querys
            string dmgTypeQuery = String.Format("select * from DamageTypeTable");

            //Create and open a connection to SQL server
            SqlConnection conn = new SqlConnection(Globals.connectionString);

            //Try to fetch data for weapons
            try
            {

                conn.Open();

                SqlCommand commandWeapons = new SqlCommand(dmgTypeQuery, conn);

                //Create DataReader for storing the returning table into server memory
                SqlDataReader dataReader = commandWeapons.ExecuteReader();

                DmgTypeClass dmgTypeClass = null;

                //load into the result object the returned row from the database
                if (dataReader.HasRows())
                {
                    while (dataReader.Read())
                    {
                        dmgTypeClass = new DmgTypeClass();

                        dmgTypeClass.Id = Convert.ToInt32(dataReader["Id"]);
                        dmgTypeClass.Name = dataReader["Name"].ToString();
                        dmgTypeClass.HealthDmgModifyer = Convert.ToInt32(dataReader["HealthDmgModifyer"]);
                        dmgTypeClass.ManaDmgModifyer = Convert.ToInt32(dataReader["ManaDmgModifyer"]);
                        dmgTypeClass.StaminaDmgModifyer = Convert.ToInt32(dataReader["StaminaDmgModifyer"]);

                        dmgTypeClassesResult.Add(dmgTypeClass);
                    }
                }
                return dmgTypeClassesResult;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void CreateWeapon(WeaponClass weaponClass)
        {
            //Create SQL querry string
            string sqlQuery = String.Format($"Insert into [WeaponsTable] ([Name], [BaseDmg], [DmgType]) Values ('{weaponClass.Name}', '{weaponClass.BaseDmg}', '{weaponClass.DmgType}');");

            //Create and open a connection to SQL server
            SqlConnection conn = new SqlConnection(Globals.connectionString);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                sqlCommand.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void CreateDmgType(DmgTypeClass dmgTypeClass)
        {
            //Create SQL querry string
            string sqlQuery = String.Format($"Insert into [WeaponsTable] ([Name], [DmgType], [HealthDmgModifyer], [ManaDmgModifyer], [StaminaDmgModifyer]) Values ('{dmgTypeClass.Name}', '{dmgTypeClass.DmgType}', '{dmgTypeClass.HealthDmgModifyer}', '{dmgTypeClass.ManaDmgModifyer}', '{dmgTypeClass.StaminaDmgModifyer}');");

            //Create and open a connection to SQL server
            SqlConnection conn = new SqlConnection(Globals.connectionString);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                sqlCommand.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void UpdateWeapon(WeaponClass weaponClass)
        {
            //Create SQL query string
            string sqlQuery = String.Format($"update [Weapon] set Name = {weaponClass.Name}, BaseDmg = {weaponClass.BaseDmg}, DmgType = {weaponClass.DmgType} where Id = {weaponClass.Id}");

            //Create and open a connction
            SqlConnection conn = new SqlConnection(Globals.connectionString);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
