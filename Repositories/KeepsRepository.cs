using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM keeps";
      return _db.Query<Keep>(sql);
    }

    public Keep Get(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    public int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (name, img, isPrivate, description)
      VALUES
      (@Name,@Img,@IsPrivate,@Description);";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    internal User GetUsers(string id)
    {
      string sql = "SELECT * FROM user WHERE Id = @id";
      return _db.QueryFirstOrDefault<User>(sql, new { id });
    }

    public void Edit(Keep keep)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name,
     
        img = @Img,
        isPrivate = @IsPrivate,
         description = @Description)
      WHERE id = @Id";
      _db.Execute(sql, keep);
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    // internal User GetUserById(string id)
    // {
    //   string sql = "SELECT * FROM user WHERE id = @id";
    //   return _db.QueryFirstOrDefault<User>(sql, new { id });
    // }
  }
}