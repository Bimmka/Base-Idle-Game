namespace Features.Services
{
  public interface ICleanupService : IService
  {
    bool IsCleanedUp { get; }
    void Cleanup();
  }
}