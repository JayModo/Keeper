using Keepr.Interfaces;

namespace Keepr.Models
{
  public class Keep : IKeep
  {


    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int Id { get; set; }
    public string UserId { get; set; }

    public bool IsPrivate { get; set; }

    public int views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }
  }
}