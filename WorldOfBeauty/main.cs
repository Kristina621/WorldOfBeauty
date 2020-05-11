using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfBeauty
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private Point mouseOffset;
        private bool isMouseDown = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                    SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y + 30);
                Location = mousePos;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void lblMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            createCheck CreateCheck = new createCheck();
            CreateCheck.Show();
            this.Hide();
        }
        int i = 0;
        private void CreateForm(string formName, BindingSource bindSource)
        {
            Form childForm = new Form();
            childForm.Width = 450;
            childForm.Height = 300;
            childForm.Text = formName;

            DataGridView dataGrid = new DataGridView();
            dataGrid.Parent = childForm;
            dataGrid.Top = 0;
            dataGrid.Left = 0;
            dataGrid.Width = 435;
            dataGrid.Height = 200;
            dataGrid.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            dataGrid.DataSource = bindSource;
            dataGrid.ColumnHeadersHeight = 50;
            dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGrid.SelectionChanged += new EventHandler(SelectCells);
            Button btnSave = new Button();
            btnSave.Parent = childForm;
            btnSave.Height = 30;
            btnSave.Width = 120;
            btnSave.Top = 220;
            btnSave.Left = 20;
            btnSave.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnSave.Text = "Сохранить";
            btnSave.Click += new EventHandler(SaveDataTable);

            Button btnHelp = new Button();
            btnHelp.Parent = childForm;
            btnHelp.Height = 30;
            btnHelp.Width = 120;
            btnHelp.Top = 220;
            btnHelp.Left = 295;
            btnHelp.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnHelp.Text = "Помощь?";
            btnHelp.Click += new EventHandler(help);


            childForm.Show();

           DB.FillTableBinding();
            if (i == 0)
            {
                i++;
                childForm.Close();
            }
               
        }

        private void help(object sender, EventArgs e) {
           MessageBox.Show("Правильное заполнение полей:\nПервичные ID выставляются автоматически.\nВсе ID должны быть числом.\nФормат телефона: +7(000)000-00-00\nФормат времени: 00:00\nФормат даты: 00.00.00", "Помощь");
        }
        private static DataGridViewSelectedRowCollection selCells;

        private void SelectCells(object sender, EventArgs e)
        {
            selCells = (sender as DataGridView).SelectedRows;
        }

        private void SaveDataTable(object sender, EventArgs e)
        {
            try
            {
                string tableName = (sender as Button).Parent.Text;
                switch (tableName)
                {
                    case "Чек":
                        DB.UpdateCheckAdapter();
                        break;
                    case "Должности":
                        DB.UpdateDoljnostAdapter();
                        break;
                    case "Клиенты":
                        DB.UpdateKlientAdapter();
                        break;
                    case "Номенклатура":
                        DB.UpdateNomenAdapter();
                        break;
                    case "Пользователи":
                        DB.UpdateUserAdapter();
                        break;
                    case "Склад":
                        DB.UpdateSkladAdapter();
                        break;
                    case "Сотрудники":
                        DB.UpdateSotrAdapter();
                        break;
                    case "Поставки":
                        DB.UpdateSotrAdapter();
                        break;
                    case "График работы":
                        DB.UpdateGrafRabAdapter();
                        break;
                    case "Графики работы сотрудников":
                        DB.UpdateGrafRabSotrAdapter();
                        break;
                    case "Салон":
                        DB.UpdateSotrAdapter();
                        break;
                    case "Роли":
                        DB.UpdateSotrAdapter();
                        break;
                    case "Номенклатура чеков":
                        DB.UpdateNomenCheckAdapter();
                        break;
                }
                DB.FillTableBinding();
            }
            catch (Exception ex) {
                MessageBox.Show("Не все поля заполнены должным образом!\n Убедитесть, что ID является числом, все поля заполнены и нет случайных значений");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateForm("Чек", DB.bsCheck);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateForm("Должности", DB.bsDoljnost);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateForm("Клиенты", DB.bsKlient);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CreateForm("Номенклатура", DB.bsNomen);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            CreateForm("Поставки", DB.bsPostavka);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            CreateForm("Склад", DB.bsSklad);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CreateForm("Сотрудники", DB.bsSotr);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CreateForm("Пользователи", DB.bsUser);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateForm("График работы", DB.bsGrafRab);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CreateForm("Графики работы сотрудников", DB.bsGrafRabSotr);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CreateForm("Салон", DB.bsSalon);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CreateForm("Роли", DB.bsRole);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateForm("Номенклатура чеков", DB.bsNomenCheck);
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке");
        }

        private void btnOpt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке");
        }

        private void aboutProg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("«World Of Beauty» – данные салоны известны на рынке с 2016 года."
                + " Оказывая услуги косметического ухода за кожей лица, рук, уходом за волосами и" +
                " высокому уровню MAKEUP’а компания непрерывно развивается и растет, из-за чего и нуждается " +
                "в автоматизации и переходе на новый уровень функционирования бизнеса.", "О программе");
        }

        private void AboutAvt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор программы является студентом Московского Приборостроительного техникума имени Г.В. Плеханова и создавал этот проект в учебных целях.", "Об авторе");
        }

        private void main_Load(object sender, EventArgs e)
        {
            CreateForm("Графики работы сотрудников", DB.bsGrafRabSotr);
        }
    }
}
