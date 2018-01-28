using UnityEngine;

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
        cg.alpha = 0.4f;
    }

    public void Allow()
    {
        cg.blocksRaycasts = true;
        cg.alpha = 1;
    }
}