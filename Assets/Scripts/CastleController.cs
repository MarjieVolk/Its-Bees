using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    private Lanes lanes;
    private HasLane currentLane;
    private ModuleGrid moduleGrid;
    private int maxLane
    {
        get { return lanes.NumLanes - moduleGrid.Height; }
    }

    // Use this for initialization
	void Start ()
	{
	    lanes = this.GetComponentInParent<Lanes>();
	    currentLane = this.GetComponent<HasLane>();
	    moduleGrid = this.GetComponent<ModuleGrid>();
        Reposition();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
	    {
	        if (currentLane.Lane < maxLane)
	        {
	            currentLane.Lane++;
	            Reposition();
	        }
	    }

	    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
	    {
	        if (currentLane.Lane > 0)
	        {
	            currentLane.Lane--;
                Reposition();
	        }
	    }
	}

    private void Reposition()
    {
        transform.position = new Vector3(lanes.GetComponent<BoxCollider2D>().bounds.min.x + lanes.LaneHeight / 2f, lanes.CenterOfLane(currentLane.Lane), 0);
    }
}
