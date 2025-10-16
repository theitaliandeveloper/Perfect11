using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Enum.Poison;

namespace Perfect11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void DarkMode(bool status)
        {
            if (status)
            {
                pages.Theme = ThemeStyle.Dark;
                welcomePage.Theme = ThemeStyle.Dark;
            }
            else
            {
                pages.Theme = ThemeStyle.Light;
                welcomePage.Theme = ThemeStyle.Light;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DarkMode(true);
        }
    }
}
