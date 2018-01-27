using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthEnergyHandler : MonoBehaviour {

    public int earthEnergyValue = 3;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Spaceship" || coll.gameObject.tag == "Laserbeam")
            earthEnergyValue -= 1;

        Debug.Log("La terra è stata attaccata! Energia rimasta= " + earthEnergyValue);

        CheckEnergy();
    }


    public void CheckEnergy ()
    {
        switch (earthEnergyValue)
        {
            case 2:

                //Far partire effetto distruzione della prima barriera

                this.transform.GetChild(0).gameObject.SetActive(false);
                break;

            case 1:

                //Far partire effetto distruzione della prima barriera


                this.transform.GetChild(0).gameObject.SetActive(false);
                break;

            case 0:
                //Far partire effetto distruzione della terra

                this.transform.GetChild(0).gameObject.SetActive(false);

                //TO DO Chiama metodo di Game Over nel GameManager

                break;
        }
    }
}
