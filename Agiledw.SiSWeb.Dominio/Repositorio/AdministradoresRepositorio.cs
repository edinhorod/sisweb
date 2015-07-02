using Agiledw.SiSWeb.Dominio.Entidades;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Agiledw.SiSWeb.Dominio.Repositorio
{
    public class AdministradoresRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        //LISTAR TODOS OS ADMINISTRADORES
        public IEnumerable<Entidades.Administrador> Administradores
        {
            get { return _context.Administradores; }

        }

        //SALVAR/ALTERAR ADMINISTRDOR
        public void Salvar(Administrador administrador)
        {
            if (administrador.Id == 0)
            {
                _context.Administradores.Add(administrador);
            }
            else
            {
                Administrador admin = _context.Administradores.Find(administrador.Id);
                if (admin != null)
                {
                    admin.Nome = administrador.Nome;
                    admin.Email = administrador.Email;
                    admin.Senha = administrador.Senha;
                    admin.UltimoAcesso = administrador.UltimoAcesso;
                    admin.Tipo = administrador.Tipo;
                    admin.Imagem = administrador.Imagem;
                    admin.ImagemMimeType = administrador.ImagemMimeType;
                }
            }
            _context.SaveChanges();
        }

        //EXCLUIR ADMINISTRADOR
        public Administrador Excluir(int Id)
        {
            Administrador admin = _context.Administradores.Find(Id);
            if (admin != null)
            {
                _context.Administradores.Remove(admin);
                _context.SaveChanges();
            }
            return admin;
        }
    }
}
