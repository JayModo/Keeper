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
      (name, img, userId, isPrivate, description)
      VALUES
      (@Name,@Img,@UserId,@IsPrivate,@Description);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    public IEnumerable<Keep> GetUser(string id)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @id";
      return _db.Query<Keep>(sql, new { id });
    }

    public void Edit(Keep keep)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name,
      img = @Img,
      isPrivate = @IsPrivate,
      description = @Description
      WHERE id = @Id";
      _db.Execute(sql, keep);
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    public IEnumerable<Keep> GetUsersByKeepId(string uid)
    {
      string sql = "SELECT * FROM user WHERE userId = @userid";
      return _db.Query<Keep>(sql, new { uid });
    }
  }
}