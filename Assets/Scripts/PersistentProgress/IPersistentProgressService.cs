using Data;
using Infrastructure.Services;

namespace PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
       public PlayerProgress Progress { get; set; }
    }
}