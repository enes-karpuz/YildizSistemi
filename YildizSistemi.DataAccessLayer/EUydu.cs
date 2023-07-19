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
    public class EUydu
    {
        public SqlConnection sqlConnection { get; set; }
        public SqlCommand sqlCommand { get; set; }
        public Database database { get; set; }
        public string connectionString = "Data Source=ENES-THINKPAD;Initial Catalog=YildizSistemleri;Integrated Security=True";
        public EUydu()
        {
            database = new Database();
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
        }
        public List<Uydu> GetirUydu()
        {
            sqlCommand = new SqlCommand("GetirUydu", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Uydu> uyduListesi = new List<Uydu>();
            foreach (DataRow satir in dt.Rows)
            {
                uyduListesi.Add(new Uydu()
                {
                    Isim = (satir["Isim"]).ToString(),
                    YariCap = Convert.ToInt32(satir["YariCap"].ToString()),
                    GezegenId = Convert.ToInt32(satir["GezegenID"].ToString())
                });
            }
            return uyduListesi;
        }

        public Uydu OkuUydu(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("OkuUydu", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@p_UyduID", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            database.OpenConnetion(sqlConnection);
            sqlDataAdapter.Fill(dt);

            Uydu okunanUydu = new Uydu()
            {
                Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                Isim = dt.Rows[0]["Isim"].ToString(),
                YariCap = Convert.ToInt32(dt.Rows[0]["YariCap"]),
                GezegenId = Convert.ToInt32(dt.Rows[0]["GezegenID"].ToString())
            };
            return okunanUydu;
        }
        public bool EkleUydu(Uydu uydu)
        {
            SqlCommand sqlCommand = new SqlCommand("EkleUydu", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@p_UyduIsim", uydu.Isim);
            sqlCommand.Parameters.AddWithValue("@p_UyduYariCap", uydu.YariCap);
            sqlCommand.Parameters.AddWithValue("@p_GezegenId", uydu.GezegenId);
            database.OpenConnetion(sqlConnection);
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                sqlConnection.Close();
                return true;
            }
            return false;
        }


        public bool GuncelleUydu(Uydu uydu)
        {
            SqlCommand sqlCommand = new SqlCommand("GuncelleUydu", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@p_UyduID", uydu.Id);
            sqlCommand.Parameters.AddWithValue("@p_UyduIsim", uydu.Isim); // TODO : İsim düzelticektir.
            sqlCommand.Parameters.AddWithValue("@p_YariCap", uydu.YariCap);
            sqlCommand.Parameters.AddWithValue("@p_GezegenId", uydu.GezegenId);
            
            database.OpenConnetion(sqlConnection);
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                sqlConnection.Close();
                return true;
            }
            return false;
        }

        //TODO : Return id olacak.
        public bool SilUydu(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("SilUydu", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@p_UyduID", id);
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
