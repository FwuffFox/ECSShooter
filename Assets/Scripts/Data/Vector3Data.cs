using System;
using UnityEngine;

namespace ECSShooter.Data
{
    [Serializable]
    public class Vector3Data
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3Data(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3Data(Vector3 data)
        {
            X = data.x;
            Y = data.y;
            Z = data.z;
        }
    }
}