using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestServer
{
    public class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }


        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }
        public static Vector3 Zero
        {
            get
            {
                return new Vector3()
                {
                    X = 0,
                    Y = 0,
                    Z = 0
                };
            }
        }


        public static Vector3 Random
        {
            get
            {
                float rndX = Guid.NewGuid().GetHashCode() % Guid.NewGuid().GetHashCode();
                float rndY = Guid.NewGuid().GetHashCode() % Guid.NewGuid().GetHashCode();
                float rndZ = Guid.NewGuid().GetHashCode() % Guid.NewGuid().GetHashCode();

                return new Vector3()
                {
                    X = rndX % 100,
                    Y = rndY % 100,
                    Z = rndZ % 100
                };
            }
        }

        public static Vector3 operator+ (Vector3 v1, Vector3 v2)
        {
            return new Vector3()
            {
                X = v1.X + v2.X,
                Y = v1.Y + v2.Y,
                Z = v1.Z + v2.Z
            };
        }

        public static Vector3 operator- (Vector3 v1, Vector3 v2)
        {
            return new Vector3()
            {
                X = v1.X - v2.X,
                Y = v1.Y - v2.Y,
                Z = v1.Z - v2.Z
            };
        }

        public static Vector3 operator* (Vector3 v, float f)
        {
            return new Vector3()
            {
                X = v.X * f,
                Y = v.Y * f,
                Z = v.Z * f,
            };
        }

        public static Vector3 operator/ (Vector3 v, float f)
        {
            return new Vector3()
            {
                X = v.X / f,
                Y = v.Y / f,
                Z = v.Z / f
            };
        }

        public static float Dot(Vector3 v1, Vector3 v2)
        {
            float result = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
            return result;           
        }

        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            return new Vector3()
            {
                X = v1.Y * v2.Z - v1.Z * v2.Y,
                Y = v1.Z * v2.X - v1.X * v2.Z,
                Z = v1.X * v2.Y - v1.Y * v2.X
            };
        }

        public static float SqrDisatnce(Vector3 v1, Vector3 v2)
        {
            float dX = v1.X - v2.X;
            float dY = v1.Y - v2.Y;
            float dZ = v1.Z - v2.Z;

            return dX * dX + dY * dY + dZ * dZ;
        }

        public static float Distance(Vector3 v1, Vector3 v2)
        {
            return (float)Math.Sqrt(SqrDisatnce(v1, v2));
        }
        

        public float SqrMagnitude()
        {
            return X * X + Y * Y + Z * Z;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(SqrMagnitude());
        }
    }
}
