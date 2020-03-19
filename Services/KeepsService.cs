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

    public IEnumerable<Keep> GetAll()
    {
      return _repo.Get();
    }

    public IEnumerable<Keep> GetUser(string id)
    {
      return _repo.GetUser(id);
    }
    public Keep Get(int id)
    {
      Keep exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

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
      keep = editKeep;
      keep.Name = editKeep.Name;
      keep.Img = editKeep.Img;
      keep.Description = editKeep.Description;
      keep.views = editKeep.views;
      keep.IsPrivate = editKeep.IsPrivate;
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
  }
}