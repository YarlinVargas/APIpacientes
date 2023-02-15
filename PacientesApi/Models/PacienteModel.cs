namespace PacientesApi.Models
{
    public class PacienteModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string type_document { get; set; }
        public string num_document { get; set; }
        public string phone_number { get; set; }
        public string direccion { get; set;}
        public string department { get; set;}
        public string city { get; set; }
    }
}
