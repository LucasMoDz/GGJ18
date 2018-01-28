using Package.CustomLibrary;
using UnityEngine;
using UnityEngine.UI;

public class CollisionLaser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Spaceship"))
        {
            Debug.Log(coll.gameObject.name);
            if (this.transform.parent.parent.CompareTag("Spaceship"))
                return;

            Debug.Log("ENTrato");
            this.transform.parent.parent.GetChild(1).GetComponent<EarthEnergyHandler>().isCollided = true;
            //coll.GetComponent<SpaceShip>().explode();
            EarthEnergyHandler earth = FindObjectOfType<EarthEnergyHandler>();

            earth.attack();
            earth.isCollided = true;
            coll.gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.clear;

            UtilitiesGen.CallMethod(2.2f, ()=>
            {
                earth = FindObjectOfType<EarthEnergyHandler>();
                earth.isCollided = false;
                earth.laser.GetComponent<RectTransform>().sizeDelta = new Vector2(earth.laser.GetComponent<RectTransform>().sizeDelta.x, 0);
                coll.gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.white;
            });
        }
        else if (coll.gameObject.CompareTag("Earth"))
        {
            if (this.transform.parent.parent.GetChild(1).tag == "Earth")
                return;

            this.transform.parent.parent.gameObject.GetComponent<SpaceShip>().isCollided = true;
        }
    }
}