using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanes : MonoBehaviour
{
    [SerializeField] private int numLanes;
    public int NumLanes { get { return numLanes; } }

    public float CenterOfLane(int lane)
    {
        Bounds bounds = this.GetComponent<Collider2D>().bounds;
        return bounds.min.y + bounds.size.y * (lane + 0.5f) / numLanes;
    }

    public float LaneHeight
    {
        get { return GetComponent<Collider2D>().bounds.size.y / numLanes; }
    }

    public int RandomLane()
    {
        return Random.Range(0, NumLanes);
    }
}
