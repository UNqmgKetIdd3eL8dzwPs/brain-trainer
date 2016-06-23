using BrainTrainer.Client.Attributes;

namespace BrainTrainer.Client.Enums
{
    [UrlPart]
    public enum Mode
    {
        [UrlValue("search/questions")]
        Random,
        [UrlValue("random")]
        Search
    }
}