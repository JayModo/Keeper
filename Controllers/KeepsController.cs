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

    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
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

    // !FIXME this is The problem
    [Authorize]
    [HttpGet("/user/Id")]
    public async Task<ActionResult<User>> GetUsers(string id)
    {
      try
      {
        //NOTE THIS IS HOW YOU GET THE USER ID (node => req.session.uid)
        var n = HttpContext.User.FindFirstValue(ClaimTypes.Name);
        var uid = HttpContext.User.FindFirstValue("Id");
        User user = _ks.GetUsers(id);
        return Ok(user);
      }
      catch (Exception e)
      {
        await HttpContext.SignOutAsync();
        return Unauthorized(e.Message);
      }
    }
    //end of the problem

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> Get(int id)
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



    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep newKeep)
    {
      try
      {
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







