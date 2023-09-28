using System.Collections.Generic;

namespace TinyTools
{
    public static class ListExtensions
    {
        /// <summary>
        /// Return a random item from list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T Random<T>(this IList<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Removes and returns a random item from the list
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
        /// Shuffles the list (Fisher-Yates algorithm)
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
