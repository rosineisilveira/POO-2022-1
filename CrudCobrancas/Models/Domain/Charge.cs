

namespace CrudCobrancas.Models.Domain

{
    public class Charge
    {
        public Charge(){}
       

        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVenc { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataPag  { get; set; }
       
        public Client Client  { get; set; }
        
    }
}