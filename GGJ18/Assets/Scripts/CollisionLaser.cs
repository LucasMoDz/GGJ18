using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLaser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider coll)
    {
        if (coll.gameObject.CompareTag("SpaceShip"))
        {
            //coll.GetComponent<SpaceShip>().explode();
        }
    }
}