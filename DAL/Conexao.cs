using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Conexao
    {
        public static string StringDeConexao
        {
            get 
            { 
                return @"user id = sa; initial catalog = luvancar; data source = cinzasso\meusqlexpress; password = 1707"; 
            }
        }
    }
}
