namespace PacientesApi.Connection
{
    public class conexionbd
    {
        private string connectionString= string.Empty;

        public conexionbd()
        {
            //Sentencia sql para traer los datos de la BD
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = builder.GetSection("ConnectionStrings:conexion").Value;
        }
        //devolvemos la cadena ConnectionString
        public string cadenaSql() 
        { 
            return connectionString; 
        }  
    }
}
