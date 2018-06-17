using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanes : MonoBehaviour
{
    [SerializeField] private int numLanes;

    private Bounds bounds;

    public int NumLanes { get { return numLanes; } }

    private void Awake()
    {
        bounds = GetComponent<BoxCollider2D>().bounds;
    }

    public float CenterOfLane(int lane)
    {
        return bounds.min.y + bounds.size.y * (lane + 0.5f) / numLanes;
    }

    public float LaneHeight
    {
        get { return bounds.size.y / numLanes; }
    }

    public int RandomLane()
    {
        return Random.Range(0, NumLanes);
    }

    public int XPositionToLaneDepth(float positionX)
    {
        return Mathf.FloorToInt((positionX - bounds.min.x) / LaneHeight);
    }
}
