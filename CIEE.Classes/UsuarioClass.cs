using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIEE.Classes
{
    public class UsuarioClass
    {
        private int id_usuario;
        private string nome;
        private string usuario;
        private string senha;

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
