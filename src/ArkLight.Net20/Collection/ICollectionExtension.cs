using System;
using System.Collections.Generic;
using System.Text;

namespace ArkLight.Collection
{
    public static class ICollectionExtension
    {
        /// <summary>
        /// ToString()一个集合类型 (返回类型类似于Python的str()函数,没有递归调用) 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToListString<T>(IList<T> list)
        {
            var str = "[";
            if (list?.Count > 0)
            {
                var count = list.Count;
                for (var i = 0; i < count - 1; ++i)
                    str += list[i] + ", ";
                str += list[count - 1];
            }
            str += "]";
            return str;
        }

        /// <summary>
        /// ToString()一个集合类型 (返回类型类似于Python的str(dict)函数,没有递归调用) 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToKeyValuePairString<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            var str = "{";
            if (dictionary?.Count > 0)
            {
                foreach (var keyValuePair in dictionary)
                    str += $"\"{keyValuePair.Key}\" : {keyValuePair.Value}, ";
                str = str.Remove(str.Length - 2 , 2);
            }
            str += "}";
            return str;
        }

    }
}
