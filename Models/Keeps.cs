using Keeper.Interfaces;

namespace Keeper.Models
{
  public class Keeps : IKeeps
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
  }
}