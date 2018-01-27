using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetHandler : MonoBehaviour {

    public int alphabetValue;
    public List<GameObject> alphabetCanvas = new List<GameObject>();

    public void SetValue(int value)
    {
        alphabetValue = value;
    }

    public void ShowAlphabet ()
    {
        if (alphabetValue == 0)
        {
            alphabetCanvas[0].GetComponent<CanvasGroup>().alpha = 1;
            alphabetCanvas[0].GetComponent<CanvasGroup>().interactable = true;
            alphabetCanvas[0].GetComponent<CanvasGroup>().blocksRaycasts = true;

            alphabetCanvas[1].GetComponent<CanvasGroup>().alpha = 0;
            alphabetCanvas[1].GetComponent<CanvasGroup>().interactable = false;
            alphabetCanvas[1].GetComponent<CanvasGroup>().blocksRaycasts = false;

            alphabetCanvas[2].GetComponent<CanvasGroup>().alpha = 0;
            alphabetCanvas[2].GetComponent<CanvasGroup>().interactable = false;
            alphabetCanvas[2].GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else if (alphabetValue == 1)
        {
            alphabetCanvas[0].GetComponent<CanvasGroup>().alpha = 0;
            alphabetCanvas[0].GetComponent<CanvasGroup>().interactable = false;
            alphabetCanvas[0].GetComponent<CanvasGroup>().blocksRaycasts = false;

            alphabetCanvas[1].GetComponent<CanvasGroup>().alpha = 1;
            alphabetCanvas[1].GetComponent<CanvasGroup>().interactable = true;
            alphabetCanvas[1].GetComponent<CanvasGroup>().blocksRaycasts = true;

            alphabetCanvas[2].GetComponent<CanvasGroup>().alpha = 0;
            alphabetCanvas[2].GetComponent<CanvasGroup>().interactable = false;
            alphabetCanvas[2].GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else if (alphabetValue == 2)
        {
            alphabetCanvas[0].GetComponent<CanvasGroup>().alpha = 0;
            alphabetCanvas[0].GetComponent<CanvasGroup>().interactable = false;
            alphabetCanvas[0].GetComponent<CanvasGroup>().blocksRaycasts = false;

            alphabetCanvas[1].GetComponent<CanvasGroup>().alpha = 0;
            alphabetCanvas[1].GetComponent<CanvasGroup>().interactable = false;
            alphabetCanvas[1].GetComponent<CanvasGroup>().blocksRaycasts = false;

            alphabetCanvas[2].GetComponent<CanvasGroup>().alpha = 1;
            alphabetCanvas[2].GetComponent<CanvasGroup>().interactable = true;
            alphabetCanvas[2].GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }


}
