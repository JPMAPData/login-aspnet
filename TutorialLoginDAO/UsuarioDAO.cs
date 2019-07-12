using MAPDataClassLib.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace TutorialLoginDAO
{
    public class UsuarioDAO : DAOBase<Usuario>
    {
        public bool GetByLoginSenha(string login, string senha)
        {
            //CriteriosPesquisa criterios = new CriteriosPesquisa();
            //criterios.AdicionarCriterioAND("login", Operadores.Igual, login);
            //criterios.AdicionarCriterioAND("senha", Operadores.Igual, senha);

            //List<Usuario> usuarios = GetListByCriteriosPesquisa(criterios);
            //if (usuarios == null)
            //    return null;
            //else
            //    return usuarios[0];

            string sql = "SELECT * FROM tbUsuario WHERE login=@login AND senha=@senha";

            object[] parms = { "@login", login, "@senha", senha };

            return Db.Read<Usuario>(sql, DB2Object, parms)!=null;
        }
    }
}
