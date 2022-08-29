using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UILuvancar
{
    public partial class FormTarefa : Form
    {
        public FormTarefa()
        {
            InitializeComponent();
        }

        private void FormTarefa_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            using(FormLogin frm = new FormLogin())
            {
                frm.ShowDialog();
                if (!frm.Logou)
                {
                    Application.Exit();
                }
            }

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            TarefaBLL tarefaBLL = new TarefaBLL();
            tarefaBindingSource.DataSource = tarefaBLL.Buscar(textbox)
        }
    }
}
