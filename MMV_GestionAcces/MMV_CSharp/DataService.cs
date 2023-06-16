using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MMV_CSharp
{
    public interface IDataService
    {
        ObservableCollection<Personne> GetPersonnes();
        ObservableCollection<Batiment> GetBatiments();
        public void UpdateBatiment(Batiment batiment);
        public void AddPersonne(Personne personne);
        public void UpdatePersonne(Personne personne);
        public void DeletePersonne(Personne personne);


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
        public ObservableCollection<Personne> GetPersonnes()
        {
            ObservableCollection<Personne> personnes = new ObservableCollection<Personne>();
            //String sqlPersonnes = "PS_GetPersonnes";
            _connexion.Open();
            using (SqlCommand command = new SqlCommand("PS_GetPersonnes", _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personnes.Add(new Personne()
                        {
                            PER_ID = (Int16)reader["PER_ID"],
                            PER_NOM = (string)reader["PER_NOM"],
                            PER_PRENOM = (string)reader["PER_PRENOM"],
                            PER_PHOTO = (string)reader["PER_PHOTO"],
                            HAB_NOM = (string)reader["HAB_NOM"]

                        });
                    }
                }
                _connexion.Close();
                return new ObservableCollection<Personne>(personnes);
            }
        }
        public void UpdateBatiment(int? id, Batiment batiment)
        {
            String sqlUpdateBatiment = "MMV_UpdateBatiment";
            _connexion.Open();
            using (SqlCommand command = new SqlCommand(sqlUpdateBatiment, _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BAT_ID", batiment.BAT_ID);
                command.Parameters.AddWithValue("@BAT_NOM", batiment.BAT_NOM);
                command.Parameters.AddWithValue("@BAT_DESC", batiment.BAT_DESC);
                var resultat = command.ExecuteScalar();
            }
            _connexion.Close();
            return;
        }

        public ObservableCollection<Batiment> GetBatiments()
        {
            ObservableCollection<Batiment> batiments = new ObservableCollection<Batiment>();
            _connexion.Open();
            using (SqlCommand command = new SqlCommand("MMV_SELECTBatiment", _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        batiments.Add(new Batiment()
                        {
                            BAT_ID = (Int16)reader["BAT_ID"],
                            BAT_NOM = (string)reader["BAT_NOM"],
                            BAT_DESC = (string)reader["BAT_DESC"]

                        });
                    }
                }
                _connexion.Close();
                return new ObservableCollection<Batiment>(batiments);
            }
        }

        public void AddPersonne(Personne personne)
        {
            String sqlInsertPersonne = "MMV_InsertPersonne";
            _connexion.Open();
            using (SqlCommand command = new SqlCommand(sqlInsertPersonne, _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PER_NOM", personne.PER_NOM);
                command.Parameters.AddWithValue("@PER_PRENOM", personne.PER_PRENOM);
                command.Parameters.AddWithValue("@PER_PHOTO", personne.PER_PHOTO);
                command.Parameters.AddWithValue("@HAB_ID", personne.HAB_ID);
                
                var resultat = command.ExecuteScalar();
            }
            _connexion.Close();
            return;
        }

        public void UpdatePersonne(Personne personne)
        {
            String sqlUpdatePersonne = "MMV_UpdatePersonne";
            _connexion.Open();
            using (SqlCommand command = new SqlCommand(sqlUpdatePersonne, _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PER_ID", personne.PER_ID);
                command.Parameters.AddWithValue("@PER_NOM", personne.PER_NOM);
                command.Parameters.AddWithValue("@PER_PRENOM", personne.PER_PRENOM);
                command.Parameters.AddWithValue("@HAB_ID", personne.HAB_ID);
                var resultat = command.ExecuteScalar();
            }
            _connexion.Close();
            return;
        }
        public void DeletePersonne(Personne personne)
        {
            String sqlUpdatePersonne = "MMV_DeletePersonne";
            _connexion.Open();
            using (SqlCommand command = new SqlCommand(sqlUpdatePersonne, _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PER_ID", personne.PER_ID);
                //command.Parameters.AddWithValue("@PER_NOM", personne.PER_NOM);
                //command.Parameters.AddWithValue("@PER_PRENOM", personne.PER_PRENOM);
                //command.Parameters.AddWithValue("@HAB_ID", personne.HAB_ID);
                var resultat = command.ExecuteScalar();
            }
            _connexion.Close();
            return;
        }

        public void UpdateBatiment(Batiment batiment)
        {
            String sqlUpdateBatiment = "MMV_UpdateBatiment";
            _connexion.Open();
            using (SqlCommand command = new SqlCommand(sqlUpdateBatiment, _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BAT_ID", batiment.BAT_ID);
                command.Parameters.AddWithValue("@BAT_NOM", batiment.BAT_NOM);
                command.Parameters.AddWithValue("@BAT_DESC", batiment.BAT_DESC);
                var resultat = command.ExecuteScalar();
            }
            _connexion.Close();
            return;
        }

        public ObservableCollection<Batiment> GetBatimentById()
        {
            ObservableCollection<Batiment> batiments = new ObservableCollection<Batiment>();
            _connexion.Open();
            using (SqlCommand command = new SqlCommand("MMV_GetBatimentById", _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        batiments.Add(new Batiment()
                        {
                            BAT_ID = (Int16)reader["BAT_ID"],
                            BAT_NOM = (string)reader["BAT_NOM"],
                            BAT_DESC = (string)reader["BAT_DESC"]

                        });
                    }
                }
                _connexion.Close();
                return new ObservableCollection<Batiment>(batiments);
            }
        }
    }
}