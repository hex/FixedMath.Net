using System;
namespace FixMath.NET
{
    public struct Vector2Fix64 : IEquatable<Vector2Fix64>
    {
        public static readonly Vector2Fix64 Zero = new Vector2Fix64();
        public static readonly Vector2Fix64 One = new Vector2Fix64(Fix64.One, Fix64.One);
        public static readonly Vector2Fix64 UnitX = new Vector2Fix64(Fix64.One, Fix64.Zero);
        public static readonly Vector2Fix64 UnitY = new Vector2Fix64(Fix64.Zero, Fix64.One);

        public static Vector2Fix64 operator +(Vector2Fix64 rhs) {
            return rhs;
        }
        public static Vector2Fix64 operator -(Vector2Fix64 rhs) {
            return new Vector2Fix64(-rhs.m_x, -rhs.m_y);
        }

        public static Vector2Fix64 operator +(Vector2Fix64 lhs, Vector2Fix64 rhs) {
            return new Vector2Fix64(lhs.m_x + rhs.m_x, lhs.m_y + rhs.m_y);
        }
        public static Vector2Fix64 operator -(Vector2Fix64 lhs, Vector2Fix64 rhs) {
            return new Vector2Fix64(lhs.m_x - rhs.m_x, lhs.m_y - rhs.m_y);
        }

        public static Vector2Fix64 operator +(Vector2Fix64 lhs, Fix64 rhs) {
            return lhs.ScalarAdd(rhs);
        }
        public static Vector2Fix64 operator +(Fix64 lhs, Vector2Fix64 rhs) {
            return rhs.ScalarAdd(lhs);
        }
        public static Vector2Fix64 operator -(Vector2Fix64 lhs, Fix64 rhs) {
            return new Vector2Fix64(lhs.m_x - rhs, lhs.m_y - rhs);
        }
        public static Vector2Fix64 operator *(Vector2Fix64 lhs, Fix64 rhs) {
            return lhs.ScalarMultiply(rhs);
        }
        public static Vector2Fix64 operator *(Fix64 lhs, Vector2Fix64 rhs) {
            return rhs.ScalarMultiply(lhs);
        }
        public static Vector2Fix64 operator /(Vector2Fix64 lhs, Fix64 rhs) {
            return new Vector2Fix64(lhs.m_x / rhs, lhs.m_y / rhs);
        }

        readonly Fix64 m_x, m_y;

        public Vector2Fix64(Fix64 x, Fix64 y) {
            m_x = x;
            m_y = y;
        }

        public Fix64 X { get { return m_x; } }
        public Fix64 Y { get { return m_y; } }

        public Fix64 Dot(Vector2Fix64 rhs) {
            return m_x * rhs.m_x + m_y * rhs.m_y;
        }

        public Fix64 Cross(Vector2Fix64 rhs) {
            return m_x * rhs.m_y - m_y * rhs.m_x;
        }

        Vector2Fix64 ScalarAdd(Fix64 value) {
            return new Vector2Fix64(m_x + value, m_y + value);
        }
        Vector2Fix64 ScalarMultiply(Fix64 value) {
            return new Vector2Fix64(m_x * value, m_y * value);
        }

        public Fix64 GetMagnitude() {
            return Fix64.Sqrt(m_x * m_x + m_y * m_y);
        }

        public Vector2Fix64 Normalize() {
            if (m_x == Fix64.Zero && m_y == Fix64.Zero)
                return Vector2Fix64.Zero;

            var m = GetMagnitude();
            return new Vector2Fix64(m_x / m, m_y / m);
        }

        public override string ToString() {
            return string.Format("({0}, {1})", m_x, m_y);
        }

        public bool Equals(Vector2Fix64 other) {
            return m_x == other.m_x && m_y == other.m_y;
        }

        public override bool Equals(object obj) {
            if (obj is Vector2Fix64)
            {
                return Equals((Vector2Fix64)obj);
            }

            return false;
        }

        public override int GetHashCode() {
            return m_x.GetHashCode() + m_y.GetHashCode();
        }

        public static bool operator ==(Vector2Fix64 value1, Vector2Fix64 value2) {
            return value1.m_x == value2.m_x && value1.m_y == value2.m_y;
        }

        public static bool operator !=(Vector2Fix64 value1, Vector2Fix64 value2) {
            return value1.m_x != value2.m_x || value1.m_y != value2.m_y;
        }
    }
}
