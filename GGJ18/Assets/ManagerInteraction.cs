using UnityEngine;
using UnityEngine.UI;

public class ManagerInteraction : MonoBehaviour
{
    private CanvasGroup cg;

    private void Awake()
    {
        cg = this.GetComponent<CanvasGroup>();
        Block();
    }

    public void Block()
    {
        cg.blocksRaycasts = false;
        cg.interactable = false;

        for (int i = 0; i < cg.transform.childCount; i++)
        {
            cg.transform.GetChild(i).GetComponent<Image>().color = Color.grey;
        }
        
        //cg.alpha = 0.4f;
    }

    public void Allow()
    {
        cg.blocksRaycasts = true;
        cg.interactable = true;

        for (int i = 0; i < cg.transform.childCount; i++)
        {
            cg.transform.GetChild(i).GetComponent<Image>().color = Color.white;
        }


        //cg.alpha = 1;
    }
}