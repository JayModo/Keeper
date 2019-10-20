using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Authorize]
  [ApiController]
  [Route("/api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeeps> Create([FromBody] VaultKeeps newVaultKeeps)
    {
      try
      {
        newVaultKeeps.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.CreateVaultKeeps(newVaultKeeps));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      try
      {
        string uid = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.GetVaultKeep(vaultId, uid));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut]
    //editing the vault by deleting keep
    // get the right vaultId and keepId 
    //verify the vaultkeep id before delete

    public ActionResult<string> Delete([FromBody]VaultKeeps vaultkeep)
    {
      try
      {
        return Ok(_vks.Delete(vaultkeep));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }


  }
}