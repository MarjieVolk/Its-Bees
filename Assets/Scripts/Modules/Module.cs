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

    private Dictionary<Side, SideConfig> sideConfig;

    protected void Start()
    {
        this.sideConfig = new Dictionary<Side, SideConfig>();
        this.sideConfig[Side.Left] = this.leftSide;
        this.sideConfig[Side.Right] = this.rightSide;
        this.sideConfig[Side.Top] = this.topSide;
        this.sideConfig[Side.Bottom] = this.bottomSide;
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
