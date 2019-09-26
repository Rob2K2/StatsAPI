using MySql.Data.MySqlClient;
using StatsAPI.DB;
using StatsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.DAL
{
    public class UserDAL
    {
        public bool UpdateUserKudos(int id, int totalKudos)
        {
            bool respuesta = false;
            try
            {
                using (var con = Connection.ConexionMysql())
                {
                    con.Open();
                    var query = "UPDATE kudos_usuarios.kudos_users " +
                                "SET total_kudos=? " +
                                "WHERE id = ?";

                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add("@total_kudos", MySqlDbType.Int16).Value = totalKudos;
                    cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

                    respuesta = Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public User ObtenerUsuario(int id)
        {
            var user = new User();
            try
            {
                using (var con = Connection.ConexionMysql())
                {
                    con.Open();
                    var query = "SELECT  id userid, first_name firstname, last_name lastname, nickname, total_kudos totalkudos " +
                                "FROM kudos_usuarios.kudos_users " +
                                "WHERE id = ?";

                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

                    using (var dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            user.UserID = Convert.ToInt32(dr["userid"]);
                            user.FirstName = dr["firstname"].ToString();
                            user.LastName = dr["lastname"].ToString();
                            user.NickName = dr["nickname"].ToString();
                            //user.TotalKudos = Convert.ToInt32(dr["totalkudos"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }
    }
}
