using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Vault GetVault(int id)
    {
      string sql = "SELECT * FROM Vaults WHERE id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }

    public IEnumerable<Vault> GetUserVault(string id)
    {
      string sql = "SELECT * FROM Vaults WHERE userId = @id";
      return _db.Query<Vault>(sql, new { id });
    }

    public int CreateVault(Vault newVault)
    {
      string sql = @"
     INSERT INTO vaults
     (name, description,userId)
     VALUES
     (@Name,@Description,@UserId);
     SELECT lAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}