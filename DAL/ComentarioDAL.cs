using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class ComentarioDAL
    {
        public Comentario Inserir(Comentario _comentario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_inserircomentario";

                SqlParameter pid = new SqlParameter("@Id", SqlDbType.Int);
                pid.Value = _comentario.Id;
                cmd.Parameters.Add(pid);

                SqlParameter pid_Usuario = new SqlParameter("@Id_Usuario", SqlDbType.Int);
                pid_Usuario.Value = _comentario.Id_Usuario;
                cmd.Parameters.Add(pid_Usuario);

                SqlParameter pid_Tarefa = new SqlParameter("@Id_Tarefa ", SqlDbType.Int);
                pid_Tarefa.Value = _comentario.Id_Tarefa;
                cmd.Parameters.Add(pid_Tarefa);

                SqlParameter pdescricao = new SqlParameter("@Descricao", SqlDbType.VarChar);
                pdescricao.Value = _comentario.Descricao;
                cmd.Parameters.Add(pdescricao);


                return _comentario;
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
        public DataTable Buscar(string _id_Tarefa)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandText = "sp_buscarcomentario";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pid_Tarefa = new SqlParameter("@Id_Tarefa", SqlDbType.Int);
                pid_Tarefa.Value = _id_Tarefa;

                da.SelectCommand.Parameters.Add(pid_Tarefa);

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
    }
