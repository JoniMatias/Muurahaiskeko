using System;
using UnityEngine;

namespace Roy_T.AStar.Primitives
{
    public struct Position : IEquatable<Position>
    {
        public static Position Zero => new Position(0, 0);

        public Position(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Position FromOffset(Distance xDistanceFromOrigin, Distance yDistanceFromOrigin)
            => new Position(xDistanceFromOrigin.Meters, yDistanceFromOrigin.Meters);

        public float X { get; }
        public float Y { get; }

        public static bool operator ==(Position a, Position b)
            => a.Equals(b);

        public static bool operator !=(Position a, Position b)
            => !a.Equals(b);

        public override string ToString() => $"({this.X:F2}, {this.Y:F2})";

        public static implicit operator Vector2(Position p) => new Vector2(p.X, p.Y);
        public static implicit operator Position(Vector2 v) => new Position(v.x, v.y);
        public static implicit operator Vector3(Position p) => new Vector3(p.X, p.Y, 0);
        public static implicit operator Position(Vector3 v) => new Position(v.x, v.y);

        public override bool Equals(object obj) => obj is Position position && this.Equals(position);

        public bool Equals(Position other) => this.X == other.X && this.Y == other.Y;

        public override int GetHashCode() => -1609761766 + this.X.GetHashCode() + this.Y.GetHashCode();
    }
}
