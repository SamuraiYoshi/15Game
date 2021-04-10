using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotManager : MonoBehaviour
{
    public bool occupied;

    public bool trueOccupied;

    


   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(gameObject.tag))
        {
            occupied = true;
            trueOccupied = true;
        }
        else
        {
            occupied = true;
            trueOccupied = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        occupied = false;
        trueOccupied = false;
    }
}
