using S2ITSolution_MVC.Models.Base;
using S2ITSolution_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;


// Trabalharemos apenas utilizando CommandType.Text, ideal seria usar Procedures, Functions e Views.
namespace S2ITSolution_MVC.Models
{
    public class RepositorioAmigo
    {
        private AcessDB db = new AcessDB();

        public string CriarAmigo(AmigoViewModel Amigos)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@Nome", Amigos.NM_Amigo);                   

                String cmd = "INSERT INTO dbo.Amigo (NM_Amigo) values(@Nome)";

                string result = db.ExecuteCUD(System.Data.CommandType.Text, cmd);

                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public AmigoViewModel GetAmigoById(int id)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@Id", id);

                String cmd = "SELECT * FROM dbo.Amigo WHERE ID_Amigo = @Id";

                DataTable dt = db.ExecuteR(System.Data.CommandType.Text, cmd);
                AmigoViewModel amigos = null;

                foreach (DataRow dr in dt.Rows)
                {
                    AmigoViewModel _amigo = new AmigoViewModel();
                    _amigo.ID_Amigo = Convert.ToInt32(dr["ID_Amigo"]);
                    _amigo.NM_Amigo = Convert.ToString(dr["NM_Amigo"]);

                    amigos = _amigo;
                }

                return amigos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string DeleteAmigo(AmigoViewModel Amigos)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@ID_Amigo", Amigos.ID_Amigo);

                String cmd = "DELETE FROM dbo.Amigo WHERE @ID_Amigo = ID_Amigo";

                string result = db.ExecuteCUD(System.Data.CommandType.Text, cmd);

                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string UpdateAmigo(AmigoViewModel Amigos)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@ID_Amigo", Amigos.ID_Amigo);
                db.AddParameters("@NM_Amigo", Amigos.NM_Amigo);
            
                String cmd = "UPDATE dbo.Amigo SET NM_Amigo = @NM_Amigo WHERE ID_Amigo = @ID_Amigo";

                string result = db.ExecuteCUD(System.Data.CommandType.Text, cmd);

                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<AmigoViewModel> DemonstraAmigos()
        {
            try
            {
                db.ClearParameters();

                String cmd = "SELECT * FROM dbo.Amigo";

                DataTable dt = db.ExecuteR(System.Data.CommandType.Text, cmd);
                List<AmigoViewModel> lstAmigos = new List<AmigoViewModel>();

                foreach (DataRow dr in dt.Rows)
                {
                    AmigoViewModel Amigos = new AmigoViewModel();
                    Amigos.ID_Amigo = Convert.ToInt32(dr["ID_Amigo"]);
                    Amigos.NM_Amigo = Convert.ToString(dr["NM_Amigo"]);

                    lstAmigos.Add(Amigos);
                }

                return lstAmigos;
            }
            catch (Exception e)
            {

                throw new Exception (e.Message);
            }
        }
    }
}
