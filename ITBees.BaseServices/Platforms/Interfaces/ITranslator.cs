using ITBees.Models.Languages;

namespace ITBees.BaseServices.Platforms.Interfaces
{
    public interface ITranslator
    {
        string Get(Language language, string key);
        string Get(Language language, LangConst langConst);
    }

    public interface IUserManagerLangConst
    {
        LangConst PrivateCompanyName { get; }
    }
    public struct LangConst
    {
        public string Value { get; set; }
    }
}