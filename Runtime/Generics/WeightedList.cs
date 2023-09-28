using System;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTools.Generics
{
    public class WeightedList<T>
    {
        /// <summary>
        /// The current Count of items in the list
        /// </summary>
        public int Count => _items.Count;

        private List<Tuple<T, int>> _items = new List<Tuple<T, int>>();
        private int _weightTotal = 0;

        /// <summary>
        /// Adds a weighted item to the list
        /// </summary>
        /// <param name="item">The item to add</param>
        /// <param name="weight">The weight of the item to add</param>
        public void Add(T item, int weight)
        {
            _weightTotal += weight;
            _items.Add(new Tuple<T, int>(item, _weightTotal));
        }

        /// <summary>
        /// Returns a random item from the list
        /// (Calculated based on item weight)
        /// </summary>
        /// <returns></returns>
        public T Random()
        {
            int randomWeight = UnityEngine.Random.Range(0, _weightTotal + 1);

            foreach (Tuple<T, int> item in _items)
            {
                if (randomWeight <= item.Item2)
                    return item.Item1;
            }

            Debug.LogError("Weighted random could not find valid item!");
            return default(T);
        }

        /// <summary>
        /// Removes and returns a random item from the list
        /// (Calculated based on item weight)
        /// </summary>
        /// <returns></returns>
        public T RemoveRandom()
        {
            if (_items.Count == 0)
                return default(T);

            int randomWeight = UnityEngine.Random.Range(0, _weightTotal + 1);

            foreach (Tuple<T, int> item in _items)
            {
                if (randomWeight <= item.Item2)
                {
                    _items.Remove(item);
                    return item.Item1;
                }
            }

            Debug.LogError("Weighted random could not find valid item!");
            return default(T);
        }
    }
}
