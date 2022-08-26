using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TarefaBLL
    {
        public Tarefa Inserir(Tarefa _tarefa)
        {
            TarefaDAL tarefaDAL = new TarefaDAL();
            return tarefaDAL.Inserir(_tarefa);
        }
        public DataTable Buscar(string _filtro)
        {
            TarefaDAL tarefaDAL = new TarefaDAL();
            return tarefaDAL.Buscar(_filtro);
        }
        public void Excluir(int _id)
        {
            TarefaDAL tarefaDAL = new TarefaDAL();
            tarefaDAL.Excluir(_id);
        }

    }
}
