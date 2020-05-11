using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfBeauty
{
    public partial class Reg : Form
    {
        public Reg()
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

        private void btnAuth_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == String.Empty || tbPass.Text == String.Empty)
                lblErr.Text = "Не все поля заполнены!";
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbPass.Text != tbPass2.Text)
                    MessageBox.Show("Пароли не совпадают");
                string tel;
                tel = string.Empty;
                await Task.Run(() => Registration.RegNewClient(tbLogin.Text, tbPass.Text, tbPass2.Text, tbName.Text, tbFam.Text, tbOtch.Text, tel));
                if (Registration.ok)
                {
                    MessageBox.Show(Registration.error, Registration.head);
                    Auth auth = new Auth();
                    auth.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(Registration.error, Registration.head);
                }
            }
            catch (Exception ex) {

                MessageBox.Show("Ошибка регистрации");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
