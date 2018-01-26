public class DoNotDestroy : ManagerBaseClass
{
    protected override void PreInitialization()
    {
        base.PreInitialization();

        DontDestroyOnLoad(this.gameObject);
    }
}