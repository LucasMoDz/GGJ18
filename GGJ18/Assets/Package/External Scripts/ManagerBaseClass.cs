using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ManagerBaseClass : MonoBehaviour
{
    [SerializeField]
    protected bool debugMode = true;
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += RemoveSceneLoadedParameters;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= RemoveSceneLoadedParameters;
    }
    
    private void RemoveSceneLoadedParameters(Scene _scene, LoadSceneMode _loadSceneMode)
    {
        AddListenersToExternalSceneEvents();
    }

    ///<summary> Base Awake will call AddEvents(), AddListeners() and Initialization in this order </summary>
    protected virtual void Awake()
    {
        PreInitialization();
        AddEvents();
        AddListeners();
        Initialization();
    }

    ///<summary> First Method called in the base Awake </summary>
    protected virtual void PreInitialization() {}

    ///<summary> Second Method called in the base Awake </summary>
    protected virtual void AddEvents() {}

    ///<summary> Third Method called in the base Awake, base one will register AddListenersToExternalSceneEvents() method to ExternalEventsRegistration Topic </summary>
    protected virtual void AddListeners() {}
    
    ///<summary> Fourth Method called in the base Awake </summary>
    protected virtual void Initialization() {}

    ///<summary> Place here all the listeners to events not created in the same script, will be called between awake and start </summary>
    protected virtual void AddListenersToExternalSceneEvents() {}
}