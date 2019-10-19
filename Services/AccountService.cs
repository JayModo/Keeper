using System;
using Keepr.Repositories;
using Keepr.Models;
using System.Collections.Generic;

namespace Keepr
{
  public class AccountService
  {
    private readonly KeepsRepository _krepo;
    private readonly AccountRepository _repo;

    public User Register(UserRegistration creds)
    {
      User user = new User();
      user.Id = Guid.NewGuid().ToString();
      user.Email = creds.Email;
      user.Username = creds.Username;
      user.Hash = BCrypt.Net.BCrypt.HashPassword(creds.Password);

      _repo.Register(user);
      return user;
    }

    public User SignIn(UserSignIn creds)
    {
      User user = _repo.GetUserByEmail(creds.Email);
      if (user == null || !BCrypt.Net.BCrypt.Verify(creds.Password, user.Hash))
      {
        throw new Exception("Invalid Email or Password");
      }
      user.Hash = null;
      return user;
    }

    public User GetUserById(string Id)
    {
      User user = _repo.GetUserById(Id);
      if (user == null) { throw new Exception("Invalid Request"); }
      user.Hash = null;
      return user;
    }
    public IEnumerable<Keep> GetKeeps(string userId)
    {
      User exists = _repo.GetUserById(userId);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return _krepo.GetUsersByKeepId(userId);
    }

    public AccountService(AccountRepository repo, KeepsRepository krepo)
    {
      _krepo = krepo;
      _repo = repo;
    }
  }
}