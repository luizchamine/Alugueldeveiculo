using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class TarefaDAL
    {
        public Tarefa Inserir(Tarefa _tarefa)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_inserirtarefa";

                SqlParameter pid = new SqlParameter("@Id",SqlDbType.Int);
                pid.Value = _tarefa.Id;
                cmd.Parameters.Add(pid);

                SqlParameter pid_Usuario = new SqlParameter("@Id_Usuario", SqlDbType.Int);
                pid_Usuario.Value = _tarefa.Id_Usuario;
                cmd.Parameters.Add(pid_Usuario);

                SqlParameter pdescricao = new SqlParameter("@Descricao", SqlDbType.VarChar);
                pdescricao.Value = _tarefa.Descricao;
                cmd.Parameters.Add(pdescricao);

                SqlParameter pestatus = new SqlParameter("@Estatus ", SqlDbType.VarChar);
                pestatus.Value = _tarefa.Estatus;
                cmd.Parameters.Add(pestatus);

                return _tarefa;
            }
            catch (SqlException ex)
            {
                throw new Exception("Sql Erro: "+ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable Buscar(string _filtro)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandText = "sp_buscartarefa";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pfiltro = new SqlParameter("@Filtro", SqlDbType.VarChar);
                pfiltro.Value = _filtro;

                da.SelectCommand.Parameters.Add(pfiltro);

                cn.Open();//abrir coneccao
                da.Fill(dt);//buscar para preencher o datatable

                //SqlCommand cmd = new SqlCommand();

                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Sql Erro: " + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }
        public bool Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_excluirtarefa";

                SqlParameter pid = new SqlParameter("@Id", SqlDbType.Int);
                pid.Value = _id;
                cmd.Parameters.Add(pid);

                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if(resultado != 1)
                {
                    throw new Exception("erro na exclusao do usuário: " + _id.ToString());
                }

                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception("Sql Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }
    }
}
