using System.Web.Mvc;
using System.Linq;
using Agiledw.SiSWeb.Dominio.Repositorio;
using Agiledw.SiSWeb.Dominio.Entidades;
using System.Web;

namespace Agiledw.SiSWeb.Web.Areas.Admin.Controllers
{
    public class AdministradoresController : Controller
    {
        private AdministradoresRepositorio _repositorio;
        //
        // GET: /Admin/Administrador/
        public ActionResult Index()
        {
            _repositorio = new AdministradoresRepositorio();
            var administradores = _repositorio.Administradores;
            return View(administradores);
        }

        //SELECIONAR ADMINISTRADOR PELO ID
        public ViewResult Alterar(int Id)//Nome da variável tem que ser o mesmo nome do Id da página Index
        {
            _repositorio = new AdministradoresRepositorio();
            Administrador administrador = _repositorio.Administradores.FirstOrDefault(a => a.Id == Id);
            return View(administrador);
        }

        //ALTERAR ADMINISTRADOR
        [HttpPost]
        public ActionResult Alterar(Administrador administrador, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    administrador.ImagemMimeType = image.ContentType;
                    administrador.Imagem = new byte[image.ContentLength];
                    image.InputStream.Read(administrador.Imagem, 0, image.ContentLength);
                }
                _repositorio = new AdministradoresRepositorio();
                _repositorio.Salvar(administrador);
                TempData["mensagem"] = string.Format("{0} Gravado com sucesso", administrador.Nome);
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        //OBTER IMAGEM
        public FileContentResult ObterImagem(int Id)
        {
            _repositorio = new AdministradoresRepositorio();
            Administrador admin = _repositorio.Administradores.FirstOrDefault(a => a.Id == Id);
            if(admin!=null)
            {
                return File(admin.Imagem, admin.ImagemMimeType);
            }
            return null;
        }

        //GRAVAR NOVO ADMINISTRADOR
        public ViewResult NovoAdministrador()
        {
            return View("Alterar", new Administrador());
        }

        //EXCLUIR ADMINISTRADOR
        [HttpPost]
        public JsonResult Excluir(int Id)
        {
            string mensagem = string.Empty;
            _repositorio = new AdministradoresRepositorio();
            Administrador admin = _repositorio.Excluir(Id);
            if (admin != null)
            {
                mensagem = string.Format("{0} excluído com sucesso", admin.Nome);
            }
            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }
    }
}