using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTurret : MonoBehaviour
{
    void OnEnable()
    {
        GetComponentInChildren<Shoot>().enabled = true;
        GetComponentInChildren<Target>().enabled = true;
    }
}
