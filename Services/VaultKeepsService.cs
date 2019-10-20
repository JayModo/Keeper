using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkrepo;

    public VaultKeepsService(VaultKeepsRepository vkrepo)
    {

      _vkrepo = vkrepo;
    }



    internal object CreateVaultKeeps(VaultKeeps newVaultKeeps)
    {
      int id = _vkrepo.CreateVaultKeeps(newVaultKeeps);
      newVaultKeeps.Id = id;
      return newVaultKeeps;
    }


    public IEnumerable<Keep> GetVaultKeep(int VaultId, string uid)
    {

      return _vkrepo.GetVaultKeep(VaultId, uid);
    }

    public string Delete(VaultKeeps vaultkeep)
    {

      VaultKeeps exists = _vkrepo.GetId(vaultkeep.VaultId, vaultkeep.KeepId);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _vkrepo.Delete(vaultkeep.Id);
      return "the VaultKeeps are no more";
    }
  }
}