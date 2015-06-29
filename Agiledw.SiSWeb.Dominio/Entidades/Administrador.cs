using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agiledw.SiSWeb.Dominio.Entidades
{
    [Table("Administrador")]
    public class Administrador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Digite o nome completo")]
        [Display(Name="Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Digite o E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [Display(Name="E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage="Digite a senha")]
        [DataType(DataType.Password)]
        [Display(Name="Senha")]
        public string Senha { get; set; }

        public DateTime UltimoAcesso { get; set; }
        
        [Required(ErrorMessage="Selecione o tipo")]
        public int Tipo { get; set; }

        public byte[] Imagem { get; set; }

        public string ImagemMimeType { get; set; }

    }
}
