using Dapper;
using Microsoft.Data.SqlClient;
using _20220921.Models;
using _20220921.Dtos;

namespace _20220921.Repository
{
    public class CardRepository
    {
        private readonly string _connectString = DBUtil.ConnectionString();
        public IEnumerable<CardDto> GetList()
        {
            using var conn = new SqlConnection(_connectString);
            var sql = "SELECT * FROM Card";
            var result = conn.Query<Card>(sql)
            .Select(x => new CardDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Attack = x.Attack,
                Health = x.Health
            });
            return result;
        }
        public CardDto? Get(int id)
        {
            var sql =
            @"
             SELECT *
             FROM Card
             Where Id = @id
             ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);
            using var conn = new SqlConnection(_connectString);
            var oneCard = conn.QueryFirstOrDefault<Card>(sql, parameters);
            var result = new CardDto();
            if (oneCard != null)
            {
                result.Id = oneCard.Id;
                result.Name = oneCard.Name;
                result.Description = oneCard.Description;
                result.Attack = oneCard.Attack;
                result.Health = oneCard.Health;
                return result;
            }
            else

            {
                return null;
            }
        }

        public int Create(CardDto parameter)
        {
            var sql =
            @"
               INSERT INTO Card ([Name],[Description],[Attack],[Health])
               VALUES ( @Name ,@Description ,@Attack ,@Health );
               SELECT @@IDENTITY;
            ";
            using var conn = new SqlConnection(_connectString);
            var result = conn.Execute(sql, parameter);
            return result;
        }
        public bool Update(int id, CardDto parameter)
        {
            var sql =
            @"
                UPDATE Card
                SET
                [Name] = @Name
                ,[Description] = @Description
                ,[Attack] = @Attack
                ,[Health] = @Health
                WHERE
                Id = @id
            ";

            var parameters = new DynamicParameters(parameter);
            parameters.Add("Id", id, System.Data.DbType.Int32);
            using var conn = new SqlConnection(_connectString);
            var result = conn.Execute(sql, parameters);
            return result > 0;
        }
        public void Delete(int id)
        {
            var sql =
            @"
                DELETE FROM Card
                WHERE Id = @Id
            ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);
            using var conn = new SqlConnection(_connectString);
            var result = conn.Execute(sql, parameters);
        }
        public bool PartialUpdate(int id, CardPartialDto parameter)
        {
            var sql =
            @"
                UPDATE Card
                SET
                [Description] = @Description
                ,[Attack] = @Attack
                ,[Health] = @Health
                ,[Cost] = @Cost
                ,[Level] = @Level
                WHERE
                Id = @id
                ";
            var parameters = new DynamicParameters(parameter);
            parameters.Add("Id", id, System.Data.DbType.Int32);
            // 若沒用 ToString() 方法，僅會記錄原始輸入資料，如數字 1, 2, 3,..
            // 若用 ToString() 方法，才能記錄文字至 DB，如 Good, Fair, Poor…
            parameters.Add("Level", parameter.Level.ToString());
            using var conn = new SqlConnection(_connectString);
            var result = conn.Execute(sql, parameters);
            return result > 0;
        }
    }

}
