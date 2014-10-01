using System;
using UnityEngine;
using System.Collections;


public struct Vector3d
{
    public double x, y, z;

    public Vector3d(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;

    }
    private static double abs(double x) { return x > 0 ? x : -x; }
    private const double compdelta = 1e-5;
    public static Vector3d operator -(Vector3d a) { return new Vector3d(-a.x, -a.y, -a.z); }
    public static Vector3d operator -(Vector3d a, Vector3d b) { return new Vector3d(a.x - b.x, a.y - b.y, a.z - b.z); }
    public static Vector3d operator +(Vector3d a, Vector3d b) { return new Vector3d(a.x + b.x, a.y + b.y, a.z + b.z); }
    //public static bool operator !=(Vector3d lhs, Vector3d rhs) { return !(lhs == rhs); }
    //public static bool operator ==(Vector3d lhs, Vector3d rhs) { return abs(lhs.x - rhs.x) < compdelta && abs(lhs.y - rhs.y) < compdelta && abs(lhs.z - rhs.z) < compdelta; }
    public static Vector3d operator *(double d, Vector3d a) { return new Vector3d(a.x * d, a.y * d, a.z * d); }
    public static Vector3d operator *(Vector3d a, double d) { return new Vector3d(a.x * d, a.y * d, a.z * d); }
    public static Vector3d operator *(int d, Vector3d a) { return new Vector3d(a.x * d, a.y * d, a.z * d); }
    public static Vector3d operator *(Vector3d a, int d) { return new Vector3d(a.x * d, a.y * d, a.z * d); }
    public static Vector3d operator /(Vector3d a, double d) { return new Vector3d(a.x / d, a.y / d, a.z / d); }

    public Vector3 ToVector3()
    {
        return new Vector3((float)x, (float)y, (float)z);
    }
    public double Length()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }
    public double LengthSquared()
    {
        return x * x + y * y + z * z;
    }
    public Vector3d Normalize()
    {
        double l = this.Length();
        return new Vector3d(x / l, y / l, z / l);
    }
}