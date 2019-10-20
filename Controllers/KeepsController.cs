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
    public ActionResult<IEnumerable<Keep>> GetAll()
    {
      try
      {
        return Ok(_ks.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
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
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetUser()
    {
      try
      {
        var id = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.GetUser(id));
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
        newKeep.Id = id;
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


  }
}







