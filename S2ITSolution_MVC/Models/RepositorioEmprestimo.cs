using S2ITSolution_MVC.Models.Base;
using S2ITSolution_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace S2ITSolution_MVC.Models
{
    public class RepositorioEmprestimo
    {
        private AcessDB db = new AcessDB();

        public string CriarEmprestimo(EmprestimoViewModel emp)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@Amigo", emp.ID_Amigo);
                db.AddParameters("@Jogo", emp.ID_Jogo);            

                String cmd = "INSERT INTO dbo.Emprestimo (ID_Amigo, ID_Jogo, DH_Emprestimo) values(@Amigo, @Jogo, GETDATE())";

                string result = db.ExecuteCUD(System.Data.CommandType.Text, cmd);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EmprestimoViewModel GetEmprestimoById(int id)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@Id", id);

                String cmd = @"SELECT * 
                               FROM dbo.Emprestimo WITH (NOLOCK)
                               WHERE ID_Emprestimo = @Id";

                DataTable dt = db.ExecuteR(System.Data.CommandType.Text, cmd);
                EmprestimoViewModel emp = null;

                foreach (DataRow dr in dt.Rows)
                {
                    EmprestimoViewModel _emp = new EmprestimoViewModel();
                    _emp.ID_Emprestimo = Convert.ToInt32(dr["ID_Emprestimo"]);
                    _emp.ID_Jogo = Convert.ToInt32(dr["ID_Jogo"]);
                    _emp.ID_Amigo = Convert.ToInt32(dr["ID_Amigo"]);
                    _emp.DH_Devolucao = Equals(dr["DH_Devolucao"]) ? Convert.ToDateTime(dr["DH_Devolucao"]) : DateTime.MinValue;
                    _emp.DH_Emprestimo = Convert.ToDateTime(dr["DH_Emprestimo"]);

                    emp = _emp;
                }

                return emp;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string DeleteEmprestimo(EmprestimoViewModel Emp)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@Id", Emp.ID_Emprestimo);

                String cmd = "DELETE FROM dbo.Emprestimo WHERE ID_Emprestimo = @Id";

                string result = db.ExecuteCUD(System.Data.CommandType.Text, cmd);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string UpdateEmprestimo(EmprestimoViewModel emp)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@DH_Devolucao", emp.DH_Devolucao);                

                String cmd = "UPDATE dbo.Emprestimo SET DH_Devolucao = @DH_Devolucao WHERE ID_Empresimo = @ID_Empresimo";

                string result = db.ExecuteCUD(System.Data.CommandType.Text, cmd);

                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<EmprestimoViewModel> DemonstraEmprestimos()
        {
            try
            {
                db.ClearParameters();

                String cmd = @"SELECT  ID_Emprestimo = Emprestimo.ID_Emprestimo
                                      ,DH_Devolucao  = Emprestimo.DH_Devolucao
                                      ,DH_Emprestimo = Emprestimo.DH_Emprestimo
                               	      ,ID_Jogo       = Jogo.ID_Jogo
                               	      ,NM_Jogo       = Jogo.NM_Jogo
                               	      ,ID_Amigo      = Amigo.ID_Amigo
                               	      ,NM_Amigo      = Amigo.NM_Amigo
                               FROM dbo.Emprestimo WITH (NOLOCK)
                               INNER JOIN dbo.Jogo WITH( NOLOCK)
                               ON Jogo.ID_Jogo = Emprestimo.ID_Jogo
                               INNER JOIN dbo.Amigo WITH (NOLOCK)
                               ON Amigo.ID_Amigo = Emprestimo.ID_Amigo";

                DataTable dt = db.ExecuteR(System.Data.CommandType.Text, cmd);
                List<EmprestimoViewModel> lstEmp = new List<EmprestimoViewModel>();
                DateTime? DH_NULL = new Nullable<DateTime>();

                foreach (DataRow dr in dt.Rows)
                {
                    EmprestimoViewModel _emp = new EmprestimoViewModel();                 

                    _emp.ID_Emprestimo = Convert.ToInt32(dr["ID_Emprestimo"]);
                    _emp.ID_Jogo = Convert.ToInt32(dr["ID_Jogo"]);
                    _emp.NM_Jogo = Convert.ToString(dr["NM_Jogo"]);
                    _emp.ID_Amigo = Convert.ToInt32(dr["ID_Amigo"]);
                    _emp.NM_Amigo = Convert.ToString(dr["NM_Amigo"]);
                    _emp.DH_Devolucao = Equals(dr["DH_Devolucao"]) ? Convert.ToDateTime(dr["DH_Devolucao"]) : DH_NULL;
                    _emp.DH_Emprestimo = Convert.ToDateTime(dr["DH_Emprestimo"]);

                    lstEmp.Add(_emp);
                }

                return lstEmp;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}