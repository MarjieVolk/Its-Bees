using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Module : MonoBehaviour
{
    public enum Side
    {
        Top, Bottom, Left, Right
    }

    [Serializable]
    private class SideConfig
    {
        [SerializeField] private bool isConnector;
        public bool IsConnector { get { return this.isConnector; } }
    }

    [SerializeField] private SideConfig leftSide;
    [SerializeField] private SideConfig rightSide;
    [SerializeField] private SideConfig topSide;
    [SerializeField] private SideConfig bottomSide;
    [SerializeField] private MonoBehaviour enableOnAttach;

    private Dictionary<Side, SideConfig> sideConfig;

    private Lanes lanes;
    private ModuleGrid castleGrid;
    private HasLane lane;

    private void Start()
    {
        this.sideConfig = new Dictionary<Side, SideConfig>();
        this.sideConfig[Side.Left] = this.leftSide;
        this.sideConfig[Side.Right] = this.rightSide;
        this.sideConfig[Side.Top] = this.topSide;
        this.sideConfig[Side.Bottom] = this.bottomSide;

        lanes = GetComponentInParent<Lanes>();
        castleGrid = FindObjectOfType<ModuleGrid>(); // TODO don't use FindObjectOfType, generally
        lane = GetComponent<HasLane>();

        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.size = new Vector2(lanes.LaneHeight, lanes.LaneHeight);
    }

    private void Update()
    {
        if (!IsAttached())
        {
            int x = lanes.XPositionToLaneDepth(transform.position.x);
            int y = lane.Lane;

            //Debug.Log(transform.position + " -> (" + x + ", " + y + ")");
            if (castleGrid.TryConnectModuleGlobalLane(this, x, y))
            {
                Destroy(GetComponent<MovesForwards>());
                enableOnAttach.enabled = true;
            }
        }
    }

    private bool IsAttached()
    {
        Transform t = transform;
        while (t != castleGrid.transform && t.parent != null)
        {
            t = t.parent;
        }

        return t == castleGrid.transform;
    }

    public bool IsConnector(Side side)
    {
        return this.sideConfig[side].IsConnector;
    }

    public IEnumerable<Side> ConnectorSides()
    {
        return this.sideConfig.Where(kvp => kvp.Value.IsConnector).Select(kvp => kvp.Key);
    }
}
