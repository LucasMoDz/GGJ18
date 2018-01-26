using Package.EventManager;

public enum SaveVersionTopics
{
    /// <summary> 0 Results | 1 Parameter = int </summary>
    SetSaveVersion = 0,

    /// <summary> 1 Result = int | 0 Parameters </summary>
    GetSaveVersion = 1
}

public class ManagerSaveVersion : ManagerBaseClass
{
    //[NotEditableOnInspector]
    public int saveVersion;

    protected override void AddEvents()
    {
        base.AddEvents();

        EventManager.AddEvent<int>(SaveVersionTopics.SetSaveVersion);
        EventManager.AddEvent<int>(SaveVersionTopics.GetSaveVersion, TopicType.Function);
    }

    protected override void AddListeners()
    {
        base.AddListeners();

        EventManager.AddListener<int>(SaveVersionTopics.SetSaveVersion, _version => { saveVersion = _version; });
        EventManager.AddListener(SaveVersionTopics.GetSaveVersion, ()=> saveVersion);
    }
}