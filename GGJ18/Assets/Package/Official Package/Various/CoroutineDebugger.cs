using UnityEngine;
using System.Linq;
using System.Diagnostics;
using Package.CustomLibrary;
using Debug = UnityEngine.Debug;

/// <summary> Debug class of coroutine overloading. </summary>
public static class CoroutineDebugger
{
    /// <summary> Print on console many informations of coroutine overloading. </summary>
    /// <param name="_gameObject"> GameObject to be checked. </param>
    public static void SearchConflict(GameObject _gameObject)
    {
        #if UNITY_EDITOR

        Transform[] allGameObjects = Resources.FindObjectsOfTypeAll(typeof(Transform)) as Transform[];

        foreach (var obj in allGameObjects)
        {
            if (obj.GetInstanceID().Equals(_gameObject.transform.GetInstanceID()))
            {
                string debugMessage = "More than one coroutine are running on '" + obj.transform.name + "'.\nPath: ";
                
                StackFrame stackFrame = null;
                int secondToLastIndex = 0;
                
                for (int i = 3; i < 100; i++)
                {
                    stackFrame = new StackFrame(i);
                    secondToLastIndex = i;

                    debugMessage += UtilitiesGen.GetStringFromStartToChar(stackFrame.GetMethod().DeclaringType.ToString(), '+') + " > ";
                    
                    if (IsSecondToLastCall(stackFrame))
                        break;
                }

                string functionCalled = stackFrame.GetMethod().Name;
                stackFrame = new StackFrame(secondToLastIndex + 1);
                
                if (stackFrame.GetMethod().Name.Equals("MoveNext"))
                {
                    debugMessage += UtilitiesGen.GetStringFromStartToChar(stackFrame.GetMethod().DeclaringType.ToString(), '+') + " > IEnumerator " + UtilitiesGen.GetStringFromFirstCharToSecond(stackFrame.GetMethod().DeclaringType.ToString(), '<', '>') + " > ";
                }
                else
                {
                    debugMessage += UtilitiesGen.GetStringFromStartToChar(stackFrame.GetMethod().DeclaringType.ToString(), '+') + "  > void " + stackFrame.GetMethod().Name + " > ";
                }

                debugMessage += functionCalled;
                //Debug.LogError(debugMessage);
                break;
            }
        }

        #endif
    }

    private static bool IsSecondToLastCall(StackFrame _currentStackFrame)
    {
        string constantString = "Package.CustomLibrary.Utilities";
        string[] libraries = { "UI", "Gen", "3D", "2D" };

        return libraries.Any(t => _currentStackFrame.GetMethod().DeclaringType.ToString().Equals(constantString + t));
    }
}