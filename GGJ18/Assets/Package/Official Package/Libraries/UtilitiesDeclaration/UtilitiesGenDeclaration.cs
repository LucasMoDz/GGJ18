using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Package.CustomLibrary
{
    /// <summary> Provides general tested functions. </summary>
    public class UtilitiesGen
    {
        #region Private Singleton

        private static Implementation.UtilitiesGen _utilitiesGenInstance;

        private static Implementation.UtilitiesGen UtilitiesGenInstance
        {
            get
            {
                if (_utilitiesGenInstance == null)
                {
                    _utilitiesGenInstance = Object.FindObjectOfType<Implementation.UtilitiesGen>();

                    if (Application.isPlaying)
                    {
                        EventManager.EventManager.AddEvent(TopicName.LibraryGenGarbageCollector);
                        EventManager.EventManager.AddListener(TopicName.LibraryGenGarbageCollector, GarbageCollector);
                    }
                }

                return _utilitiesGenInstance;
            }
        }

        #endregion

        #region Copy

        /// <summary> Return a copy of parameter. </summary>
        /// <param name="_object"> Object whose you want a copy. </param>
        public static T DeepClone<T>(T _object)
        {
            return UtilitiesGenInstance.DeepClone(_object);
        }

        #endregion

        #region Loading Scene

        /// <summary> Load scene using async operation. </summary>
        /// <param name="_sceneName"> Name of scene to load. </param>
        /// <param name="_mode"> Single or additive. </param>
        /// <param name="_minTotalTime"> The minimum time for the scene to be ready. </param>
        /// <param name="_extraWaitTime"> Wait time to switch active scene. WARNING: Awake() and Start() of next scene have already started. </param>
        /// <param name="_imageToFill"> Bar image to be filled. </param>
        /// <param name="_percentText"> Text to be updated with loading percentage. </param>
        public static Coroutine LoadScene(Enum _sceneName, LoadSceneMode _mode = LoadSceneMode.Single, float _minTotalTime = 0, float _extraWaitTime = 0, Image _imageToFill = null, Text _percentText = null)
        {
            return UtilitiesGenInstance.LoadScene(_sceneName, _mode, _minTotalTime, _extraWaitTime, _imageToFill, _percentText);
        }

        #endregion

        #region Sorting Algorithms

        private static Implementation.UtilitiesGen.Sort _sort;

        /// <summary> Class that provides sorting algorithms. </summary>
        public static Implementation.UtilitiesGen.Sort Sort
        {
            get
            {
                if (_sort == null)
                    _sort = new Implementation.UtilitiesGen.Sort();

                return _sort;
            }
        }

        #endregion

        #region List and Array Handler

        ///<summary> Return new list filled to parameters. </summary>
        /// <param name="_objects"> Value to be included in the list. </param>
        public static List<T> FillList<T>(params T[] _objects)
        {
            return UtilitiesGenInstance.FillList(_objects);
        }

        /// <summary> Return new array filled to parameters. </summary>
        /// <param name="_objects"> Value to be included in the array. </param>
        public static T[] FillArray<T>(params T[] _objects)
        {
            return UtilitiesGenInstance.FillArray(_objects);
        }

        /// <summary> Swap two elements of a list. </summary>
        /// <param name="_list"> List where you want swap. </param>
        /// <param name="_firstIndex"> Index of first element to be swapped. </param>
        /// <param name="_secondIndex"> Index of second element to be swapped. </param>
        public static List<T> Swap<T>(List<T> _list, int _firstIndex, int _secondIndex)
        {
            return UtilitiesGenInstance.Swap(_list, _firstIndex, _secondIndex);
        }

        /// <summary> Swap two elements of an array. </summary>
        /// <param name="_array"> Array where you want swap. </param>
        /// <param name="_firstIndex"> Index of first element to be swapped. </param>
        /// <param name="_secondIndex"> Index of second element to be swapped. </param>
        public static T[] Swap<T>(T[] _array, int _firstIndex, int _secondIndex)
        {
            return UtilitiesGenInstance.Swap(_array, _firstIndex, _secondIndex);
        }

        /// <summary> Shuffle list elements. </summary>
        /// <param name="_listToShuffle"> List to shuffle. </param>
        public static List<T> Shuffle<T>(List<T> _listToShuffle)
        {
            return UtilitiesGenInstance.Shuffle(_listToShuffle);
        }
        #endregion

        #region Activation and Deactivation

        public static void EnableObjects(params GameObject[] _object)
        {
            /// <summary> Enable parameters GameObject. </summary>
            /// <param name="_object"> Object to be activated. </param>
            UtilitiesGenInstance.EnableObjects(_object);
        }

        /// <summary> Disable parameters GameObject. </summary>
        /// <param name="_object"> Object to be deactivated. </param>
        public static void DisableObjects(params GameObject[] _object)
        {
            UtilitiesGenInstance.DisableObjects(_object);
        }

        #endregion

        #region Call Method Overloads

        /// <summary> Call method after  seconds. </summary>
        /// <param name="_seconds"> Wait seconds before starting the method. </param>
        /// <param name="_method"> Method to be started. </param>
        public static void CallMethod(float _seconds, Action _method)
        {
            UtilitiesGenInstance.CallMethod(_seconds, _method);
        }

        /// <summary> Call the method after choosed time seconds. </summary>
        /// <param name="_seconds"> Wait seconds to start parameter method. </param>
        /// <param name="_method"> Method to start. </param>
        /// <param name="_parameterValue"> Parameter of method. </param>
        public static void CallMethod<A>(float _seconds, Action<A> _method, A _parameterValue)
        {
            UtilitiesGenInstance.CallMethod(_seconds, () => _method(_parameterValue));
        }

        #endregion

        #region String Overloads

        /// <summary> Return a new string from start to parameter char. </summary>
        /// <param name="_completeString"> String to be evaluated. </param>
        /// <param name="_charToFound"> Final char. </param>
        public static string GetStringFromStartToChar(string _completeString, char _charToFound)
        {
            return UtilitiesGenInstance.GetStringFromStartToChar(_completeString, _charToFound);
        }

        /// <summary> Return a new string from first parameter char to second. </summary>
        /// <param name="_completeString"> String to be evaluated. </param>
        /// <param name="_firstChar"> Start char. </param>
        /// <param name="_secondChar"> Final char. </param>
        public static string GetStringFromFirstCharToSecond(string _completeString, char _firstChar, char _secondChar)
        {
            return UtilitiesGenInstance.GetStringFromFirstCharToSecond(_completeString, _firstChar, _secondChar);
        }

        public static string GetStringFromEnum(Enum _enum)
        {
            return UtilitiesGenInstance.GetStringFromEnum(_enum);
        }

        #endregion

        #region Load and Save Overloads
        /// <summary>Search for a file with name _filename into persistentDataPath, then it returns the data contained in it</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public static T ReadingByFile<T>(Enum _fileName)
        {
            return UtilitiesGenInstance.ReadingByFile<T>(_fileName);
        }

        /// <summary>Create a file with the name _filename into persistentDataPath and Serialize _dataToSave into it</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_fileName"></param>
        /// <param name="_dataToSave"></param>
        public static void WritingToFile<T>(Enum _fileName, T _dataToSave)
        {
            UtilitiesGenInstance.WritingToFile(_fileName, _dataToSave);
        }

        #endregion

        #region Instantiate Gameobject
       /// <summary>
       /// Needed when you are trying to instantiate by a non monobehaviour class
       /// </summary>
       /// <param name="_prefab"></param>
       /// <param name="_where"></param>
       /// <returns></returns>
        public static GameObject CustomInstantiate(GameObject _prefab, Transform _where)
        {
            return UtilitiesGenInstance.CustomInstantiate(_prefab, _where);
        }

        #endregion

        #region Start a Coroutine

        /// <summary>
        /// Needed when you are trying to Start a Coroutine by a non monobehaviour class
        /// </summary>
        /// <param name="_coroToStart"></param>
        /// <returns></returns>
        public static Coroutine CustomStartCoroutine(IEnumerator _coroToStart)
        {
            return UtilitiesGenInstance.CustomStartCoroutine(_coroToStart);
        }

        #endregion

        #region Enum Converter

        public static TEnum EnumConverter<TEnum>(Enum _value, TEnum _defaultValue = default(TEnum)) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return UtilitiesGenInstance.EnumConverter(_value, _defaultValue);
        }

        public static bool EnumConversionIsPossible<TEnum>(Enum _value, TEnum _defaultValue = default(TEnum)) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return UtilitiesGenInstance.EnumConversionIsPossible(_value, _defaultValue);
        }

        public static TEnum EnumConverter<TEnum>(string _value, TEnum _defaultValue = default(TEnum)) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return UtilitiesGenInstance.EnumConverter(_value, _defaultValue);
        }

        public static bool EnumConversionIsPossible<TEnum>(string _value, TEnum _defaultValue = default(TEnum)) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return UtilitiesGenInstance.EnumConversionIsPossible(_value, _defaultValue);
        }

        /// <summary> Return an array of enum values. </summary>
        /// <typeparam name="T"> T should be an Enum. </typeparam>
        public static T[] GetEnumValues<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            return UtilitiesGenInstance.GetEnumValues<T>();
        }

        public static T EnumConverterVariant<T>(IConvertible _value) where T : struct, IComparable, IFormattable, IConvertible
        {
            return UtilitiesGenInstance.EnumConverterVariant<T>(_value);
        }

        #endregion

        /// <summary> Force app reboot. </summary>
        public static void RebootApp()
        {
            UtilitiesGenInstance.RebootApp();
        }

        private static void GarbageCollector()
        {

        }
    }
}