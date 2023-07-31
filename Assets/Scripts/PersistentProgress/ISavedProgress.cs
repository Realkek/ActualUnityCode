using Data;

namespace Activity.Character
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress playerProgress);
    }
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress playerProgress);
    }
}