using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{

  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    private readonly AccountRepository _aRepo;
    public KeepsService(KeepsRepository repo, AccountRepository aRepo)
    {
      _repo = repo;
      _aRepo = aRepo;
    }

    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public IEnumerable<Keep> Get(string UserId)
    {
      return _repo.Get();
    }
    public Keep Get(int id)
    {
      Keep exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }




    // public User GetUserById(string id)
    // {
    //   User user = _repo.GetUserById(id);
    //   if (user == null) { throw new Exception("Invalid Request"); }
    //   user.Hash = null;
    //   return user;
    // }

    public Keep Create(Keep newKeep)
    {

      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    public Keep Edit(Keep editKeep)
    {
      Keep keep = _repo.Get(editKeep.Id);
      if (keep == null) { throw new Exception("Invalid Id"); }
      keep.Name = editKeep.Name;
      keep.UserId = editKeep.UserId;
      _repo.Edit(keep);
      return keep;
    }

    public string Delete(int id)
    {
      Keep exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return "the keep was terminated";
    }

    // public User GetUser(string UserId)
    // {
    //   User exists = _repo.Get(UserId);
    //   if (exists == null) { throw new Exception("Invalid Id"); }
    //   return exists;
    // }
  }
}