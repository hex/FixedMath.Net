using System;
namespace FixMath.NET
{
    public struct Vector2Fix64 : IEquatable<Vector2Fix64>
    {
        public readonly Fix64 X, Y;

        public static readonly Vector2Fix64 Zero = new Vector2Fix64();
        public static readonly Vector2Fix64 One = new Vector2Fix64(Fix64.One, Fix64.One);
        public static readonly Vector2Fix64 UnitX = new Vector2Fix64(Fix64.One, Fix64.Zero);
        public static readonly Vector2Fix64 UnitY = new Vector2Fix64(Fix64.Zero, Fix64.One);

        public static Vector2Fix64 operator +(Vector2Fix64 rhs) {
            return rhs;
        }
        public static Vector2Fix64 operator -(Vector2Fix64 rhs) {
            return new Vector2Fix64(-rhs.X, -rhs.Y);
        }

        public static Vector2Fix64 operator +(Vector2Fix64 lhs, Vector2Fix64 rhs) {
            return new Vector2Fix64(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }
        public static Vector2Fix64 operator -(Vector2Fix64 lhs, Vector2Fix64 rhs) {
            return new Vector2Fix64(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Vector2Fix64 operator +(Vector2Fix64 lhs, Fix64 rhs) {
            return new Vector2Fix64(lhs.X + rhs, lhs.Y + rhs);
        }
        public static Vector2Fix64 operator +(Fix64 lhs, Vector2Fix64 rhs) {
            return new Vector2Fix64(rhs.X + lhs, rhs.Y + lhs);
        }
        public static Vector2Fix64 operator -(Vector2Fix64 lhs, Fix64 rhs) {
            return new Vector2Fix64(lhs.X - rhs, lhs.Y - rhs);
        }
        public static Vector2Fix64 operator *(Vector2Fix64 lhs, Fix64 rhs) {
            return new Vector2Fix64(lhs.X * rhs, lhs.Y * rhs);
        }
        public static Vector2Fix64 operator *(Fix64 lhs, Vector2Fix64 rhs) {
            return new Vector2Fix64(rhs.X * lhs, rhs.Y * lhs);
        }
        public static Vector2Fix64 operator /(Vector2Fix64 lhs, Fix64 rhs) {
            return new Vector2Fix64(lhs.X / rhs, lhs.Y / rhs);
        }

        public Vector2Fix64(Fix64 x, Fix64 y) {
            X = x;
            Y = y;
        }

        public Fix64 Dot(Vector2Fix64 rhs) {
            return X * rhs.X + Y * rhs.Y;
        }

        public Fix64 Cross(Vector2Fix64 rhs) {
            return X * rhs.Y - Y * rhs.X;
        }

        public Fix64 GetMagnitude() {
            return Fix64.Sqrt(X * X + Y * Y);
        }

        public Vector2Fix64 Normalize() {
            if (X == Fix64.Zero && Y == Fix64.Zero)
                return Zero;

            var m = GetMagnitude();
            return new Vector2Fix64(X / m, Y / m);
        }

        public override string ToString() {
            return string.Format("({0}, {1})", X, Y);
        }

        public bool Equals(Vector2Fix64 other) {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj) {
            if (obj is Vector2Fix64)
            {
                return Equals((Vector2Fix64)obj);
            }

            return false;
        }

        public override int GetHashCode() {
            unchecked {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Vector2Fix64 value1, Vector2Fix64 value2) {
            return value1.X == value2.X && value1.Y == value2.Y;
        }

        public static bool operator !=(Vector2Fix64 value1, Vector2Fix64 value2) {
            return value1.X != value2.X || value1.Y != value2.Y;
        }
    }
}
