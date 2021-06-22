using UnityEngine;

namespace TinyTools.Extensions
{
    public static class VectorExtensions
    {
        /// <summary>
        /// Returns this vectory with only x and y
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 ToVector2(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }

        /// <summary>
        /// Set x value of Vector2
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        public static void SetX(this Vector2 v, float x)
        {
            v = new Vector2(x, v.y);
        }

        /// <summary>
        /// Set y value of Vector2
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        public static void SetY(this Vector2 v, float y)
        {
            v = new Vector2(v.x, y);
        }

        /// <summary>
        /// Return a copy of this vector with an altered x component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector2 ChangeX(this Vector2 v, float x)
        {
            return new Vector2(x, v.y);
        }

        /// <summary>
        /// Return a copy of this vector with an altered y component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector2 ChangeY(this Vector2 v, float y)
        {
            return new Vector2(v.x, y);
        }

        /// <summary>
        /// Sets x value of Vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        public static void SetX(this Vector3 v, float x)
        {
            v = new Vector3(x, v.y, v.z);
        }

        /// <summary>
        /// Sets y value of Vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        public static void SetY(this Vector3 v, float y)
        {
            v = new Vector3(v.x, y, v.z);
        }

        /// <summary>
        /// Sets z value of Vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        public static void SetZ(this Vector3 v, float z)
        {
            v = new Vector3(v.x, v.y, z);
        }

        /// <summary>
        /// Return a copy of this vector with an altered x component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 ChangeX(this Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        /// <summary>
        /// Return a copy of this vector with an altered y component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 ChangeY(this Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }

        /// <summary>
        /// Return a copy of this vector with an altered z component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 ChangeZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }
    }
}
