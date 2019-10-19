namespace Keepr.Interfaces
{
  public interface IKeep
  {
    string Name { get; set; }

    string Description { get; set; }

    string Img { get; set; }

    int Id { get; set; }
    int UserId { get; set; }

    bool isprivate { get; set; }

    int views { get; set; }
    int Shares { get; set; }
    int Keeps { get; set; }


  }
}