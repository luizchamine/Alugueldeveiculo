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
    public partial class FormLogin : Form
    {
        public bool Logou;
        public FormLogin()
        {
            InitializeComponent();
            Logou = false;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            BindingSource usuarioBindingSource = new BindingSource();
            usuarioBindingSource.DataSource = usuarioBLL.BuscarUsuarioPorNome(textBoxUsuario.Text);

            if (usuarioBindingSource.Count != 0)
            {

                string nome = ((DataRowView)usuarioBindingSource.Current).Row["Nome"].ToString();
                string senha = ((DataRowView)usuarioBindingSource.Current).Row["Senha"].ToString();


                if (nome == textBoxUsuario.Text && senha == textBoxSenha.Text)
                {
                    Logou = false;
                    Close();
                }
                else
                {
                    MessageBox.Show("dados inconscistentes!");
                    textBoxSenha.Text = "";
                    textBoxSenha.Focus();
                }

            }
            else
            {
                MessageBox.Show("sem usuários no sistema!");
                textBoxSenha.Text = "";
                textBoxSenha.Focus();

            }
        }
    }
}
