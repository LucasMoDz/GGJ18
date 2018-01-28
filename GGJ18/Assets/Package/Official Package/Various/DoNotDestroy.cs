public class DoNotDestroy : ManagerBaseClass
{
    protected override void PreInitialization()
    {
        base.PreInitialization();

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}