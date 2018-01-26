using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class SceneNavigator : EditorWindow
{
    [MenuItem("Scene Navigator/Loader")]
    private static void OpenLoader()
    {
        OpenScene("Assets/Internal Assets/00-00 Loader/Loader.unity");
    }

    [MenuItem("Scene Navigator/Aspect Ratio")]
    private static void OpenAspectRatio()
    {
        OpenScene("Assets/Internal Assets/00-01 AspectRatio/Scenes/AspectRatio.unity");
    }

    [MenuItem("Scene Navigator/Preloading")]
    private static void OpenPreloading()
    {
        OpenScene("Assets/Internal Assets/01-02 Preloading/Scenes/Preloading.unity");
    }

    [MenuItem("Scene Navigator/Inn")]
    private static void OpenInn()
    {
        OpenScene("Assets/Internal Assets/03-04 Inn/Scenes/Inn.unity");
    }

    [MenuItem("Scene Navigator/Deck Builder")]
    private static void OpenDeckBuilder()
    {
        OpenScene("Assets/Internal Assets/05-06 DeckBuilder/Scenes/DeckBuilder.unity");
    }

    [MenuItem("Scene Navigator/Inventory Shop")]
    private static void OpenInventoryShop()
    {
        OpenScene("Assets/Internal Assets/07-08 InventoryShop/Scenes/InventoryShop.unity");
    }

    [MenuItem("Scene Navigator/Dungeon Choose")]
    private static void OpenDungeonChoose()
    {
        OpenScene("Assets/Internal Assets/11-12 DungeonChoose/Scenes/DungeonChoose.unity");
    }

    [MenuItem("Scene Navigator/Dungeon Game")]
    private static void OpenDungeonGame()
    {
        OpenScene("Assets/Internal Assets/13-14 DungeonGame/Scenes/DungeonGame.unity");
    }
    
    private static void OpenScene(string _scene)
    {
        if (Application.isPlaying)
            return;

        string sceneName = string.Empty;
        bool startToWrite = false;

        for (int i = _scene.Length - 1; i > 0; i--)
        {
            if (_scene[i].Equals('/'))
                break;

            if (startToWrite)
            {
                sceneName = sceneName.Insert(0, _scene[i].ToString());
            }

            if (_scene[i].Equals('.'))
            {
                startToWrite = true;
            }
        }

        if (SceneManager.GetActiveScene().name.Equals(sceneName))
            return;

        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(_scene);
        }

        Debug.Log(sceneName + " has been opened\n");
    }
}