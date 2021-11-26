using RubricaTelefonica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaTelefonica.Core.InterfaceRepositories.RepositoryADO
{
    public class RepositoryContattiADO : IRepositoryContatti
    {
        string connectionString =@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RubricaTelefonica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Contatto> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Contatti";

                SqlDataReader reader = command.ExecuteReader();

                List<Contatto> contatti = new List<Contatto>();

                while (reader.Read())
                {
                    var idC = (int)reader["Id"];
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    Contatto c = new Contatto();
                    c.IdContatto = idC;
                    c.Nome = nome;
                    c.Cognome = cognome;
                    contatti.Add(c);
                }
                connection.Close();

                return contatti;
            }
        }
    
        public Contatto Add(Contatto item)
        {
            throw new NotImplementedException();
        }

        public Esito Delete(Contatto cont)
        {
            throw new NotImplementedException();
        }

        

        public Contatto GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
