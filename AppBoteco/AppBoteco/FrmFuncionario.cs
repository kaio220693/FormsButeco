using AppBoteco.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBoteco.Classes;

namespace AppBoteco
{
    public partial class FrmFuncionario : Form
    {
        public FrmFuncionario()
        {
            InitializeComponent();
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            List<Funcionario> funcionarios = funcionario.listaFuncionario();
            dgvFuncionario.DataSource = funcionarios;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.ActiveControl = txtNome;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || mtxtCpf.Text == "" || textEndereco.Text == "" || textBairro.Text == "" || textCidade.Text == "" || mtxtCelular.Text == "" || mtxtCEP.Text == "" || textCargo.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Funcionario funcionario = new Funcionario();
                if (funcionario.RegistroRepetido(mtxtCpf.Text) == true)
                {
                    MessageBox.Show("Cliente já existe em nossa base de dados!", "Cliente Repetido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNome.Text = "";
                    mtxtCpf.Text = "";
                    mtxtCelular.Text = "";
                    mtxtCEP.Text = "";
                    textEndereco.Text = "";
                    textBairro.Text = "";
                    textCidade.Text = "";
                    textCargo.Text = "";
                    return;
                }
                else
                {
                    funcionario.Inserir(txtNome.Text, mtxtCpf.Text, textEndereco.Text, textBairro.Text, textCidade.Text, mtxtCelular.Text, mtxtCEP.Text, textCargo.Text);
                    MessageBox.Show("Funcionario inserido com sucesso!", "Inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<Funcionario> funcionarios = funcionario.listaFuncionario();
                    dgvFuncionario.DataSource = funcionarios;
                    txtNome.Text = "";
                    mtxtCpf.Text = "";
                    mtxtCelular.Text = "";
                    mtxtCEP.Text = "";
                    textEndereco.Text = "";
                    textBairro.Text = "";
                    textCidade.Text = "";
                    textCargo.Text = "";
                    this.txtNome.Focus();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro - Inserção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Por favor, digite um ID para localizar!", "Sem ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                int id = Convert.ToInt32(txtId.Text.Trim());
                Funcionario funcionario = new Funcionario();
                funcionario.Localizar(id);
                txtNome.Text = funcionario.nome;
                mtxtCelular.Text = funcionario.celular;
                mtxtCpf.Text = funcionario.cpf;
                mtxtCEP.Text= funcionario.cep;
                textEndereco.Text = funcionario.endereco;
                textBairro.Text= funcionario.bairro;
                textCidade.Text = funcionario.cidade;
                textCargo.Text = funcionario.cargo;
                if (txtNome.Text != null)
                {
                    btnEditar.Enabled = true;
                    btnExcluir.Enabled = true;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro - Inserção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text.Trim());
                Funcionario funcionario = new Funcionario();
                funcionario.Atualizar(id, txtNome.Text, mtxtCpf.Text, textEndereco.Text, textBairro.Text, textCidade.Text, mtxtCelular.Text, mtxtCEP.Text, textCargo.Text);
                MessageBox.Show("Funcionario atualizado com sucesso!", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Funcionario> funcionarios = funcionario.listaFuncionario();
                dgvFuncionario.DataSource = funcionarios;
                txtId.Text = "";
                txtNome.Text = "";
                mtxtCelular.Text = "";
                mtxtCpf.Text = "";
                textEndereco.Text = "";
                textBairro.Text = "";
                textCidade.Text = "";
                textCargo.Text = "";
                this.ActiveControl = txtNome;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro - Inserção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text.Trim());
                Funcionario funcionario = new Funcionario();
                funcionario.Excluir(id);
                MessageBox.Show("Funcionario Excluido com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Funcionario>funcionarios = funcionario.listaFuncionario();
                dgvFuncionario.DataSource = funcionarios;
                txtId.Text = "";
                txtNome.Text = "";
                mtxtCelular.Text = "";
                mtxtCpf.Text = "";
                textEndereco.Text = "";
                textBairro.Text = "";
                textCidade.Text = "";
                textCargo.Text = "";
                this.ActiveControl = txtNome;
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message, "Erro - Inserção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvFuncionario.Rows[e.RowIndex];
                this.dgvFuncionario.Rows[e.RowIndex].Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                mtxtCpf.Text = row.Cells[2].Value.ToString();
                mtxtCelular.Text = row.Cells[3].Value.ToString();
                textEndereco.Text = row.Cells[4].Value.ToString();
                textBairro.Text = row.Cells[5].Value.ToString();
                textCidade.Text = row.Cells[6].Value.ToString();
                textCargo.Text = row.Cells[7].Value.ToString();
            }
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }
    }
}
