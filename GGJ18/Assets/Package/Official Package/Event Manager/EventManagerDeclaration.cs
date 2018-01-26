using System;

namespace Package.EventManager
{
    /// <summary> Proprietary architecture at events. </summary>
    public class EventManager
    {
        #region Singleton

        private static Implementation.EventManager _eventManagerInstance;

        private static Implementation.EventManager EventManagerInstance
        {
            get
            {
                return _eventManagerInstance ?? (_eventManagerInstance = UnityEngine.Object.FindObjectOfType<Implementation.EventManager>());
            }
        }

        #endregion

        #region AddEvent Overloads

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent(Enum _topicName, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent(_topicName, _toBeDestroyed);
        }

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_topicType"> Set 'TopicType.Function' if you want an event that return T. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent<A>(Enum _topicName, TopicType _topicType = TopicType.Event, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent<A>(_topicName, _topicType, _toBeDestroyed);
        }

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_topicType"> Set 'TopicType.Function' if you want an event that return T. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent<A, B>(Enum _topicName, TopicType _topicType = TopicType.Event, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent<A, B>(_topicName, _topicType, _toBeDestroyed);
        }

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_topicType"> Set 'TopicType.Function' if you want an event that return T. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent<A, B, C>(Enum _topicName, TopicType _topicType = TopicType.Event, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent<A, B, C>(_topicName, _topicType, _toBeDestroyed);
        }

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_topicType"> Set 'TopicType.Function' if you want an event that return T. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent<A, B, C, D>(Enum _topicName, TopicType _topicType = TopicType.Event, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent<A, B, C, D>(_topicName, _topicType, _toBeDestroyed);
        }

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_topicType"> Set 'TopicType.Function' if you want an event that return T. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent<A, B, C, D, E>(Enum _topicName, TopicType _topicType = TopicType.Event, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent<A, B, C, D, E>(_topicName, _topicType, _toBeDestroyed);
        }

        #endregion

        #region AddListener Overloads

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener(Enum _topicName, Implementation.EventManager.CustomDelegate _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<A>(Enum _topicName, Implementation.EventManager.CustomDelegate<A> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<A, B>(Enum _topicName, Implementation.EventManager.CustomDelegate<A, B> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<A, B, C>(Enum _topicName, Implementation.EventManager.CustomDelegate<A, B, C> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<A, B, C, D>(Enum _topicName, Implementation.EventManager.CustomDelegate<A, B, C, D> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<A, B, C, D, E>(Enum _topicName, Implementation.EventManager.CustomDelegate<A, B, C, D, E> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult, A>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult, A> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult, A, B>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult, A, B> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult, A, B, C>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult, A, B, C, D>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C, D> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult, A, B, C, D, E>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C, D, E> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        #endregion

        #region RemoveListener Overloads

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener(Enum _topicName, Implementation.EventManager.CustomDelegate _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<A>(Enum _topicName, Implementation.EventManager.CustomDelegate<A> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<A, B>(Enum _topicName, Implementation.EventManager.CustomDelegate<A, B> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<A, B, C>(Enum _topicName, Implementation.EventManager.CustomDelegate<A, B, C> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<A, B, C, D>(Enum _topicName, Implementation.EventManager.CustomDelegate<A, B, C, D> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<A, B, C, D, E>(Enum _topicName, Implementation.EventManager.CustomDelegate<A, B, C, D, E> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult, A>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult, A> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult, A, B>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult, A, B> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult, A, B, C>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult, A, B, C, D>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C, D> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult, A, B, C, D, E>(Enum _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C, D, E> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        #endregion

        #region Invoke Overloads

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        public static void Invoke(Enum _topicName)
        {
            EventManagerInstance.Invoke(_topicName);
        }

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// /// <param name="_firstValue"> First parameter value of attached function. </param>
        public static void Invoke<A>(Enum _topicName, A _firstValue)
        {
            EventManagerInstance.Invoke(_topicName, _firstValue);
        }

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        public static void Invoke<A, B>(Enum _topicName, A _firstValue, B _secondValue)
        {
            EventManagerInstance.Invoke(_topicName, _firstValue, _secondValue);
        }

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        public static void Invoke<A, B, C>(Enum _topicName, A _firstValue, B _secondValue, C _thirdValue)
        {
            EventManagerInstance.Invoke(_topicName, _firstValue, _secondValue, _thirdValue);
        }

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        /// <param name="_fourthValue"> Fourth parameter value of attached function. </param>
        public static void Invoke<A, B, C, D>(Enum _topicName, A _firstValue, B _secondValue, C _thirdValue, D _fourthValue)
        {
            EventManagerInstance.Invoke(_topicName, _firstValue, _secondValue, _thirdValue, _fourthValue);
        }

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        /// <param name="_fourthValue"> Fourth parameter value of attached function. </param>
        /// <param name="_fifthValue"> Fifth parameter value of attached function. </param>
        public static void Invoke<A, B, C, D, E>(Enum _topicName, A _firstValue, B _secondValue, C _thirdValue, D _fourthValue, E _fifthValue)
        {
            EventManagerInstance.Invoke(_topicName, _firstValue, _secondValue, _thirdValue, _fourthValue, _fifthValue);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        public static TResult Invoke<TResult>(Enum _topicName)
        {
            return EventManagerInstance.Invoke<TResult>(_topicName);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        public static TResult Invoke<TResult, A>(Enum _topicName, A _firstValue)
        {
            return EventManagerInstance.Invoke<TResult, A>(_topicName, _firstValue);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        public static TResult Invoke<TResult, A, B>(Enum _topicName, A _firstValue, B _secondValue)
        {
            return EventManagerInstance.Invoke<TResult, A, B>(_topicName, _firstValue, _secondValue);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        public static TResult Invoke<TResult, A, B, C>(Enum _topicName, A _firstValue, B _secondValue, C _thirdValue)
        {
            return EventManagerInstance.Invoke<TResult, A, B, C>(_topicName, _firstValue, _secondValue, _thirdValue);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        /// <param name="_fourthValue"> Fourth parameter value of attached function. </param>
        public static TResult Invoke<TResult, A, B, C, D>(Enum _topicName, A _firstValue, B _secondValue, C _thirdValue, D _fourthValue)
        {
            return EventManagerInstance.Invoke<TResult, A, B, C, D>(_topicName, _firstValue, _secondValue, _thirdValue, _fourthValue);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        /// <param name="_fourthValue"> Fourth parameter value of attached function. </param>
        /// <param name="_fifthValue"> Fifth parameter value of attached function. </param>
        public static TResult Invoke<TResult, A, B, C, D, E>(Enum _topicName, A _firstValue, B _secondValue, C _thirdValue, D _fourthValue, E _fifthValue)
        {
            return EventManagerInstance.Invoke<TResult, A, B, C, D, E>(_topicName, _firstValue, _secondValue, _thirdValue, _fourthValue, _fifthValue);
        }

        #endregion

        #region AddEvent Overloads

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent(string _topicName, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent(_topicName, _toBeDestroyed);
        }

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_topicType"> Set 'TopicType.Function' if you want an event that return T. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent<A>(string _topicName, TopicType _topicType = TopicType.Event, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent<A>(_topicName, _topicType, _toBeDestroyed);
        }

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_topicType"> Set 'TopicType.Function' if you want an event that return T. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent<A, B>(string _topicName, TopicType _topicType = TopicType.Event, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent<A, B>(_topicName, _topicType, _toBeDestroyed);
        }

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_topicType"> Set 'TopicType.Function' if you want an event that return T. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent<A, B, C>(string _topicName, TopicType _topicType = TopicType.Event, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent<A, B, C>(_topicName, _topicType, _toBeDestroyed);
        }

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_topicType"> Set 'TopicType.Function' if you want an event that return T. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent<A, B, C, D>(string _topicName, TopicType _topicType = TopicType.Event, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent<A, B, C, D>(_topicName, _topicType, _toBeDestroyed);
        }

        /// <summary> Create a new event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_topicType"> Set 'TopicType.Function' if you want an event that return T. </param>
        /// <param name="_toBeDestroyed"> Set 'true' if gameObject has not 'DoNotDestroy'. </param>
        public static void AddEvent<A, B, C, D, E>(string _topicName, TopicType _topicType = TopicType.Event, bool _toBeDestroyed = false)
        {
            EventManagerInstance.AddEvent<A, B, C, D, E>(_topicName, _topicType, _toBeDestroyed);
        }

        #endregion

        #region AddListener Overloads

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener(string _topicName, Implementation.EventManager.CustomDelegate _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<A>(string _topicName, Implementation.EventManager.CustomDelegate<A> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<A, B>(string _topicName, Implementation.EventManager.CustomDelegate<A, B> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<A, B, C>(string _topicName, Implementation.EventManager.CustomDelegate<A, B, C> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<A, B, C, D>(string _topicName, Implementation.EventManager.CustomDelegate<A, B, C, D> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<A, B, C, D, E>(string _topicName, Implementation.EventManager.CustomDelegate<A, B, C, D, E> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult>(string _topicName, Implementation.EventManager.CustomFunction<TResult> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult, A>(string _topicName, Implementation.EventManager.CustomFunction<TResult, A> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult, A, B>(string _topicName, Implementation.EventManager.CustomFunction<TResult, A, B> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult, A, B, C>(string _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult, A, B, C, D>(string _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C, D> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        /// <summary> Add a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method or lambda expression. </param>
        public static void AddListener<TResult, A, B, C, D, E>(string _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C, D, E> _function)
        {
            EventManagerInstance.AddListener(_topicName, _function);
        }

        #endregion

        #region RemoveListener Overloads

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener(string _topicName, Implementation.EventManager.CustomDelegate _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<A>(string _topicName, Implementation.EventManager.CustomDelegate<A> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<A, B>(string _topicName, Implementation.EventManager.CustomDelegate<A, B> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<A, B, C>(string _topicName, Implementation.EventManager.CustomDelegate<A, B, C> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<A, B, C, D>(string _topicName, Implementation.EventManager.CustomDelegate<A, B, C, D> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<A, B, C, D, E>(string _topicName, Implementation.EventManager.CustomDelegate<A, B, C, D, E> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult>(string _topicName, Implementation.EventManager.CustomFunction<TResult> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult, A>(string _topicName, Implementation.EventManager.CustomFunction<TResult, A> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult, A, B>(string _topicName, Implementation.EventManager.CustomFunction<TResult, A, B> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult, A, B, C>(string _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult, A, B, C, D>(string _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C, D> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        /// <summary> Remove a function to existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_function"> Method to be removed. </param>
        public static void RemoveListener<TResult, A, B, C, D, E>(string _topicName, Implementation.EventManager.CustomFunction<TResult, A, B, C, D, E> _function)
        {
            EventManagerInstance.RemoveListener(_topicName, _function);
        }

        #endregion

        #region Invoke Overloads

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        public static void Invoke(string _topicName)
        {
            EventManagerInstance.Invoke(_topicName);
        }

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// /// <param name="_firstValue"> First parameter value of attached function. </param>
        public static void Invoke<A>(string _topicName, A _firstValue)
        {
            EventManagerInstance.Invoke(_topicName, _firstValue);
        }

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        public static void Invoke<A, B>(string _topicName, A _firstValue, B _secondValue)
        {
            EventManagerInstance.Invoke(_topicName, _firstValue, _secondValue);
        }

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        public static void Invoke<A, B, C>(string _topicName, A _firstValue, B _secondValue, C _thirdValue)
        {
            EventManagerInstance.Invoke(_topicName, _firstValue, _secondValue, _thirdValue);
        }

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        /// <param name="_fourthValue"> Fourth parameter value of attached function. </param>
        public static void Invoke<A, B, C, D>(string _topicName, A _firstValue, B _secondValue, C _thirdValue, D _fourthValue)
        {
            EventManagerInstance.Invoke(_topicName, _firstValue, _secondValue, _thirdValue, _fourthValue);
        }

        /// <summary> Invoke an existed event. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        /// <param name="_fourthValue"> Fourth parameter value of attached function. </param>
        /// <param name="_fifthValue"> Fifth parameter value of attached function. </param>
        public static void Invoke<A, B, C, D, E>(string _topicName, A _firstValue, B _secondValue, C _thirdValue, D _fourthValue, E _fifthValue)
        {
            EventManagerInstance.Invoke(_topicName, _firstValue, _secondValue, _thirdValue, _fourthValue, _fifthValue);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        public static TResult Invoke<TResult>(string _topicName)
        {
            return EventManagerInstance.Invoke<TResult>(_topicName);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        public static TResult Invoke<TResult, A>(string _topicName, A _firstValue)
        {
            return EventManagerInstance.Invoke<TResult, A>(_topicName, _firstValue);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        public static TResult Invoke<TResult, A, B>(string _topicName, A _firstValue, B _secondValue)
        {
            return EventManagerInstance.Invoke<TResult, A, B>(_topicName, _firstValue, _secondValue);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        public static TResult Invoke<TResult, A, B, C>(string _topicName, A _firstValue, B _secondValue, C _thirdValue)
        {
            return EventManagerInstance.Invoke<TResult, A, B, C>(_topicName, _firstValue, _secondValue, _thirdValue);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        /// <param name="_fourthValue"> Fourth parameter value of attached function. </param>
        public static TResult Invoke<TResult, A, B, C, D>(string _topicName, A _firstValue, B _secondValue, C _thirdValue, D _fourthValue)
        {
            return EventManagerInstance.Invoke<TResult, A, B, C, D>(_topicName, _firstValue, _secondValue, _thirdValue, _fourthValue);
        }

        /// <summary> Invoke an existed event with return parameter. </summary>
        /// <param name="_topicName"> Topic name. </param>
        /// <param name="_firstValue"> First parameter value of attached function. </param>
        /// <param name="_secondValue"> Second parameter value of attached function. </param>
        /// <param name="_thirdValue"> Third parameter value of attached function. </param>
        /// <param name="_fourthValue"> Fourth parameter value of attached function. </param>
        /// <param name="_fifthValue"> Fifth parameter value of attached function. </param>
        public static TResult Invoke<TResult, A, B, C, D, E>(string _topicName, A _firstValue, B _secondValue, C _thirdValue, D _fourthValue, E _fifthValue)
        {
            return EventManagerInstance.Invoke<TResult, A, B, C, D, E>(_topicName, _firstValue, _secondValue, _thirdValue, _fourthValue, _fifthValue);
        }

        #endregion
    }
}