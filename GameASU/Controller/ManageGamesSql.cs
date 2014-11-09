using GameASU.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameASU.Controller
{
    /// <summary>
    /// Controller for managing games and properties on the Sql Database Server.
    /// </summary>
    public class ManageGameSql
    {
        private DBGame GameDC { get; set; }
        public ManageGameSql() { }

        public string InsertGame(Game game)
        {
            int ReturnCode = 0;
            string ReturnMessage = String.Empty;
            SqlConnection DBConn = new SqlConnection(global::System.Configuration.ConfigurationManager.ConnectionStrings["GameASU"].ConnectionString);

            try
            {
                SqlCommand InsertGame = new SqlCommand();

                InsertGame.Connection = DBConn;
                InsertGame.CommandText = "spi_tblGames";
                InsertGame.CommandType = CommandType.StoredProcedure;

                InsertGame.Parameters.Add("@tblDeveloperID", SqlDbType.Int).Value = game.tblDeveloperID;
                InsertGame.Parameters.Add("@GameName", SqlDbType.VarChar, 200).Value = game.GameName;
                InsertGame.Parameters.Add("@ScreenWidth", SqlDbType.Int).Value = game.ScreenWidth;
                InsertGame.Parameters.Add("@ScreenHeight", SqlDbType.Int).Value = game.ScreenHeight;
                InsertGame.Parameters.Add("@GameNameOnServer", SqlDbType.VarChar, 200).Value = game.GameNameOnServer;
                InsertGame.Parameters.Add("@TileImageLocation", SqlDbType.VarChar, 200).Value = game.TileImageLocation;
                InsertGame.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                InsertGame.Parameters.Add("@Ret_Code", SqlDbType.Int).Direction = ParameterDirection.Output;
                InsertGame.Parameters.Add("@Ret_Message", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                DBConn.Open();

                InsertGame.ExecuteNonQuery();

                game.Id = (int)InsertGame.Parameters["@ID"].Value;
                ReturnCode = (int)InsertGame.Parameters["@Ret_Code"].Value;
                ReturnMessage = InsertGame.Parameters["@Ret_Message"].Value.ToString();

                return ReturnMessage;

            }

            catch (SqlException e) { return e.Message; }
        }

        public string UpdateGame(Game game, string gameImageName)
        {
            int ReturnCode = 0;
            string ReturnMessage = String.Empty;
            SqlConnection DBConn = new SqlConnection(global::System.Configuration.ConfigurationManager.ConnectionStrings["GameASU"].ConnectionString);

            try
            {
                using (DBConn)
                {
                    SqlCommand UpdateGame = new SqlCommand();

                    UpdateGame.Connection = DBConn;
                    UpdateGame.CommandText = "spu_tblGames";
                    UpdateGame.CommandType = CommandType.StoredProcedure;

                    UpdateGame.Parameters.Add("@ID", SqlDbType.Int).Value = game.Id;
                    UpdateGame.Parameters.Add("@GameName", SqlDbType.VarChar, 200).Value = game.GameName;
                    UpdateGame.Parameters.Add("@ScreenWidth", SqlDbType.Int).Value = game.ScreenWidth;
                    UpdateGame.Parameters.Add("@ScreenHeight", SqlDbType.Int).Value = game.ScreenHeight;
                    UpdateGame.Parameters.Add("@GameNameOnServer", SqlDbType.VarChar, 200).Value = game.Id.ToString() + ".unity3d";
                    UpdateGame.Parameters.Add("@TileImageLocation", SqlDbType.VarChar, 200).Value = gameImageName;
                    UpdateGame.Parameters.Add("@Ret_Code", SqlDbType.Int).Direction = ParameterDirection.Output;
                    UpdateGame.Parameters.Add("@Ret_Message", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                    DBConn.Open();

                    UpdateGame.ExecuteNonQuery();

                    ReturnCode = (int)UpdateGame.Parameters["@Ret_Code"].Value;
                    ReturnMessage = UpdateGame.Parameters["@Ret_Message"].Value.ToString();

                    return ReturnMessage;
                }

            }
            catch (SqlException e) { return e.Message; }
        }

        public IQueryable<Game> GetTableData()
        {
            return GameDC.SelectTableData();
        }
    }
}