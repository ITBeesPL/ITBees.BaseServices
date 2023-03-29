using System.Text;
using ITBees.BaseServices.Settings.Interfaces;
using ITBees.BaseServices.Settings.Models;

namespace ITBees.BaseServices.Settings.Services
{
    public class ReplaceableValues
    {
        public static string Process(string someTestInputString, params ReplaceableField[] replaceableField)
        {
            return Process(someTestInputString, null, replaceableField);
        }

        public static string Process(string someTestInputString, IHasReplaceableUpperFields settingClass, params ReplaceableField[] replaceableField)
        {
            var sb = new StringBuilder(someTestInputString);
            if (settingClass != null)
            {
                foreach (var field in Replaceable.GetRepacableFieldsWithValues(settingClass))
                {
                    sb.Replace($"[[{field.Name}]]", field.Value);
                }
            }

            foreach (var field in replaceableField)
            {
                sb.Replace($"[[{field.Name}]]", field.Value);
            }


            return sb.ToString();
        }
    }
}