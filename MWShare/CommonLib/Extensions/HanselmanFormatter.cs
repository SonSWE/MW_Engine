﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonLib.Extensions
{
    public static class HanselmanFormatter
    {
        public static string HanselFormat(this object anObject, string aFormat)
        {
            return anObject.HanselFormat(aFormat, null);
        }

        public static string HanselFormat(this object anObject, string aFormat, IFormatProvider formatProvider)
        {
            StringBuilder sb = new();
            Type type = anObject.GetType();
            Regex reg = new(@"({)([^}]+)(})", RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(aFormat);
            int startIndex = 0;
            foreach (Match m in mc)
            {
                Group g = m.Groups[2]; //it's second in the match between { and }  
                int length = g.Index - startIndex - 1;
                sb.Append(aFormat.Substring(startIndex, length));

                string toGet = String.Empty;
                string toFormat = String.Empty;
                int formatIndex = g.Value.IndexOf(":"); //formatting would be to the right of a :  
                if (formatIndex == -1) //no formatting, no worries  
                {
                    toGet = g.Value;
                }
                else //pickup the formatting  
                {
                    toGet = g.Value.Substring(0, formatIndex);
                    toFormat = g.Value.Substring(formatIndex + 1);
                }

                //first try properties  
                PropertyInfo retrievedProperty = null;
                Type retrievedType = null;
                object retrievedObject = null;

                if (type == typeof(ExpandoObject))
                {
                    IDictionary<string, object> _dicRouteObj = anObject as IDictionary<string, object>;
                    if (_dicRouteObj?.Count > 0 && _dicRouteObj.ContainsKey(toGet))
                    {
                        retrievedType = _dicRouteObj[toGet].GetType();
                        retrievedObject = _dicRouteObj[toGet];
                    }
                }
                else
                {
                    retrievedProperty = type.GetProperty(toGet);
                    if (retrievedProperty != null)
                    {
                        retrievedType = retrievedProperty.PropertyType;
                        retrievedObject = retrievedProperty.GetValue(anObject, null);
                    }
                    else //try fields  
                    {
                        FieldInfo retrievedField = type.GetField(toGet);
                        if (retrievedField != null)
                        {
                            retrievedType = retrievedField.FieldType;
                            retrievedObject = retrievedField.GetValue(anObject);
                        }
                    }
                }

                if (retrievedType != null) //Cool, we found something  
                {
                    string result = String.Empty;
                    if (retrievedObject != null)
                    {
                        if (toFormat == String.Empty) //no format info  
                        {
                            result = retrievedType.InvokeMember("ToString",
                                BindingFlags.Public | BindingFlags.NonPublic |
                                BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase
                                , null, retrievedObject, null) as string;
                        }
                        else //format info  
                        {
                            result = retrievedType.InvokeMember("ToString",
                                BindingFlags.Public | BindingFlags.NonPublic |
                                BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase
                                , null, retrievedObject, new object[] { toFormat, formatProvider }) as string;
                        }
                    }
                    sb.Append(result);
                }
                else //didn't find a property with that name, so be gracious and put it back  
                {
                    sb.Append("{");
                    sb.Append(g.Value);
                    sb.Append("}");
                }
                startIndex = g.Index + g.Length + 1;
            }
            if (startIndex < aFormat.Length) //include the rest (end) of the string  
            {
                sb.Append(aFormat.Substring(startIndex));
            }
            return sb.ToString();
        }
    }
}
