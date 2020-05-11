using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

namespace WorldOfBeauty
{
    internal class DBActions
    {
        public static SqlCommand cmd = new SqlCommand(string.Empty, DBConnect.sql);
        //Добавление названия и типа процедуры 
        private static void spConfiguration(string spName)
        {
            cmd.CommandText = spName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public static string execScalar()
        {
            DBConnect.sql.Open();
            string scalar = DBActions.cmd.ExecuteScalar().ToString();
            DBConnect.sql.Close();
            return scalar;
        }


        //Вызов процедуры Добавления в таблицу "Check"
        public static void Check_Insert(string Check_Num, string Check_Date, string Check_Time,
                float Sum, int Employee_Id, int Salon_Id)
        {
            spConfiguration("Check_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Nom_Check", Check_Num);
                cmd.Parameters.AddWithValue("@Data", Check_Date);
                cmd.Parameters.AddWithValue("@Time", Check_Time);
                cmd.Parameters.AddWithValue("@Summ", Sum);
                cmd.Parameters.AddWithValue("@Klient_Id", Employee_Id);
                cmd.Parameters.AddWithValue("@Salon_Id", Salon_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "Check"
        public static void Check_Update(int id_Check, string Check_Num, string Check_Date, string Check_Time, float Sum,
                 int Stor_Id, int Salon_Id, int Klient_Id)
        {
            spConfiguration("Upd_Check");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_Check", id_Check);
                cmd.Parameters.AddWithValue("@CN", Check_Num);
                cmd.Parameters.AddWithValue("@CD", Check_Date);
                cmd.Parameters.AddWithValue("@CT", Check_Time);
                cmd.Parameters.AddWithValue("@s", Sum);
                cmd.Parameters.AddWithValue("@SI", Stor_Id);
                cmd.Parameters.AddWithValue("@HI", Salon_Id);
                cmd.Parameters.AddWithValue("@Klient_Id", Klient_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "Check"
        public static void Check_Delete(int ID)
        {
            spConfiguration("Del_Check");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Check", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры Добавления в таблицу "client"
        public static void client_Insert(string Surn_Client, string Name_Client, string Midn_Client, string Mob_Num_Client)
        {
            spConfiguration("Klient_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Fam", Surn_Client);
                cmd.Parameters.AddWithValue("@Name", Name_Client);
                cmd.Parameters.AddWithValue("@Otch", Midn_Client);
                cmd.Parameters.AddWithValue("@Tel", Mob_Num_Client);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "client"
        public static void client_Update(int id_client, string Surn_Client, string Name_Client, string Midn_Client, string Mob_Num_Client,
                int Sale_Id, int User_Id)
        {
            spConfiguration("Upd_klient");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Klient", id_client);
                cmd.Parameters.AddWithValue("@SC", Surn_Client);
                cmd.Parameters.AddWithValue("@NC", Name_Client);
                cmd.Parameters.AddWithValue("@MC", Midn_Client);
                cmd.Parameters.AddWithValue("@MNC", Mob_Num_Client);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "client"
        public static void client_Delete(int ID)
        {
            spConfiguration("Del_Klient");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Klient", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }
   
        //Вызов процедуры Добавления в таблицу "Delivery"
        public static void Delivery_Insert(string Invoice_Num, string Delivery_Date, string Delivery_Time, string Product_Name, int Product_Count)
        {
            spConfiguration("Postavka_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Nom_Naklad", Invoice_Num);
                cmd.Parameters.AddWithValue("@data", Delivery_Date);
                cmd.Parameters.AddWithValue("@Time", Delivery_Time);
                cmd.Parameters.AddWithValue("@Name_Tov", Product_Name);
                cmd.Parameters.AddWithValue("@Kol", Product_Count);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "Delivery"
        public static void Delivery_Update(int id_Delivery, int count, string Invoice_Num, string Delivery_Date, string Delivery_Time)
        {
            spConfiguration("Upd_Post");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Postavka", id_Delivery);
                cmd.Parameters.AddWithValue("@NP", Invoice_Num);
                cmd.Parameters.AddWithValue("@DP", Delivery_Date);
                cmd.Parameters.AddWithValue("@NT", Delivery_Time);
                cmd.Parameters.AddWithValue("@kol", count);
                DBConnect.sql.Open();
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "Delivery"
        public static void Delivery_Delete(int ID)
        {
            spConfiguration("Del_Postavka");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Postavka", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }
  
        //Вызов процедуры Добавления в таблицу "Employee"
        public static void Employee_Insert(string Surn_Employee, string Name_Employee, string Midn_Employee, string Mob_Num_Employee,
                string Employee_Contr_Num, string Num_Pass, string Serie_Pass, string City_Live_Employee, int Employee_Type_Id)
        {
            spConfiguration("Sotr_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Fam", Surn_Employee);
                cmd.Parameters.AddWithValue("@Name", Name_Employee);
                cmd.Parameters.AddWithValue("@Otch", Midn_Employee);
                cmd.Parameters.AddWithValue("@Tel", Mob_Num_Employee);
                cmd.Parameters.AddWithValue("@Nom_Trud_Dogovor", Employee_Contr_Num);
                cmd.Parameters.AddWithValue("@Nom_Pass", Num_Pass);
                cmd.Parameters.AddWithValue("@Serya_Pass", Serie_Pass);
                cmd.Parameters.AddWithValue("@City", City_Live_Employee);
                cmd.Parameters.AddWithValue("@Dolj_ID", Employee_Type_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "Employee"
        public static void Employee_Update(int id_Employee, string Surn_Employee, string Name_Employee, string Midn_Employee, string Mob_Num_Employee,
                string Employee_Contr_Num, string Num_Pass, string Serie_Pass, string City_Live_Employee, int Employee_Type_Id)
        {
            spConfiguration("Upd_Sotr");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Sotr", id_Employee);
                cmd.Parameters.AddWithValue("@SE", Surn_Employee);
                cmd.Parameters.AddWithValue("@NE", Name_Employee);
                cmd.Parameters.AddWithValue("@ME", Midn_Employee);
                cmd.Parameters.AddWithValue("@MNE", Mob_Num_Employee);
                cmd.Parameters.AddWithValue("@ECN", Employee_Contr_Num);
                cmd.Parameters.AddWithValue("@NP", Num_Pass);
                cmd.Parameters.AddWithValue("@SP", Serie_Pass);
                cmd.Parameters.AddWithValue("@CLE", City_Live_Employee);
                cmd.Parameters.AddWithValue("@Dolj_ID", Employee_Type_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "Employee"
        public static void Employee_Delete(int ID)
        {
            spConfiguration("Del_Sotr");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Sotr", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры Добавления в таблицу "Employee_Position"
        public static void Employee_Position_Insert(int Employee_Id, int Position_Id)
        {
            spConfiguration("Dolj_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", Employee_Id);
                cmd.Parameters.AddWithValue("@Stavka", Position_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "Employee_Position"
        public static void Employee_Position_Update(int id_Employee_Position, int Employee_Id, int Position_Id)
        {
            spConfiguration("Upd_Dolj");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Dolj", id_Employee_Position);
                cmd.Parameters.AddWithValue("@Name", Employee_Id);
                cmd.Parameters.AddWithValue("@Stavka", Position_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "Employee_Position"
        public static void Employee_Position_Delete(int ID)
        {
            spConfiguration("Del_Dolj");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Dolj", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры Добавления в таблицу "Employee_Schedule_Work"
        public static void Employee_Schedule_Work_Insert(int Employee_Id, int Schedule_Work_Id)
        {
            spConfiguration("Graf_Rab_Sotr_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Sotr_ID", Employee_Id);
                cmd.Parameters.AddWithValue("@Graf_Rab_ID", Schedule_Work_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "Employee_Schedule_Work"
        public static void Employee_Schedule_Work_Update(int id_Employee_Schedule_Work, int Employee_Id, int Schedule_Work_Id)
        {
            spConfiguration("Upd_Graf_Rab_Sotr");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Graf_Rab_Sotr", id_Employee_Schedule_Work);
                cmd.Parameters.AddWithValue("@EI", Employee_Id);
                cmd.Parameters.AddWithValue("@SWI", Schedule_Work_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "Employee_Schedule_Work"
        public static void Employee_Schedule_Work_Delete(int ID)
        {
            spConfiguration("Del_Graf_Rab_Sotr");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Graf_Rab_Sotr", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }
 
       
        
        //Вызов процедуры Добавления в таблицу "Salon"
        public static void Salon_Insert(string Address, string License_Num, string Graf_Rab,
                string Salon_Mob_Num)
        {
            spConfiguration("Salon_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Nom_Lic", License_Num);
                cmd.Parameters.AddWithValue("@Graf_Rab", Graf_Rab);
                cmd.Parameters.AddWithValue("@Nom_Tel", Salon_Mob_Num);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "Salon"
        public static void Salon_Update(int id_Salon, string Address, string License_Num, string Schedule_Work,
                string Salon_Mob_Num)
        {
            spConfiguration("Upd_Salon");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Salon", id_Salon);
                cmd.Parameters.AddWithValue("@Adrs", Address);
                cmd.Parameters.AddWithValue("@LN", License_Num);
                cmd.Parameters.AddWithValue("@SW", Schedule_Work);
                cmd.Parameters.AddWithValue("@Tel", Salon_Mob_Num);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "Salon"
        public static void Salon_Delete(int ID)
        {
            spConfiguration("Del_Salon");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Salon", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        

        //Вызов процедуры Добавления в таблицу "Номенклатура"
        public static void Nomen_Insert(float Product_Price, int Store_Id, bool Usluga)
        {
            spConfiguration("Nomen_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Cena", Product_Price);
                cmd.Parameters.AddWithValue("@Sklad_Id", Store_Id);
                cmd.Parameters.AddWithValue("@Usluga", Usluga);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        public static void Nomen_Update(int id_Nomen, float Product_Price, int Store_Id, bool Usluga)
        {
            spConfiguration("Upd_Nomen");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Nomen", id_Nomen);
                cmd.Parameters.AddWithValue("@Cena", Product_Price);
                cmd.Parameters.AddWithValue("@SI", Store_Id);
                cmd.Parameters.AddWithValue("@Usluga", Usluga);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "Nomen"
        public static void Nomen_Delete(int ID)
        {
            spConfiguration("Del_Nomen");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Nomen", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }
       
       
        //Вызов процедуры Добавления в таблицу "Role"
        public static void Role_Insert(string Role_Name, bool Client, bool Booking, bool Salon, bool Nomen_Chek, bool Nomen
            , bool Check, bool Schedule_Work_Employee, bool Store, bool Employee, bool Schedule_Work
            , bool Delivery, bool Employee_Position)
        {
            spConfiguration("Role_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", Role_Name);
                cmd.Parameters.AddWithValue("@Klient", Client);
                cmd.Parameters.AddWithValue("@Salon", Salon);
                cmd.Parameters.AddWithValue("@Nomen_Chek", Nomen_Chek);
                cmd.Parameters.AddWithValue("@Nomen", Nomen);
                cmd.Parameters.AddWithValue("@Check", Check);
                cmd.Parameters.AddWithValue("@Graf_Rab_Sotr", Schedule_Work_Employee);
                cmd.Parameters.AddWithValue("@Sklad", Store);
                cmd.Parameters.AddWithValue("@Sotr", Employee);
                cmd.Parameters.AddWithValue("@Graf_Rab", Schedule_Work);
                cmd.Parameters.AddWithValue("@Postavka", Delivery);
                cmd.Parameters.AddWithValue("@Dolj", Employee_Position);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "Role"
        public static void Role_Update(int id_Role, string Role_Name, bool Client,  bool Salon, 
             bool Nomen_check,  bool Nomen
            , bool Check, bool Schedule_Work_Employee, bool Store, bool Employee, bool Schedule_Work
            , bool Delivery)
        {
            spConfiguration("Upd_Role");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_Role", id_Role);
                cmd.Parameters.AddWithValue("@Role_Name", Role_Name);
                cmd.Parameters.AddWithValue("@CL", Client);
                cmd.Parameters.AddWithValue("@Salon", Salon);
                cmd.Parameters.AddWithValue("@NC", Nomen_check);
                cmd.Parameters.AddWithValue("@Nomen", Nomen);
                cmd.Parameters.AddWithValue("@CHCK", Check);
                cmd.Parameters.AddWithValue("@GRS", Schedule_Work_Employee);
                cmd.Parameters.AddWithValue("@StR", Store);
                cmd.Parameters.AddWithValue("@Sotr", Employee);
                cmd.Parameters.AddWithValue("@GR", Schedule_Work);
                cmd.Parameters.AddWithValue("@Post", Delivery);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "Role"
        public static void Role_Delete(int ID)
        {
            spConfiguration("Del_Role");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Role", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }
 
        //Вызов процедуры Добавления в таблицу "Schedule_Work"
        public static void Schedule_Work_Insert(string Time_Work, string Week_Day)
        {
            spConfiguration("Graf_Rab_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Time", Time_Work);
                cmd.Parameters.AddWithValue("@Day", Week_Day);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "Schedule_Work"
        public static void Schedule_Work_Update(int id_Schedule_Work, string Time_Work, string Week_Day)
        {
            spConfiguration("Upd_Graf_Rab");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Graf_Rab", id_Schedule_Work);
                cmd.Parameters.AddWithValue("@TW", Time_Work);
                cmd.Parameters.AddWithValue("@WD", Week_Day);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "Schedule_Work"
        public static void Schedule_Work_Delete(int ID)
        {
            spConfiguration("Del_Graf_Rab");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Graf_Rab", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры Добавления в таблицу "store"
        public static void store_Insert(string Product_Name, int Product_Count,  int Delivery_Id)
        {
            spConfiguration("Sklad_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", Product_Name);
                cmd.Parameters.AddWithValue("@Kol", Product_Count);
                cmd.Parameters.AddWithValue("@Postavka_ID", Delivery_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "store"
        public static void store_Update(int id_store, string Product_Name, int Product_Count, string Expiration_Date, int Delivery_Id)
        {
            spConfiguration("Upd_Skald");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Skald", id_store);
                cmd.Parameters.AddWithValue("@PN", Product_Name);
                cmd.Parameters.AddWithValue("@Kol", Product_Count);
                cmd.Parameters.AddWithValue("@d", Expiration_Date);
                cmd.Parameters.AddWithValue("@Postavka", Delivery_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "store"
        public static void store_Delete(int ID)
        {
            spConfiguration("Del_Sklad");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Sklad", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }
        
        //__________________________________________________________________________________________________________
        //__________________________________________________________________________________________________________
        //Вызов процедуры Добавления в таблицу "User"
        public static void User_Insert(string Login, string Password, int Role_Id)
        {
            spConfiguration("User_Insert");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Login", Login);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Role_Id", Role_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры обновления данных в таблице "User"
        public static void User_Update(int id_User, string Login, string Password, int Role_Id)
        {
            spConfiguration("Upd_User");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_User", id_User);
                cmd.Parameters.AddWithValue("@Log", Login);
                cmd.Parameters.AddWithValue("@Pass", Password);
                cmd.Parameters.AddWithValue("@RI", Role_Id);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }

        //Вызов процедуры удаления данных в таблице "User"
        public static void User_Delete(int ID)
        {
            spConfiguration("Del_User");
            try
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_User", ID);
                DBConnect.sql.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBConnect.sql.Close();
            }
        }
    }
}
