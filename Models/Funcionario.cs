

namespace ProjKronos.Models
{ 
    public class Funcionario
    {
       
        public int Id { get; set; }

       
        public string? NomeFuncionario { get; set; }

      
        public string? email { get; set; }

      
        public string? telemovel { get; set; }

     
        public DateTime Data { get; set; } = DateTime.Now;

        public string? Descricao { get; set; }


    }

}