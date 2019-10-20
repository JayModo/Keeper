using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {

      _repo = repo;
    }

    public Vault GetVault(int id)
    {
      Vault exists = _repo.GetVault(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

    public IEnumerable<Vault> GetUserVault(string id)
    {
      return _repo.GetUserVault(id);
    }

    public Vault CreateVault(Vault newVault)
    {
      int id = _repo.CreateVault(newVault);
      newVault.Id = id;
      return newVault;
    }

    public string Delete(int id)
    {
      Vault exists = _repo.GetVault(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return "the Vault was terminated";
    }
  }
}