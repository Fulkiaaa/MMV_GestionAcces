using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Windows;
using System.Reflection.PortableExecutable;

namespace MMV_GestionBadge
{

    public interface IDataService
    {
        public List<Personne> GetPersonnes();
        public void DisplayMessage(string message);
        public List<Batiment> GetBatiments();
        /*  List<Personne> GetPersonnes();*/
    }

    public class DataServiceSQL : IDataService
    {
        private readonly SqlConnection _connexion;


        public DataServiceSQL()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            /*builder.UserID = "sa";
            builder.Password = "Info76240#";*/
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "MMV_GestionCSharp";
            _connexion = new SqlConnection(builder.ConnectionString);
        }

        public List<Personne> GetPersonnes()
        {
            String sqlPersonnes = "MMV_SELECTPersonne";

            List<Personne> values;
            _connexion.Open();
            using (SqlCommand command = new SqlCommand(sqlPersonnes, _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;

                /* command.Parameters.AddWithValue("nom", value);*/
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    values = reader.Cast<IDataRecord>().Select(r => new Personne
                    {
                        PER_ID = (Int16)reader["PER_ID"],
                        PER_NOM = (string)reader["PER_NOM"],
                        PER_PRENOM = (string)reader["PER_PRENOM"]
                    }).ToList();
                }
                _connexion.Close();
                return values;
            }
        }

        public List<Batiment> GetBatiments()
        {
            String sqlBatiments = "MMV_SELECTBatiment";

            List<Batiment> values;
            _connexion.Open();
            using (SqlCommand command = new SqlCommand(sqlBatiments, _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                /*Ligne à add si param à entrer command.Parameters.AddWithValue("nom", 12);*/

                command.CommandType = CommandType.StoredProcedure;
                /* command.Parameters.AddWithValue("nom", value);*/
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    values = reader.Cast<IDataRecord>().Select(r => new Batiment
                    { 
                            BAT_ID = (Int16)reader["BAT_ID"],
                            BAT_NOM = (string)reader["BAT_NOM"],
                            BAT_DESC = (string)reader["BAT_DESC"]

                        }).ToList();
                    }
                    _connexion.Close();
                    return values;
                }
            }

            public void DisplayMessage(string message)
            {
                MessageBox.Show(message);
            }
        }
    }