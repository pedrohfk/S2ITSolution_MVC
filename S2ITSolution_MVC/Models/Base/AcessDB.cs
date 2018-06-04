using System;
using System.Data;
using System.Data.SqlClient;

namespace S2ITSolution_MVC.Models.Base
{
    public class AcessDB
    {
        private string stringConnection = "Data Source=localhost;Initial Catalog=ControleEmprestimos;Integrated Security=True";

        private SqlParameterCollection sqlParametersList = new SqlCommand().Parameters;

        private SqlConnection Connect()
        {
            return new SqlConnection(stringConnection);
        }

        public void ClearParameters()
        {
            sqlParametersList.Clear();
        }

        public void AddParameters(String name, Object parameter)
        {
            sqlParametersList.AddWithValue(name, parameter);
        }

        public string ExecuteCUD(CommandType cmdType, string Cmd)
        {
            try
            {
                SqlConnection connect = Connect();
                connect.Open();

                SqlCommand sqlCmd = connect.CreateCommand();
                sqlCmd.CommandType = cmdType;
                sqlCmd.CommandText = Cmd;


                foreach (SqlParameter sqlPar in sqlParametersList)
                {
                    SqlParameter par = new SqlParameter(sqlPar.ParameterName, sqlPar.Value);
                    sqlCmd.Parameters.AddWithValue(sqlPar.ParameterName, sqlPar.Value);
                }

                string result = Convert.ToString(sqlCmd.ExecuteScalar());

                return result;

            }
            catch (Exception e)
            {

                return (e.Message);
            }
        }

        public DataTable ExecuteR(CommandType cmdType, string Cmd)
        {
            try
            {
                SqlConnection connect = Connect();
                connect.Open();

                SqlCommand sqlCmd = connect.CreateCommand();
                sqlCmd.CommandType = cmdType;
                sqlCmd.CommandText = Cmd;

                foreach (SqlParameter sqlPar in sqlParametersList)
                {
                    SqlParameter parameter = new SqlParameter(sqlPar.ParameterName, sqlPar.Value);

                    sqlCmd.Parameters.Add(parameter);
                }

                SqlDataAdapter sqlAdpt = new SqlDataAdapter(sqlCmd);
                DataTable recover = new DataTable();
                sqlAdpt.Fill(recover);

                return recover;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
