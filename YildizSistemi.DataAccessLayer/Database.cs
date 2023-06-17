using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace YildizSistemi.DataAccessLayer
{
    public class Database
    {
        public SqlConnection sqlConnection { get; set; }
        public SqlCommand sqlCommand { get; set; }
        public string ConnetionString = "Data Source=ENES-THINKPAD;Initial Catalog=YildizSistemleri;Integrated Security=True";
        public Database () 
        {
            sqlConnection = new SqlConnection(ConnetionString);
            sqlCommand = sqlConnection.CreateCommand();
        }
        
        public bool OpenConnetion(SqlConnection connetion)
        {
            if (connetion.State != System.Data.ConnectionState.Closed)
            {
                connetion.Close();
            }
            connetion.Open();
            return true;
        }
        public DataTable ProsedurCalistir(string prosedurAdi, params ParamItem[] parametreler)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = prosedurAdi;
            sqlCommand.CommandType = CommandType.StoredProcedure;

            if (parametreler.Length > 0 && parametreler != null)
            {
                sqlCommand.Parameters.AddRange(ProsedurParametreDonustur(parametreler));
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;

        }
        public SqlParameter[] ProsedurParametreDonustur(params ParamItem[] parametreler)
        {
            SqlParameter[] sqlParametreleri = parametreler.Select(x => new SqlParameter()
            {
                ParameterName = x.ParamName,
                Value = x.ParamValue
            }).ToArray();
            return sqlParametreleri;
        }
    }
}
