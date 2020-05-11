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
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();

            Registr.Registry_Get();//получение значчений из рееста
            if (Registr.SE == "1")//если запоминание пароля работает
            {
                tbLogin.Text = Registr.UI;//заполнение логина и пароля
                tbPass.Text = Registr.PW;
                checkBox1.Checked = true;
            }
            else
                checkBox1.Checked = false;
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

        private async void btnAuth_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == String.Empty || tbPass.Text == String.Empty) {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }
            btnAuth.Enabled = false;
            await Task.Run(() => Authoriz.Auth(tbLogin.Text, tbPass.Text));
            btnAuth.Enabled = true;
            if (Authoriz.vhod)
            {
                string se = (bool)checkBox1.Checked ? "1" : "0";
                Registr.Registry_Set(tbLogin.Text, tbPass.Text, se);
                this.Hide();
                main main = new main();
                main.Show();
            }
            else
                MessageBox.Show("Ошибка авторизации!");

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Hide();
        }
    }
}
