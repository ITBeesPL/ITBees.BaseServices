using System;
using System.Collections.Generic;
using System.Reflection;
using ITBees.BaseServices.Settings.Interfaces;
using ITBees.BaseServices.Settings.Models;

namespace ITBees.BaseServices.Settings.Services
{
    public class Replaceable
    {
        /// <summary>
        /// Returns (using reflection) list of fields with their values all fields that has UPPER CASE NAMES - use for FAS settings in different modules
        /// </summary>
        /// <param name="classThatHaveReplaceableUpperFields"></param>
        /// <returns></returns>
        public static List<ReplacableField> GetRepacableFieldsWithValues(IHasReplaceableUpperFields classThatHaveReplaceableUpperFields)
        {
            Type settingsType = classThatHaveReplaceableUpperFields.GetType();
            var result = new List<ReplacableField>();
            foreach (PropertyInfo prop in settingsType.GetProperties())
            {
                if (prop.PropertyType == typeof(string) &&
                    prop.Name == prop.Name.ToUpper())
                {

                    string propValue = prop.GetValue(classThatHaveReplaceableUpperFields) as string;
                    result.Add(new ReplacableField() { Name = prop.Name, Value = propValue });
                }
            }
            return result;
        }
    }
}