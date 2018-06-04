using S2ITSolution_MVC.Models.Base;
using S2ITSolution_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace S2ITSolution_MVC.Models
{
    public class RepositorioJogo
    {
        private AcessDB db = new AcessDB();

        public string CriarJogo(JogoViewModel Jogos)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@Nome", Jogos.NM_Jogo);

                String cmd = "INSERT INTO dbo.Jogo (NM_Jogo) values(@Nome)";

                string result = db.ExecuteCUD(System.Data.CommandType.Text, cmd);

                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public JogoViewModel GetJogoById(int id)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@Id", id);

                String cmd = @"SELECT * 
                               FROM dbo.Jogo WITH (NOLOCK) 
                               WHERE ID_Jogo = @Id";

                DataTable dt = db.ExecuteR(System.Data.CommandType.Text, cmd);
                JogoViewModel jogos = null;

                foreach (DataRow dr in dt.Rows)
                {
                    JogoViewModel _jogo = new JogoViewModel();
                    _jogo.ID_Jogo = Convert.ToInt32(dr["ID_Jogo"]);
                    _jogo.NM_Jogo = Convert.ToString(dr["NM_Jogo"]);

                    jogos = _jogo;
                }

                return jogos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string DeleteJogo(JogoViewModel Jogos)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@ID_Jogo", Jogos.ID_Jogo);

                String cmd = "DELETE FROM dbo.Jogo WHERE ID_Jogo = @ID_Jogo";

                string result = db.ExecuteCUD(System.Data.CommandType.Text, cmd);

                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string UpdateJogo(JogoViewModel Jogos)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@ID_Jogo",  Jogos.ID_Jogo);
                db.AddParameters("@NM_Jogo",  Jogos.NM_Jogo);

                String cmd = "UPDATE dbo.Jogo SET NM_Jogo = @NM_Jogo WHERE ID_Jogo = @ID_Jogo";

                string result = db.ExecuteCUD(System.Data.CommandType.Text, cmd);

                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<JogoViewModel> DemonstraJogos()
        {
            try
            {
                db.ClearParameters();

                String cmd = @"SELECT *
				               FROM dbo.JOGO WITH (NOLOCK)
				               WHERE NOT EXISTS (SELECT 1 
				               				FROM dbo.EMPRESTIMO WITH (NOLOCK)
				               				WHERE EMPRESTIMO.ID_JOGO = JOGO.ID_JOGO)";
                                
                DataTable dt = db.ExecuteR(System.Data.CommandType.Text, cmd);
                List<JogoViewModel> lstJogos = new List<JogoViewModel>();

                foreach (DataRow dr in dt.Rows)
                {
                    JogoViewModel Jogos = new JogoViewModel();
                    Jogos.ID_Jogo = Convert.ToInt32(dr["ID_Jogo"]);
                    Jogos.NM_Jogo = Convert.ToString(dr["NM_Jogo"]);

                    lstJogos.Add(Jogos);
                }

                return lstJogos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public List<JogoViewModel> DemonstraTodosJogos()
        {
            try
            {
                db.ClearParameters();

                String cmd = "SELECT * FROM dbo.JOGO WITH (NOLOCK) ";


                DataTable dt = db.ExecuteR(System.Data.CommandType.Text, cmd);
                List<JogoViewModel> lstJogos = new List<JogoViewModel>();

                foreach (DataRow dr in dt.Rows)
                {
                    JogoViewModel Jogos = new JogoViewModel();
                    Jogos.ID_Jogo = Convert.ToInt32(dr["ID_Jogo"]);
                    Jogos.NM_Jogo = Convert.ToString(dr["NM_Jogo"]);

                    lstJogos.Add(Jogos);
                }

                return lstJogos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}