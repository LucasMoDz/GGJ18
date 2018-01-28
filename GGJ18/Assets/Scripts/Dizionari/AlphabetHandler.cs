using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetHandler : MonoBehaviour {

    public int alphabetValue;
    public GameObject[] alphabetCanvas;
    public GameObject[] raceButton;

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

            raceButton[0].GetComponent<Image>().color = Color.yellow;
            raceButton[0].transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
            raceButton[1].GetComponent<Image>().color = Color.white;
            raceButton[1].transform.GetChild(1).GetComponent<Image>().color = Color.white;
            raceButton[2].GetComponent<Image>().color = Color.white;
            raceButton[2].transform.GetChild(1).GetComponent<Image>().color = Color.white;
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

            raceButton[0].GetComponent<Image>().color = Color.white;
            raceButton[0].transform.GetChild(1).GetComponent<Image>().color = Color.white;
            raceButton[1].GetComponent<Image>().color = Color.yellow;
            raceButton[1].transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
            raceButton[2].GetComponent<Image>().color = Color.white;
            raceButton[2].transform.GetChild(1).GetComponent<Image>().color = Color.white;
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

            raceButton[0].GetComponent<Image>().color = Color.white;
            raceButton[0].transform.GetChild(1).GetComponent<Image>().color = Color.white;
            raceButton[1].GetComponent<Image>().color = Color.white;
            raceButton[1].transform.GetChild(1).GetComponent<Image>().color = Color.white;
            raceButton[2].GetComponent<Image>().color = Color.yellow;
            raceButton[2].transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
        }
    }


}
