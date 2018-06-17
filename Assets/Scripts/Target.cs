using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.right = (Vector2) (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
    }
}
