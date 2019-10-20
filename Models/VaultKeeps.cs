using Keepr.Interfaces;

namespace Keepr.Models
{
  public class VaultKeeps : IVaultKeeps
  {
    public int Id { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    public string UserId { get; set; }
  }
}