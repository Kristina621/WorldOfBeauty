using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WorldOfBeauty
{
    class DB
    {
        private static string pc = "localhost";
        private static string cat = "Salon";
        private static string ui = "sa";
        private static string Pass = "123";
        public static SqlConnection sql = new SqlConnection("Data Source = " + pc + "; Initial Catalog = " + cat + ";" +
             "Persist Security Info = true; User ID = " + ui + "; Password = \"" + Pass + "\""); //строка подключения

        public static DataTable dtCheck = new DataTable();
        public static DataTable dtDoljnost = new DataTable();
        public static DataTable dtKlient = new DataTable();
        public static DataTable dtNomen = new DataTable();
        public static DataTable dtUser = new DataTable();
        public static DataTable dtSklad = new DataTable();
        public static DataTable dtSotr = new DataTable();
        public static DataTable dtPostavka = new DataTable();

        public static DataTable dtGrafRab = new DataTable();
        public static DataTable dtGrafRabSotr = new DataTable();
        public static DataTable dtNomenCheck = new DataTable();

        public static DataTable dtRole = new DataTable();
        public static DataTable dtSalon = new DataTable();
        public static string qrKlient = "SELECT [id_Klient] as 'ID' ,[Name] as 'Имя' ,[Fam] as 'Фамилия' ,[Otch] as 'Отчество' FROM [dbo].[Klient]",
             qrCheck = "SELECT [id_Check] as 'ID' ,[Nom_Check] as 'Номер' ,[Data] as 'Дата' ,[Time] as 'Время' ,[Summ] as 'Сумма' ,[Sotr_Id] as 'ID сотрудника' ,[Salon_Id] as 'ID Салона'  ,[Klient_Id] as 'ID Клиента' FROM [dbo].[Check]",
             qrDoljnost = "SELECT [id_Dolj] as 'ID' ,[Name] as 'Название' ,[Stavka] as 'Ставка' FROM [dbo].[Doljnost]",
             qrUser = "SELECT [id_User] as 'ID' ,[Login] as 'Логин' ,[Password] as 'Пароль' ,[Role_Id] as 'ID роли' FROM [dbo].[User]",
             qrSklad = "SELECT [id_Sklad] as 'ID' ,[Name] as 'Название' ,[Kol] as 'Количество' ,[Postavka_Id] as 'ID поставки' FROM [dbo].[Sklad]",
             qrSotr = "SELECT [id_Sotr] as 'Id' ,[Fam] as 'Фамилия' ,[Name] as 'Имя' ,[Otch] as 'Отчество' ,[Tel] as 'Телефон' ,[Nom_Trud_Dogovor] as 'Номер трудового договора' ,[Nom_Pass] as 'Номер паспорта' ,[Serya_Pass] as 'Серия паспорта' ,[City] as 'город' ,[Dolj_ID] as 'Id должности' FROM [dbo].[Sotr]",
            qrPostavka = "SELECT [id_Postavka] as 'ID' ,[Nom_Naklad] as 'Номер накладной' ,[Data_Post] as 'Дата поставки' ,[Name_Tov] as 'Название товара' ,[Kol] as 'Количество' FROM [dbo].[Postavka]",
            qrNomen = "SELECT [id_Nomen] as 'ID' ,[Cena] as 'Цена' ,[Sklad_Id] as 'ID склада' ,[Usluga] as 'Услуга' FROM [dbo].[Nomen]",
            qrGrafRab = "SELECT [id_Graf_Rab] as 'ID' ,[Time] as 'Время' ,[Day] as 'День' FROM [dbo].[Graf_Rab]",
            qrGrafRabSotr = "SELECT [id_Graf_Rab_Sotr] as 'ID' ,[Sotr_Id] as 'ID сотрудника' ,[Graf_Rab_Id] as ' Id Графика работы' FROM [dbo].[Graf_Rab_Sotr]",
            qrNomenCheck = "SELECT [id_Nomen_Check] as 'ID' ,[Nomen_Id] as 'ID Номенклатуры' ,[Check_Id] as 'ID Чека' FROM [dbo].[Nomen_Check]",
            qrRole = "SELECT [id_Role] as 'ID' ,[Name] as 'Название' ,[Klient] as 'Клиенты' ,[Salon] as 'Салон' ,[Nomen_Chek] as 'Номенклатура чека' ,[Nomen] as 'Номенклатура' ,[Chek] as 'Чеки' ,[Graf_Rab_Sotr] as 'Графики работы сотрудников' ,[Sklad] as 'Склад' ,[Sotr] as 'Сотрудники' ,[Graf_Rab] as 'Графики работы' ,[Postavka] as 'Поставки' ,[Dolj] as 'Должности' FROM [dbo].[Role]",
            qrSalon = "SELECT [id_Salon] as 'ID' ,[Address] as 'Адрес' ,[Nom_Lic] as 'Номер лицензии' ,[Graf_Rab] as 'График работы' ,[Nom_Tel] as 'Номер телефона' FROM [dbo].[Salon]";
        
        public static BindingSource bsSklad = new BindingSource();
        public static BindingSource bsPostavka = new BindingSource();
        public static BindingSource bsDoljnost = new BindingSource();
        public static BindingSource bsNomen = new BindingSource();
        public static BindingSource bsKlient = new BindingSource();
        public static BindingSource bsSotr = new BindingSource();
        public static BindingSource bsCheck = new BindingSource();
        public static BindingSource bsUser = new BindingSource();
        public static BindingSource bsGrafRab = new BindingSource();
        public static BindingSource bsGrafRabSotr = new BindingSource();
        public static BindingSource bsNomenCheck = new BindingSource();
        public static BindingSource bsRole = new BindingSource();
        public static BindingSource bsSalon = new BindingSource();

        public static SqlDataAdapter daSklad = new SqlDataAdapter();
        public static SqlDataAdapter daPostavka = new SqlDataAdapter();
        public static SqlDataAdapter daDoljnost = new SqlDataAdapter();
        public static SqlDataAdapter daNomen = new SqlDataAdapter();
        public static SqlDataAdapter daKlient = new SqlDataAdapter();
        public static SqlDataAdapter daSotr = new SqlDataAdapter();
        public static SqlDataAdapter daCheck = new SqlDataAdapter();
        public static SqlDataAdapter daUser = new SqlDataAdapter();
        public static SqlDataAdapter daGrafRab = new SqlDataAdapter();
        public static SqlDataAdapter daGrafRabSotr = new SqlDataAdapter();
        public static SqlDataAdapter daNomenCheck = new SqlDataAdapter();
        public static SqlDataAdapter daRole = new SqlDataAdapter();
        public static SqlDataAdapter daSalon = new SqlDataAdapter();
        private static void FillDataTable(String query, DataTable table)
        {
            sql.Open();
            SqlCommand command = new SqlCommand(query, sql);
            SqlDataReader reader = command.ExecuteReader();
            table.Clear();
            table.Load(reader);
            reader.Close();
            sql.Close();
        }

        private static BindingSource BindSource(string query, DataTable dt)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, sql);
            da.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            return bSource;
        }

        public static void UpdateSkladAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daSklad);
                daSklad.SelectCommand = new SqlCommand(qrSklad, sql);
                daSklad.Update(dtSklad);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }
        public static void UpdateKlientAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daKlient);
                daKlient.SelectCommand = new SqlCommand(qrKlient, sql);
                daKlient.Update(dtKlient);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }

        public static void UpdateCheckAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daCheck);
                daCheck.SelectCommand = new SqlCommand(qrCheck, sql);
                daCheck.Update(dtCheck);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }
        public static void UpdateUserAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daUser);
                daUser.SelectCommand = new SqlCommand(qrUser, sql);
                daUser.Update(dtUser);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }
        public static void UpdateSotrAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daSotr);
                daSotr.SelectCommand = new SqlCommand(qrSotr, sql);
                daSotr.Update(dtSotr);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }
        public static void UpdatePostavkaAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daPostavka);
                daPostavka.SelectCommand = new SqlCommand(qrPostavka, sql);
                daPostavka.Update(dtPostavka);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }
        public static void UpdateDoljnostAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daDoljnost);
                daDoljnost.SelectCommand = new SqlCommand(qrDoljnost, sql);
                daDoljnost.Update(dtDoljnost);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }
        public static void UpdateNomenAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daNomen);
                daNomen.SelectCommand = new SqlCommand(qrNomen, sql);
                daNomen.Update(dtNomen);
                FillTableBinding();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }

        public static void UpdateGrafRabAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daSklad);
                daSklad.SelectCommand = new SqlCommand(qrSklad, sql);
                daSklad.Update(dtSklad);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }
        public static void UpdateGrafRabSotrAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daSklad);
                daSklad.SelectCommand = new SqlCommand(qrSklad, sql);
                daSklad.Update(dtSklad);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }
        public static void UpdateNomenCheckAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daSklad);
                daSklad.SelectCommand = new SqlCommand(qrSklad, sql);
                daSklad.Update(dtSklad);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }
        public static void UpdateRoleAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daSklad);
                daSklad.SelectCommand = new SqlCommand(qrSklad, sql);
                daSklad.Update(dtSklad);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }
        public static void UpdateSalonAdapter()
        {
            try
            {
                SqlCommandBuilder cBuilder = new SqlCommandBuilder(daSklad);
                daSklad.SelectCommand = new SqlCommand(qrSklad, sql);
                daSklad.Update(dtSklad);
                FillTableBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля валидны!!!\n\rПерепроверьте!\n\r" + ex.Message.ToString());
            }
        }


        public static void ConnectStringEdit(string IP, string Password, string UserName, string Catalog)
        {
            cat = Catalog;
            ui = UserName;
            Pass = Password;
            pc = IP;
        }


        public static void FillTableBinding()
        {
            bsSklad = BindSource(qrSklad, dtSklad);

            bsKlient = BindSource(qrKlient, dtKlient);

            bsCheck = BindSource(qrCheck, dtCheck);

            bsDoljnost = BindSource(qrDoljnost, dtDoljnost);

            bsSotr = BindSource(qrSotr, dtSotr);

            bsUser = BindSource(qrUser, dtUser);

            bsNomen = BindSource(qrNomen, dtNomen);

            bsPostavka = BindSource(qrPostavka, dtPostavka);

            bsGrafRab = BindSource(qrGrafRab, dtGrafRab);

            bsGrafRabSotr = BindSource(qrGrafRabSotr, dtGrafRabSotr);

            bsNomenCheck = BindSource(qrNomenCheck, dtNomenCheck);

            bsRole = BindSource(qrRole, dtRole);

            bsSalon = BindSource(qrSalon, dtSalon);

            FillDataTable(qrCheck, dtCheck);

            FillDataTable(qrKlient, dtKlient);

            FillDataTable(qrSklad, dtSklad);

            FillDataTable(qrSotr, dtSotr);

            FillDataTable(qrDoljnost, dtDoljnost);

            FillDataTable(qrNomen, dtNomen);

            FillDataTable(qrPostavka, dtPostavka);

            FillDataTable(qrUser, dtUser);

            FillDataTable(qrGrafRab, dtGrafRab);

            FillDataTable(qrGrafRabSotr, dtGrafRabSotr);

            FillDataTable(qrNomenCheck, dtNomenCheck);

            FillDataTable(qrRole, dtRole);

            FillDataTable(qrSalon, dtSalon);
        }
    }
}