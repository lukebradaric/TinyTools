using System.Collections.Generic;

namespace TinyTools.Extensions
{
    // Inspired from: 
    // https://github.com/DapperDino/Dapper-Tools/blob/master/Runtime/Extensions/ListExtensions.cs

    public static class ListExtensions
    {
        /// <summary>
        /// Return random item from list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T Random<T>(this IList<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Remove random item from list and return it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RemoveRandom<T>(this IList<T> list)
        {
            int removeIndex = UnityEngine.Random.Range(0, list.Count);
            T item = list[removeIndex];

            list.RemoveAt(removeIndex);

            return item;
        }

        /// <summary>
        /// Shuffle list using Fisher-Yates algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            // Algorithm used:
            // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle

            var rand = new System.Random();

            for (int i = list.Count - 1; i > 1; i--)
            {
                int k = rand.Next(i);
                T value = list[k];
                list[k] = list[i];
                list[i] = value;
            }
        }
    }
}
