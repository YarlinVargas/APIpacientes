using Microsoft.AspNetCore.Mvc;
using PacientesApi.Connection;
using PacientesApi.Models;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace PacientesApi.Data
{
    public class PacienteData
    {
        //traemos la coneccion a la bd
        conexionbd cn= new conexionbd();

        //Metodo para insertar pacientes
        public async Task InsertarPaciente(PacienteModel paciente)
        {
            using(var sql= new SqlConnection(cn.cadenaSql()))
            {
                using (var store= new SqlCommand("insertarPacientes",sql))
                {
                    store.CommandType= CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("name", paciente.name);
                    store.Parameters.AddWithValue("lastName", paciente.lastName);
                    store.Parameters.AddWithValue("email", paciente.email);
                    store.Parameters.AddWithValue("type_document", paciente.type_document);
                    store.Parameters.AddWithValue("num_document", paciente.num_document);
                    store.Parameters.AddWithValue("phone_number", paciente.phone_number);
                    store.Parameters.AddWithValue("direccion", paciente.direccion);
                    store.Parameters.AddWithValue("department", paciente.department);
                    store.Parameters.AddWithValue("city", paciente.city);

                    await sql.OpenAsync();  
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para editar paciente
        public async Task EditarPacientes(PacienteModel paciente)
        {
            using(var sql= new SqlConnection(cn.cadenaSql()))
            {
                using(var store= new SqlCommand("editarPacientes", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("id",paciente.id);
                    store.Parameters.AddWithValue("name", paciente.name);
                    store.Parameters.AddWithValue("lastName", paciente.lastName);
                    store.Parameters.AddWithValue("email", paciente.email);
                    store.Parameters.AddWithValue("type_document", paciente.type_document);
                    store.Parameters.AddWithValue("num_document", paciente.num_document);
                    store.Parameters.AddWithValue("phone_number", paciente.phone_number);
                    store.Parameters.AddWithValue("direccion", paciente.direccion);
                    store.Parameters.AddWithValue("department", paciente.department);
                    store.Parameters.AddWithValue("city", paciente.city);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para eliminar paciente 
        public async Task EliminarPacientes(PacienteModel paciente)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("eliminarPacientes", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("id", paciente.id);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para mostrar lista pacientes
        public async Task<ActionResult<List<PacienteModel>>> MostrarPaciente()
        {
            var list= new List<PacienteModel>();

            using(var sql= new SqlConnection(cn.cadenaSql()))
            {
                using( var store = new SqlCommand("mostrarPacientes",sql))
                {
                    await sql.OpenAsync();  
                    store.CommandType = CommandType.StoredProcedure;
                    using( var item = await store.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var mpaciente= new PacienteModel();
                            mpaciente.id = (int)item["id"];
                            mpaciente.name = (string)item["name"];
                            mpaciente.lastName = (string)item["lastName"];
                            mpaciente.email = (string)item["email"];
                            mpaciente.type_document = (string)item["type_document"];
                            mpaciente.num_document = (string)item["num_document"];
                            mpaciente.phone_number = (string)item["phone_number"];
                            mpaciente.direccion = (string)item["direccion"];
                            mpaciente.department = (string)item["department"];
                            mpaciente.city = (string)item["city"];

                            list.Add(mpaciente);
                        }
                    }
                }
            }
            return list;
        }
    }
}
