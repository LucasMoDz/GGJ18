using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace Package.CustomLibrary.Implementation
{
    public class UtilitiesGen : MonoBehaviour
    {
        [SerializeField]
        private bool debugMode;

        #region Private Singleton

        // It is used by internal class such as Sort
        private static UtilitiesGen _utilitiesGenInstance;

        private static UtilitiesGen UtilitiesGenInstance
        {
            get
            {
                if (_utilitiesGenInstance == null)
                    _utilitiesGenInstance = FindObjectOfType<UtilitiesGen>();

                return _utilitiesGenInstance;
            }
        }

        #endregion

        #region Deep Copy

        public T DeepClone<T>(T _object)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _object);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }

        #endregion

        #region Loading Scene

        public Coroutine LoadScene(Enum _sceneName, LoadSceneMode _mode, float _minTotalTime, float _extraWaitTime, Image _imageToFill, Text _percentText)
        {
            EventManager.Implementation.EventManager temporaryReference = FindObjectOfType<EventManager.Implementation.EventManager>();

            if (temporaryReference == null)
                Debug.LogError("Event Manager Not Found");
            else
            {
                EventManager.EventManager.Invoke(EventManager.Implementation.InternalTopics.RemoveListenersFromTopics);
                EventManager.EventManager.Invoke(EventManager.Implementation.InternalTopics.RemoveTopics);
                EventManager.EventManager.AddEvent(EventManager.Implementation.InternalTopics.RemoveTopics, true);
                EventManager.EventManager.AddEvent(EventManager.Implementation.InternalTopics.RemoveListenersFromTopics, true);
            }

            return StartCoroutine(LoadSceneCO(_sceneName, _mode, _minTotalTime, _extraWaitTime, _imageToFill, _percentText));
        }

        private IEnumerator LoadSceneCO(Enum _sceneName, LoadSceneMode _sceneMode, float _minTotalTime, float _extraWaitTime, Image _imageToFill, Text _textToshow)
        {
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(_sceneName.ToString(), _sceneMode);

            loadSceneAsync.allowSceneActivation = false;

            Action<float> FillImage = _value => { };
            Action<float> UpdateText = _value => { };

            if (_imageToFill != null)
            {
                FillImage = _value => { _imageToFill.fillAmount = _value; };
            }

            if (_textToshow != null)
            {
                UpdateText = _value => { _textToshow.text = (int)(_value * 100) + "%"; };
            }

            float step = 0;
            float temp_value = 0;
            float randomWait = _extraWaitTime;

            if (_sceneMode == LoadSceneMode.Additive)
            {
                randomWait += UnityEngine.Random.Range(.5f, 0.75f);
            }

            float firstStep = UnityEngine.Random.Range(.65f, .8f);
            
            while (step < 1)
            {
                temp_value = Mathf.Lerp(.0f, firstStep, step);
                step += Time.deltaTime / randomWait;
                FillImage(temp_value);
                UpdateText(temp_value);
                yield return null;
            }

            step = 0;

            while (step < 1)
            {
                step += Time.deltaTime / randomWait;
                temp_value = Mathf.Lerp(firstStep, 1, step);
                FillImage(temp_value);
                UpdateText(temp_value);
                yield return null;
            }

            loadSceneAsync.allowSceneActivation = true;

            //GC.Collect();

            if (_sceneMode == LoadSceneMode.Single)
            {
                EventManager.EventManager.Invoke(TopicName.LibraryGenGarbageCollector);
                EventManager.EventManager.Invoke(TopicName.LibraryUIGarbageCollector);

                yield return new WaitUntil(() => loadSceneAsync.isDone);

                //EventManager.EventManager.Invoke(SwitchSceneSmoothTopics.BlackPanelSmoothSwitchScene, Visibility.Off);
            }
            else
            {
                yield return new WaitUntil(() => loadSceneAsync.isDone);

                EventManager.EventManager.Invoke(TopicName.LibraryGenGarbageCollector);
                EventManager.EventManager.Invoke(TopicName.LibraryUIGarbageCollector);

                Scene sourceScene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneName.ToString()));
                SceneManager.UnloadSceneAsync(sourceScene);

                //EventManager.EventManager.Invoke(SwitchSceneSmoothTopics.BlackPanelSmoothSwitchScene, Visibility.Off);
            }
            
        }

        #endregion

        #region Sorting Algorithms

        public class Sort
        {
            /// <summary> Comb sort is an improved variant of Bubble Sort. </summary>
            /// <param name="_order"> Ascending or descending sorting order. </param>
            /// <param name="_array"> Can insert single values to fill a new array or pass an array that already exists. </param>
            public T[] CombSort<T>(SortingOrder _order, params T[] _array) where T : IComparable
            {
                float beforeTime = Time.realtimeSinceStartup;

                double gap = _array.Length;
                bool swaps = true;

                while (gap > 1 || swaps)
                {
                    gap /= 1.247330950103979;

                    if (gap < 1)
                        gap = 1;

                    swaps = false;
                    int i = 0;

                    while (i + gap < _array.Length)
                    {
                        int igap = i + (int)gap;

                        if (_array[i].CompareTo(_array[igap]).Equals(_order.Equals(SortingOrder.Ascending) ? 1 : -1))
                        {
                            T temp = _array[i];
                            _array[i] = _array[igap];
                            _array[igap] = temp;
                            swaps = true;
                        }

                        ++i;
                    }
                }

                if (UtilitiesGenInstance.debugMode)
                    Debug.Log("Sorting time: " + string.Format("{0:0.000}", (Time.realtimeSinceStartup - beforeTime) * 1000) + " ms\n");

                return _array;
            }
        }

        #endregion

        #region List and Array Handler

        public List<T> FillList<T>(params T[] _objects)
        {
            return _objects.ToList();
        }

        public T[] FillArray<T>(params T[] _objects)
        {
            return _objects.ToArray();
        }

        public List<T> Swap<T>(List<T> _list, int _firstIndex, int _secondIndex)
        {
            T temp = _list[_firstIndex];
            _list[_firstIndex] = _list[_secondIndex];
            _list[_secondIndex] = temp;
            return _list;
        }

        public T[] Swap<T>(T[] _array, int _firstIndex, int _secondIndex)
        {
            T temp = _array[_firstIndex];
            _array[_firstIndex] = _array[_secondIndex];
            _array[_secondIndex] = temp;
            return _array;
        }

        public List<T> Shuffle<T>(List<T> _listToShuffle)
        {
            List<T> newList = new List<T>();
            
            // Add empty elements
            for (int i = 0; i < _listToShuffle.Count; i++)
            {
                newList.Add(default(T));
            }
            
            // Initialize free indexes array
            List<byte> freeIndexes = new List<byte>();

            // Set elements value
            for (int i = 0; i < newList.Count; i++)
            {
                freeIndexes.Add((byte)i);
            }
            
            // Shuffle
            for (int i = 0; i < newList.Count; i++)
            {
                int nRandom = UnityEngine.Random.Range(0, freeIndexes.Count);
                newList[freeIndexes[nRandom]] = _listToShuffle[i];
                freeIndexes.RemoveAt(nRandom);
            }
            
            return newList;
        }

        #endregion

        #region Activation and Deactivation

        public void EnableObjects(params GameObject[] _object)
        {
            foreach (var obj in _object)
                obj.SetActive(true);
        }

        public void DisableObjects(params GameObject[] _object)
        {
            foreach (var obj in _object)
                obj.SetActive(false);
        }

        #endregion

        #region Call Method Overloads

        public void CallMethod(float _seconds, Action _method)
        {
            StartCoroutine(CallMethodCO(_seconds, _method));
        }

        private IEnumerator CallMethodCO(float _seconds, Action _method)
        {
            yield return new WaitForSecondsRealtime(_seconds);
            _method();
        }

        public void CallMethod<A>(float _seconds, Action<A> _method, A _parameterValue)
        {
            StartCoroutine(CallMethodCO(_seconds, _method, _parameterValue));
        }

        private IEnumerator CallMethodCO<A>(float _seconds, Action<A> _method, A _parameterValue)
        {
            yield return new WaitForSecondsRealtime(_seconds);
            _method(_parameterValue);
        }

        #endregion

        #region String Handler

        public string GetStringFromStartToChar(string _completeString, char _charToFound)
        {
            for (int j = 0; j < _completeString.ToCharArray().Length; j++)
            {
                if (_completeString.ToCharArray()[j].ToString().Equals(_charToFound.ToString()))
                {
                    _completeString = _completeString.Remove(j, _completeString.Length - j);
                    break;
                }
            }

            return _completeString;
        }

        public string GetStringFromFirstCharToSecond(string _completeString, char _firstChar, char _secondChar)
        {
            int indexFirstChar = Array.FindIndex(_completeString.ToCharArray(), x => x.Equals(_firstChar));

            char[] newString = CustomLibrary.UtilitiesGen.DeepClone(_completeString).Remove(0, indexFirstChar + 1).ToCharArray();

            int indexSecondChar = Array.FindIndex(newString, x => x.Equals(_secondChar));

            string finalString = string.Empty;

            for (int i = 0; i < indexSecondChar; i++)
            {
                finalString += newString[i];
            }

            return finalString;
        }

        public string GetStringFromEnum(Enum _nameIdentifier)
        {
            string fullString = _nameIdentifier.ToString();

            string temp_string = string.Empty;
            temp_string += fullString[0];

            for (var index = 1; index < fullString.Length; index++)
            {
                if (char.ToUpper(fullString[index]).Equals(fullString[index]))
                {
                    temp_string += ' ';
                }

                temp_string += fullString[index];
            }

            return temp_string;
        }

        #endregion

        #region Load and Save Handler

        public static class JsonHelper
        {
            public static T FromJson<T>(string _json)
            {
                return typeof(T).IsArray ? JsonUtility.FromJson<Wrapper<T>>(_json).item : JsonUtility.FromJson<T>(_json);
            }
            
            public static string ToJson<T>(T _data)
            {
                return typeof(T).IsArray ? JsonUtility.ToJson(new Wrapper<T> { item = _data }) : JsonUtility.ToJson(_data);
            }
            
            [Serializable]
            private class Wrapper<T>
            {
                public T item;
            }
        }

        public void WritingToFile<T>(Enum _fileName, T _data)
        {
            DirectoryInfo folder = new DirectoryInfo(Application.persistentDataPath + "/Save/Data_" + EventManager.EventManager.Invoke<int>(SaveVersionTopics.GetSaveVersion));

            if (!folder.Exists)
            {
                Debug.Log("Creating subdirectory\n");
                folder.Create();
            }
            
            File.WriteAllText(Application.persistentDataPath + "/Save/Data_" + EventManager.EventManager.Invoke<int>(SaveVersionTopics.GetSaveVersion) + "/" + _fileName + ".json", EncryptionHelper.Encrypt(JsonHelper.ToJson(_data))); 
            Debug.Log(_fileName + " has been saved\n");
        }
        
        public T ReadingByFile<T>(Enum _fileName)
        {
            string filePath = Application.persistentDataPath + "/Save/Data_" + EventManager.EventManager.Invoke<int>(SaveVersionTopics.GetSaveVersion) + "/" + _fileName + ".json";

            if (File.Exists(filePath))
            {
                Debug.Log(_fileName + " found, data has been loaded\n");
                return JsonHelper.FromJson<T>(EncryptionHelper.Decrypt(File.ReadAllText(filePath)));
            }
            
            return default(T);
        }

        #endregion

        #region Instantiate Gameobject 

        public GameObject CustomInstantiate(GameObject _prefab, Transform _where)
        {
            return Instantiate(_prefab, _where);
        }

        #endregion

        #region Start a Coroutine

        public Coroutine CustomStartCoroutine(IEnumerator _coroToStart)
        {
            return StartCoroutine(_coroToStart);
        }

        #endregion

        #region Enum Converter 

        public TEnum EnumConverter<TEnum>(Enum _value, TEnum defaultValue = default(TEnum)) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                Debug.LogError("TEnum must be an enumerated type\n");
                return default(TEnum);
            }

            if (!Enum.IsDefined(typeof(TEnum), _value.ToString()))
                return defaultValue;

            return (TEnum)Enum.Parse(typeof(TEnum), _value.ToString());
        }

        public bool EnumConversionIsPossible<TEnum>(Enum _value, TEnum defaultValue = default(TEnum)) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                Debug.LogError("TEnum must be an enumerated type\n");
                return false;
            }

            if (!Enum.IsDefined(typeof(TEnum), _value.ToString()))
                return false;

            foreach (var stringValue in Enum.GetNames(typeof(TEnum)))
            {
                if (_value.ToString() == stringValue)
                    return true;
            }

            return false;
        }

        public TEnum EnumConverter<TEnum>(string _value, TEnum defaultValue = default(TEnum)) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (typeof(TEnum).IsEnum) return (TEnum)Enum.Parse(typeof(TEnum), _value);
            Debug.LogError("TEnum must be an enumerated type\n");
            return default(TEnum);
        }

        public bool EnumConversionIsPossible<TEnum>(string _value, TEnum defaultValue = default(TEnum)) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                Debug.LogError("TEnum must be an enumerated type\n");
                return false;
            }

            for (var index = 0; index < Enum.GetNames(typeof(TEnum)).Length; index++)
            {
                var stringValue = Enum.GetNames(typeof(TEnum))[index];
                if (_value == stringValue) return true;
            }

            return false;
        }

        // Variant merged Enum Converter and new function to get enum elements array

        public T EnumConverterVariant<T>(IConvertible _value) 
        {
            if (!typeof(T).IsEnum)
            {
                Debug.LogError(typeof(T) + " is not an Enum!\n");
                return default(T);
            }

            var temp_elements = GetEnumValues<T>();

            for (int i = 0; i < temp_elements.Length; i++)
            {
                if (!temp_elements[i].ToString().Equals(_value.ToString()))
                    continue;

                if (debugMode)
                    Debug.Log("Return " + typeof(T) + "." + _value + "\n");

                return temp_elements[i];
            }

            Debug.LogError("'" + typeof(T) + "'" + " not contains " + "'" + _value + "'!" + "\n");
            return default(T);
        }

        public T[] GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)) as T[];
        }

        #endregion

        public void RebootApp()
        {
            System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe"));
            Application.Quit();
        }
    }
}

public static class EncryptionHelper
{
    private const string ENCRIPTION_KEY = "topkek";

    public static string Encrypt(string _textToEncrypt)
    {
        byte[] clearBytes = Encoding.Unicode.GetBytes(_textToEncrypt);

        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ENCRIPTION_KEY, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }

                _textToEncrypt = Convert.ToBase64String(ms.ToArray());
            }
        }

        return _textToEncrypt;
    }

    public static string Decrypt(string _textToDecrypt)
    {
        _textToDecrypt = _textToDecrypt.Replace(" ", "+");

        byte[] cipherBytes = Convert.FromBase64String(_textToDecrypt);

        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ENCRIPTION_KEY, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }

                _textToDecrypt = Encoding.Unicode.GetString(ms.ToArray());
            }
        }

        return _textToDecrypt;
    }
}