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
            this.gameObject.GetComponent<Image>().color = Color.red;
        } else if(symbolValue == 1)
        {
            this.gameObject.GetComponent<Image>().color = Color.green;
        } else if (symbolValue == 0)
        {
            this.gameObject.GetComponent<Image>().color = Color.grey;
        }
    }

    public void ResetButtonColor ()
    {
        this.gameObject.GetComponent<Image>().color = Color.white;
    }

}
