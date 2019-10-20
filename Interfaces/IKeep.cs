namespace Keepr.Interfaces
{
  public interface IKeep
  {
    string Name { get; set; }

    string Description { get; set; }

    string Img { get; set; }

    int Id { get; set; }
    string UserId { get; set; }

    bool IsPrivate { get; set; }

    int views { get; set; }
    int Shares { get; set; }
    int Keeps { get; set; }


  }
}