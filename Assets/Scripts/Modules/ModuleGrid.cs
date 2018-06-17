using UnityEngine;

public class ModuleGrid : MonoBehaviour
{
    [SerializeField] private int maxDepth = 5;
    [SerializeField] private int height = 4;

    private Module[,] grid;

    protected void Start()
    {
        this.grid = new Module[maxDepth, height];
    }

    public void TryConnectModule(Module module, int x, int y)
    {
        if (x > this.maxDepth || !this.IsConnectable(x, y))
            return;

        if (x == this.maxDepth)
        {
            x--;

            // Move the whole grid back 1
            for (int i = 0; i < this.maxDepth - 1; i++)
            {
                for (int j = 0; j < this.height; j++)
                {
                    this.grid[i, j] = this.grid[i + 1, j];
                }
            }
        }

        this.grid[x, y] = module;
    }

    private bool IsConnectable(int x, int y)
    {
        // Is there already a module at this location?
        if (x < this.maxDepth && this.grid[x, y] != null)
            return false;

        Module leftSide = null;
        if (x > 0)
            leftSide = this.grid[x - 1, y];

        Module rightSide = null;
        if (this.maxDepth > x + 1)
            rightSide = this.grid[x + 1, y];

        Module topSide = null;
        if (this.maxDepth > x && this.height > y + 1)
            topSide = this.grid[x, y + 1];

        Module bottomSide = null;
        if (this.maxDepth > x && y > 0)
            bottomSide = this.grid[x, y - 1];

        // Are there any adjacent modules to attach this one to?
        if (leftSide == null && rightSide == null && topSide == null && bottomSide == null)
        {
            return false;
        }
        else
        {
            // Do all of the adjacent modules allow connections on their adjacent face?
            bool isConnectable = true;

            if (leftSide != null)
                isConnectable &= leftSide.IsConnector(Module.Side.Right);

            if (rightSide != null)
                isConnectable &= rightSide.IsConnector(Module.Side.Left);

            if (topSide != null)
                isConnectable &= topSide.IsConnector(Module.Side.Bottom);

            if (bottomSide != null)
                isConnectable &= bottomSide.IsConnector(Module.Side.Top);

            return isConnectable;
        }
    }
}