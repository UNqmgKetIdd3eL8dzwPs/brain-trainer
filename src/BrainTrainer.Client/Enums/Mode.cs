using BrainTrainer.Client.UrlSerializer.Attributes;

namespace BrainTrainer.Client.Enums
{
    public enum Mode
    {
        [UrlEnumValue("random")]
        Random,
        [UrlEnumValue("search/questions")]
        Search
    }
}