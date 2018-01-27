using UnityEngine;
using System.Collections;
using Package.CustomLibrary;

public enum ActivationType
{
    Fade = 0,
    Immediate = 1
}

public class Blink : MonoBehaviour
{
    [Range(0.2f, 2.0f)] public float seconds = 1.0f;
    public ActivationType type = ActivationType.Fade;

    private CanvasGroup canvasGroup;
    
    private IEnumerator Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup is null, fix it\n");
            yield break;
        }

        if (type == ActivationType.Immediate)
        {
            while (true)
            {
                yield return new WaitForSeconds(1.5f);
                UtilitiesUI.ObjectActivation(canvasGroup);
                yield return new WaitForSeconds(1.5f);
                UtilitiesUI.ObjectDeactivation(canvasGroup);
                yield return null;
            }
        }

        while (true)
        {
            yield return UtilitiesUI.ObjectActivation(canvasGroup, seconds, 0, seconds);
            yield return null;
        }
    }
}