namespace ProjKronos.Models
{
    public class Utilizador
    {

        public int Id { get; set; }
        public string? NomeUtilizador { get; set; }
        public string? Senha { get; set; }
        public bool Administrador { get; set; }
        public bool Estado { get; set; }
    }
}
