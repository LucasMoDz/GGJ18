using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolButton : MonoBehaviour {
    public int symbolValue;

    public void SetColor ()
    {
        if(symbolValue == -1)
        {
            //this.gameObject.transform.GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            this.gameObject.transform.GetChild(1).GetComponent<Image>().color = Color.red;
        } else if(symbolValue == 1)
        {
            //this.gameObject.transform.GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            this.gameObject.transform.GetChild(1).GetComponent<Image>().color = Color.green;
        } else if (symbolValue == 0)
        {
            //this.gameObject.transform.GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            this.gameObject.transform.GetChild(1).GetComponent<Image>().color = Color.white;
        }
    }

    public void ResetButtonColor ()
    {
        this.gameObject.transform.GetChild(1).GetComponent<Image>().color = new Color32(255,255,255, 0);
    }

}
