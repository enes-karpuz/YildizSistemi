using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YildizSistemi.DataAccessLayer.Model;

namespace YildizSistemi.DataAccessLayer
{
    public class EGezegen
    {
        //TODO : Gezegen id'deki D küçük olacak.
        public SqlConnection sqlConnection { get; set; }
        public SqlCommand sqlCommand { get; set; }
        Database database { get; set; }
        
        public string connetionString = "Data Source=ENES-THINKPAD;Initial Catalog=YildizSistemleri;Integrated Security=True";
        
        public EGezegen()
        {
            database = new Database();
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connetionString;
        }

        public List<Gezegen> GetirGezegen()
        {
            SqlCommand sqlCommand = new SqlCommand("GetirGezegen", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dtGezegen = new DataTable();
            database.OpenConnetion(sqlConnection);
            sqlDataAdapter.Fill(dtGezegen);

            List<Gezegen> gezegenListesi = new List<Gezegen>();
            foreach (DataRow satir in dtGezegen.Rows)
            {
                gezegenListesi.Add(new Gezegen()
                {
                    Id = Convert.ToInt32(satir["Id"]),
                    Isim = satir["Isim"].ToString(),
                    YariCap = Convert.ToInt32(satir["YariCap"]),
                    YildizaUzaklik = Convert.ToInt32(satir["YildizaUzaklik"]),
                    YorungeEgikligi = Convert.ToInt32(satir["YorungeEgikligi"]),
                    UyduSayisi = Convert.ToInt32(satir["UyduSayisi"]),
                    Sicaklik = Convert.ToInt32(satir["Sicaklik"])
                });
            }
            return gezegenListesi;
        }

        public Gezegen OkuGezegen(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("OkuGezegen", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@p_GezegenID", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dtGezegen = new DataTable();
            database.OpenConnetion(sqlConnection);
            sqlDataAdapter.Fill(dtGezegen);

            Gezegen okunanGezegen = new Gezegen()
            {
                Id = Convert.ToInt32(dtGezegen.Rows[0]["Id"]),
                Isim = dtGezegen.Rows[0]["Isim"].ToString(),
                YariCap = Convert.ToInt32(dtGezegen.Rows[0]["YariCap"]),
                YildizaUzaklik = Convert.ToInt32(dtGezegen.Rows[0]["YildizaUzaklik"]),
                YorungeEgikligi = Convert.ToInt32(dtGezegen.Rows[0]["YorungeEgikligi"]),
                UyduSayisi = Convert.ToInt32(dtGezegen.Rows[0]["UyduSayisi"]),
                Sicaklik = Convert.ToInt32(dtGezegen.Rows[0]["Sicaklik"])
            };
            return okunanGezegen;
        }

        //TODO : Return id olacak.
        public bool EkleGezegen(Gezegen gezegen)
        {
            SqlCommand sqlCommand = new SqlCommand("EkleGezegen", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@p_GezegenIsim", gezegen.Isim);
            sqlCommand.Parameters.AddWithValue("@p_GezegenYariCap", gezegen.YariCap);
            sqlCommand.Parameters.AddWithValue("@p_GezegenYildizaUzaklik", gezegen.YildizaUzaklik);
            sqlCommand.Parameters.AddWithValue("@p_GezegenYorungeEgikligi", gezegen.YorungeEgikligi);
            sqlCommand.Parameters.AddWithValue("@p_GezegenUyduSayisi", gezegen.UyduSayisi);
            sqlCommand.Parameters.AddWithValue("@p_GezegenSicaklik", gezegen.Sicaklik);
            database.OpenConnetion(sqlConnection);
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                sqlConnection.Close();
                return true;
            }
            return false;
        }


        public bool GuncelleGezegen(Gezegen gezegen)
        {
            SqlCommand sqlCommand = new SqlCommand("GuncelleGezegen", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@p_Id", gezegen.Id);
            sqlCommand.Parameters.AddWithValue("@p_GezegenIsim", gezegen.Isim); // TODO : İsim düzelticektir.
            sqlCommand.Parameters.AddWithValue("@p_GezegenYariCap", gezegen.YariCap);
            sqlCommand.Parameters.AddWithValue("@p_GezegenYildizaUzaklik", gezegen.YildizaUzaklik);
            sqlCommand.Parameters.AddWithValue("@p_GezegenYorungeEgikligi", gezegen.YorungeEgikligi);
            sqlCommand.Parameters.AddWithValue("@p_GezegenUyduSayisi", gezegen.UyduSayisi);
            sqlCommand.Parameters.AddWithValue("@p_GezegenSicaklik", gezegen.Sicaklik);
            database.OpenConnetion(sqlConnection);
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                sqlConnection.Close();
                return true;
            }
            return false;
        }

        //TODO : Return id olacak.
        public bool SilGezegen(int Id)
        {
            SqlCommand sqlCommand = new SqlCommand("SilGezegen", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@p_GezegenID", Id);
            database.OpenConnetion(sqlConnection);
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                sqlConnection.Close();
                return true;
            }
            return false;
        }
    }
}
