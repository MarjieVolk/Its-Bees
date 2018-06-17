using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanes : MonoBehaviour
{
    [SerializeField] private int numLanes;

    [SerializeField] private GameObject lineTexture;
    [SerializeField] private float lineDrawZ = -0.1f;

    private Bounds bounds;

    public int NumLanes { get { return numLanes; } }

    private void Start()
    {
        DrawGridLines();
    }

    private void DrawGridLines()
    {
        bool isHighlighted = false;
        for (int i = 0; i <= NumLanes; i++)
        {
            float center = CenterOfLane(i);
            GameObject line = Instantiate(lineTexture, new Vector3(0, center, lineDrawZ), Quaternion.identity);
            line.transform.localScale = new Vector3(2000, LaneHeight*100, 1);
            SpriteRenderer renderer = line.GetComponent<SpriteRenderer>();
            if (isHighlighted)
            {
                renderer.color = new Vector4(1.0f, 1.0f, 1.0f, 0.1f);
            } else
            {
                renderer.color = new Vector4(0.5f, 0.5f, 0.5f, 0.1f);
            }
            isHighlighted = !isHighlighted;
        }
    }

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
