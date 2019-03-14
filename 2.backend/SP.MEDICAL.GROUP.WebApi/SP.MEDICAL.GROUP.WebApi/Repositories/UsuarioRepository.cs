using Microsoft.EntityFrameworkCore;
using SP.MEDICAL.GROUP.WebApi.Domains;
using SP.MEDICAL.GROUP.WebApi.Interfaces;
using SP.MEDICAL.GROUP.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SP.MEDICAL.GROUP.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                Usuarios User = ctx.Usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
                User.Senha = null;
                return User;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }
    }
}