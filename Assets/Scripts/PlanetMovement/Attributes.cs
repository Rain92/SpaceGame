using System;
using UnityEngine;
public class Attributes : MonoBehaviour
{
    public bool SmallObject = false;
    public bool IgnoreGravity = false;
    public bool Antigravity = false;

    public double Mass;
    public double Startspeed;
    public Vector3 StartspeedDirection;

    public Vector3d movementdirection;
    public Vector3d position;
}
