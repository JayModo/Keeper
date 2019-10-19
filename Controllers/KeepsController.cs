using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]


  public class KeepsController : ControllerBase
  {
    private readonly AccountService _as;
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks, AccountService As)
    {
      _as = As;
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpGet]
    public ActionResult<IEnumerable<Keep>> GetById(int id)
    {
      try
      {
        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<User> Get(string id)
    {
      try
      {
        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    // FIXME this is The problem
    // [Authorize]
    // [HttpGet("Authenticate")]
    // public async Task<ActionResult<User>> Authenticate()
    // {
    //   try
    //   {
    //     //NOTE THIS IS HOW YOU GET THE USER ID (node => req.session.uid)
    //     var n = HttpContext.User.FindFirstValue(ClaimTypes.Name);
    //     var id = HttpContext.User.FindFirstValue("Id");
    //     User user = _ks.GetUserById(id);
    //     return Ok(user);
    //   }
    //   catch (Exception e)
    //   {
    //     await HttpContext.SignOutAsync();
    //     return Unauthorized(e.Message);
    //   }
    // }
    //end of the problem

    // [HttpGet("{id}/user")]
    // public ActionResult<IEnumerable<User>> GetUsers(string id)
    // {
    //   try
    //   {
    //     return Ok(_ks.GetUsers(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }



    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep newKeep)
    {
      try
      {
        var uid = HttpContext.User.FindFirstValue("Id");
        newKeep.UserId = uid;
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Keep> Edit([FromBody] Keep newKeep, int id)
    {
      try
      {

        return Ok(_ks.Edit(newKeep));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_ks.Delete(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    // [HttpGet("{id}/user")]
    // public ActionResult<IEnumerable<User>> GetUsers(string id)
    // {
    //   try
    //   {
    //     return Ok(_ks.GetUsers(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }


  }
}







