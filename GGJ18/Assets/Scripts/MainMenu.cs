using System.Collections;
using System.Collections.Generic;
using Package.CustomLibrary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Image fadeImage;
    public Text typeWriterText;
    
    public void Start()
    {
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = false;

        StartCoroutine(fadeIn());
    }

    private void StartFadeOut()
    {
        //devo rimuovere i tasti "CIRCUITO" e iniziare il gioco
        fadeImage.raycastTarget = true;
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeIn()
    {
        fadeImage.raycastTarget = false;
        fadeImage.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
    }


    IEnumerator fadeOut()
    {
        fadeImage.GetComponent<Image>().CrossFadeAlpha(1f, 1f, false);
        yield return null;
    }


    public void LoadLevel (int scene)
    {
        StartCoroutine(fadeOut());
        StartCoroutine(LoadLevelCO(scene));
    }

    public IEnumerator LoadLevelCO (int levelIndex)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(levelIndex);
    }

    public void TypeWriter()
    {
        if (typeWriterText == null)
            return;

        string text = typeWriterText.text;
        typeWriterText.text = string.Empty;
        UtilitiesUI.WriteTextInTypewriterStyle(typeWriterText, text, 0.06f);
    }
}
