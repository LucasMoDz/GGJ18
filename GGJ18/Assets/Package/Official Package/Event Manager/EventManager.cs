using System;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Collections.Generic;
using System.Linq;

namespace Package.EventManager.Implementation
{
    public class EventManager : MonoBehaviour
    {
        #region Singleton

        private static EventManager eventManager;

        public static EventManager instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType<EventManager>();

                    if (!eventManager)
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene\n");
                }

                return eventManager;
            }
        }

        #endregion

        #region Delegate Types

        public delegate void CustomDelegate();
        public delegate void CustomDelegate<in A>(A _parameter1);
        public delegate void CustomDelegate<in A, in B>(A _parameter1, B _parameter2);
        public delegate void CustomDelegate<in A, in B, in C>(A _parameter1, B _parameter2, C _parameter3);
        public delegate void CustomDelegate<in A, in B, in C, in D>(A _parameter1, B _parameter2, C _parameter3, D _parameter4);
        public delegate void CustomDelegate<in A, in B, in C, in D, in E>(A _parameter1, B _parameter2, C _parameter3, D _parameter4, E _parameter5);

        public delegate TResult CustomFunction<out TResult>();
        public delegate TResult CustomFunction<out TResult, in A>(A _parameter1);
        public delegate TResult CustomFunction<out TResult, in A, in B>(A _parameter1, B _parameter2);
        public delegate TResult CustomFunction<out TResult, in A, in B, in C>(A _parameter1, B _parameter2, C _parameter3);
        public delegate TResult CustomFunction<out TResult, in A, in B, in C, in D>(A _parameter1, B _parameter2, C _parameter3, D _parameter4);
        public delegate TResult CustomFunction<out TResult, in A, in B, in C, in D, in E>(A _parameter1, B _parameter2, C _parameter3, D _parameter4, E _parameter5);

        #endregion

        #region Base Class, Topic List and General Methods

        public bool debugMode;

        [HideInInspector]
        public List<CustomTopicBase> topicsList = new List<CustomTopicBase>();

        [Serializable]
        public class CustomTopicBase
        {
            public string topicName;
        }
        
        private static bool ListenerExists(IEnumerable<Delegate> _functions, object _classInstance, string _methodName)
        {
            return (from function in _functions where function.Target != null && _classInstance != null select function.Target.Equals(_classInstance) && function.Method.Name.Equals(_methodName)).FirstOrDefault();
        }

        private void Awake()
        {
            // Garbage Collector Events
            instance.AddEvent(InternalTopics.RemoveTopics, true);
            instance.AddEvent(InternalTopics.RemoveListenersFromTopics, true);
        }

        #endregion

        #region Parameters Topic Custom

        [Serializable]
        public class CustomTopic : CustomTopicBase
        {
            public CustomDelegate topicDelegate;

            public CustomTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static void EmptyFunction() { }
        }

        [Serializable]
        public class CustomTopic<A> : CustomTopicBase
        {
            public CustomDelegate<A> topicDelegate;

            public CustomTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static void EmptyFunction<B>(B _empty1) { }
        }

        [Serializable]
        public class CustomTopic<A, B> : CustomTopicBase
        {
            public CustomDelegate<A, B> topicDelegate;

            public CustomTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static void EmptyFunction<C, D>(C _empty1, D _empty2) { }
        }

        [Serializable]
        public class CustomTopic<A, B, C> : CustomTopicBase
        {
            public CustomDelegate<A, B, C> topicDelegate;

            public CustomTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static void EmptyFunction<D, E, F>(D _empty1, E _empty2, F _empty3) { }
        }

        [Serializable]
        public class CustomTopic<A, B, C, D> : CustomTopicBase
        {
            public CustomDelegate<A, B, C, D> topicDelegate;

            public CustomTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static void EmptyFunction<E, F, G, H>(E _empty1, F _empty2, G _empty3, H _empty4) { }
        }

        [Serializable]
        public class CustomTopic<A, B, C, D, E> : CustomTopicBase
        {
            public CustomDelegate<A, B, C, D, E> topicDelegate;

            public CustomTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static void EmptyFunction<F, G, H, I, L>(F _empty1, G _empty2, H _empty3, I _empty4, L _empty5) { }
        }

        #endregion

        #region Parameters Topic Custom Value Functions

        [Serializable]
        public class CustomFunctionTopic<TResult> : CustomTopicBase
        {
            public CustomFunction<TResult> topicDelegate;

            public CustomFunctionTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static TResult EmptyFunction()
            {
                return default(TResult);
            }
        }

        [Serializable]
        public class CustomFunctionTopic<TResult, A> : CustomTopicBase
        {
            public CustomFunction<TResult, A> topicDelegate;

            public CustomFunctionTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static TResult EmptyFunction<Z>(Z _param1)
            {
                return default(TResult);
            }
        }

        [Serializable]
        public class CustomFunctionTopic<TResult, A, B> : CustomTopicBase
        {
            public CustomFunction<TResult, A, B> topicDelegate;

            public CustomFunctionTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static TResult EmptyFunction<Z, W>(Z _param1, W _param2)
            {
                return default(TResult);
            }
        }

        [Serializable]
        public class CustomFunctionTopic<TResult, A, B, C> : CustomTopicBase
        {
            public CustomFunction<TResult, A, B, C> topicDelegate;

            public CustomFunctionTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static TResult EmptyFunction<Z, W, X>(Z _param1, W _param2, X _param3)
            {
                return default(TResult);
            }
        }

        [Serializable]
        public class CustomFunctionTopic<TResult, A, B, C, D> : CustomTopicBase
        {
            public CustomFunction<TResult, A, B, C, D> topicDelegate;

            public CustomFunctionTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static TResult EmptyFunction<Z, X, W, U>(Z _param1, X _param2, W _param3, U _param4)
            {
                return default(TResult);
            }
        }

        [Serializable]
        public class CustomFunctionTopic<TResult, A, B, C, D, E> : CustomTopicBase
        {
            public CustomFunction<TResult, A, B, C, D, E> topicDelegate;

            public CustomFunctionTopic()
            {
                topicDelegate = EmptyFunction;
            }

            private static TResult EmptyFunction<Z, X, W, U, V>(Z _param1, X _param2, W _param3, U _param4, V _param5)
            {
                return default(TResult);
            }
        }

        #endregion

        #region AddEvent Overloads

        public void AddEvent(Enum _topicName, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName.ToString())) == null)
            {
                CustomTopic newTopic = new CustomTopic { topicName = _topicName.ToString() };
                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName.ToString());

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);
                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.ToString() == _topicName.ToString()));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<A>(Enum _topicName, TopicType _topicType = TopicType.Event, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName.ToString())) == null)
            {
                CustomTopicBase newTopic;

                if (_topicType == TopicType.Event)
                {
                    CustomTopic<A> eventTypeTopic = new CustomTopic<A> { topicName = _topicName.ToString() };
                    newTopic = eventTypeTopic;
                }
                else
                {
                    CustomFunctionTopic<A> functionTypeTopic = new CustomFunctionTopic<A> { topicName = _topicName.ToString() };
                    newTopic = functionTypeTopic;
                }

                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName.ToString());

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);
                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.ToString() == _topicName.ToString()));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<A, B>(Enum _topicName, TopicType _topicType = TopicType.Event, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName.ToString())) == null)
            {
                CustomTopicBase newTopic;

                if (_topicType == TopicType.Event)
                {
                    CustomTopic<A, B> eventTypeTopic = new CustomTopic<A, B> { topicName = _topicName.ToString() };
                    newTopic = eventTypeTopic;
                }
                else
                {
                    CustomFunctionTopic<A, B> functionTypeTopic = new CustomFunctionTopic<A, B> { topicName = _topicName.ToString() };
                    newTopic = functionTypeTopic;
                }

                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName.ToString());

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);
                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.ToString() == _topicName.ToString()));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<A, B, C>(Enum _topicName, TopicType _topicType = TopicType.Event, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName.ToString())) == null)
            {
                CustomTopicBase newTopic;

                if (_topicType == TopicType.Event)
                {
                    CustomTopic<A, B, C> eventTypeTopic = new CustomTopic<A, B, C> { topicName = _topicName.ToString() };
                    newTopic = eventTypeTopic;
                }
                else
                {
                    CustomFunctionTopic<A, B, C> functionTypeTopic = new CustomFunctionTopic<A, B, C> { topicName = _topicName.ToString() };
                    newTopic = functionTypeTopic;
                }

                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName.ToString());

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);
                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.ToString() == _topicName.ToString()));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<A, B, C, D>(Enum _topicName, TopicType _topicType = TopicType.Event, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName.ToString())) == null)
            {
                CustomTopicBase newTopic;

                if (_topicType == TopicType.Event)
                {
                    CustomTopic<A, B, C, D> eventTypeTopic = new CustomTopic<A, B, C, D> { topicName = _topicName.ToString() };
                    newTopic = eventTypeTopic;
                }
                else
                {
                    CustomFunctionTopic<A, B, C, D> functionTypeTopic = new CustomFunctionTopic<A, B, C, D> { topicName = _topicName.ToString() };
                    newTopic = functionTypeTopic;
                }

                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName.ToString());

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);
                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.ToString() == _topicName.ToString()));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<A, B, C, D, E>(Enum _topicName, TopicType _topicType = TopicType.Event, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName.ToString())) == null)
            {
                CustomTopicBase newTopic;

                if (_topicType == TopicType.Event)
                {
                    CustomTopic<A, B, C, D, E> eventTypeTopic = new CustomTopic<A, B, C, D, E> { topicName = _topicName.ToString() };
                    newTopic = eventTypeTopic;
                }
                else
                {
                    CustomFunctionTopic<A, B, C, D, E> functionTypeTopic = new CustomFunctionTopic<A, B, C, D, E> { topicName = _topicName.ToString() };
                    newTopic = functionTypeTopic;
                }

                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName.ToString());

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);
                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.ToString() == _topicName.ToString()));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<TResult, A, B, C, D, E>(Enum _topicName, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName.ToString())) == null)
            {
                CustomTopicBase newTopic;

                CustomFunctionTopic<TResult, A, B, C, D, E> functionTypeTopic = new CustomFunctionTopic<TResult, A, B, C, D, E> { topicName = _topicName.ToString() };
                newTopic = functionTypeTopic;


                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName.ToString());

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);
                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.ToString() == _topicName.ToString()));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        #endregion

        #region AddListener Overloads

        public void AddListener(Enum _topicName, CustomDelegate _function)
        {
            CustomTopic topicToFind = (CustomTopic)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<A>(Enum _topicName, CustomDelegate<A> _function)
        {
            CustomTopic<A> topicToFind = (CustomTopic<A>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<A, B>(Enum _topicName, CustomDelegate<A, B> _function)
        {
            CustomTopic<A, B> topicToFind = (CustomTopic<A, B>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<A, B, C>(Enum _topicName, CustomDelegate<A, B, C> _function)
        {
            CustomTopic<A, B, C> topicToFind = (CustomTopic<A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<A, B, C, D>(Enum _topicName, CustomDelegate<A, B, C, D> _function)
        {
            CustomTopic<A, B, C, D> topicToFind = (CustomTopic<A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<A, B, C, D, E>(Enum _topicName, CustomDelegate<A, B, C, D, E> _function)
        {
            CustomTopic<A, B, C, D, E> topicToFind = (CustomTopic<A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult>(Enum _topicName, CustomFunction<TResult> _function)
        {
            CustomFunctionTopic<TResult> topicToFind = (CustomFunctionTopic<TResult>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult, A>(Enum _topicName, CustomFunction<TResult, A> _function)
        {
            CustomFunctionTopic<TResult, A> topicToFind = (CustomFunctionTopic<TResult, A>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult, A, B>(Enum _topicName, CustomFunction<TResult, A, B> _function)
        {
            CustomFunctionTopic<TResult, A, B> topicToFind = (CustomFunctionTopic<TResult, A, B>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult, A, B, C>(Enum _topicName, CustomFunction<TResult, A, B, C> _function)
        {
            CustomFunctionTopic<TResult, A, B, C> topicToFind = (CustomFunctionTopic<TResult, A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult, A, B, C, D>(Enum _topicName, CustomFunction<TResult, A, B, C, D> _function)
        {
            CustomFunctionTopic<TResult, A, B, C, D> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult, A, B, C, D, E>(Enum _topicName, CustomFunction<TResult, A, B, C, D, E> _function)
        {
            CustomFunctionTopic<TResult, A, B, C, D, E> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName.ToString(), _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
                });
            }
        }

        #endregion

        #region RemoveListener Overloads

        public void RemoveListener(Enum _topicName, CustomDelegate _function)
        {
            CustomTopic topicToFind = (CustomTopic)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<A>(Enum _topicName, CustomDelegate<A> _function)
        {
            CustomTopic<A> topicToFind = (CustomTopic<A>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<A, B>(Enum _topicName, CustomDelegate<A, B> _function)
        {
            CustomTopic<A, B> topicToFind = (CustomTopic<A, B>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<A, B, C>(Enum _topicName, CustomDelegate<A, B, C> _function)
        {
            CustomTopic<A, B, C> topicToFind = (CustomTopic<A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<A, B, C, D>(Enum _topicName, CustomDelegate<A, B, C, D> _function)
        {
            CustomTopic<A, B, C, D> topicToFind = (CustomTopic<A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<A, B, C, D, E>(Enum _topicName, CustomDelegate<A, B, C, D, E> _function)
        {
            CustomTopic<A, B, C, D, E> topicToFind = (CustomTopic<A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<TResult>(Enum _topicName, CustomFunction<TResult> _function)
        {
            CustomFunctionTopic<TResult> topicToFind = (CustomFunctionTopic<TResult>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<TResult, A>(Enum _topicName, CustomFunction<TResult, A> _function)
        {
            CustomFunctionTopic<TResult, A> topicToFind = (CustomFunctionTopic<TResult, A>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<TResult, A, B>(Enum _topicName, CustomFunction<TResult, A, B> _function)
        {
            CustomFunctionTopic<TResult, A, B> topicToFind = (CustomFunctionTopic<TResult, A, B>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<TResult, A, B, C>(Enum _topicName, CustomFunction<TResult, A, B, C> _function)
        {
            CustomFunctionTopic<TResult, A, B, C> topicToFind = (CustomFunctionTopic<TResult, A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<TResult, A, B, C, D>(Enum _topicName, CustomFunction<TResult, A, B, C, D> _function)
        {
            CustomFunctionTopic<TResult, A, B, C, D> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        public void RemoveListener<TResult, A, B, C, D, E>(Enum _topicName, CustomFunction<TResult, A, B, C, D, E> _function)
        {
            CustomFunctionTopic<TResult, A, B, C, D, E> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName.ToString(), _function.Method.Name);
        }

        #endregion

        #region Invoke Overloads

        public void Invoke(Enum _topicName)
        {
            CustomTopic topicToFind = (CustomTopic)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            topicToFind.topicDelegate();
        }

        public void Invoke<A>(Enum _topicName, A _typeValue)
        {
            CustomTopic<A> topicToFind = (CustomTopic<A>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            topicToFind.topicDelegate(_typeValue);
        }

        public void Invoke<A, B>(Enum _topicName, A _typeValue, B _typeValue2)
        {
            CustomTopic<A, B> topicToFind = (CustomTopic<A, B>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            topicToFind.topicDelegate(_typeValue, _typeValue2);
        }

        public void Invoke<A, B, C>(Enum _topicName, A _typeValue, B _typeValue2, C _typeValue3)
        {
            CustomTopic<A, B, C> topicToFind = (CustomTopic<A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3);
        }

        public void Invoke<A, B, C, D>(Enum _topicName, A _typeValue, B _typeValue2, C _typeValue3, D _typeValue4)
        {
            CustomTopic<A, B, C, D> topicToFind = (CustomTopic<A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3, _typeValue4);
        }

        public void Invoke<A, B, C, D, E>(Enum _topicName, A _typeValue, B _typeValue2, C _typeValue3, D _typeValue4, E _typeValue5)
        {
            CustomTopic<A, B, C, D, E> topicToFind = (CustomTopic<A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3, _typeValue4, _typeValue5);
        }

        public TResult Invoke<TResult>(Enum _topicName)
        {
            CustomFunctionTopic<TResult> topicToFind = (CustomFunctionTopic<TResult>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            return topicToFind.topicDelegate();
        }

        public TResult Invoke<TResult, A>(Enum _topicName, A _typeValue)
        {
            CustomFunctionTopic<TResult, A> topicToFind = (CustomFunctionTopic<TResult, A>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            return topicToFind.topicDelegate(_typeValue);
        }

        public TResult Invoke<TResult, A, B>(Enum _topicName, A _typeValue, B _typeValue2)
        {
            CustomFunctionTopic<TResult, A, B> topicToFind = (CustomFunctionTopic<TResult, A, B>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            return topicToFind.topicDelegate(_typeValue, _typeValue2);
        }

        public TResult Invoke<TResult, A, B, C>(Enum _topicName, A _typeValue, B _typeValue2, C _typeValue3)
        {
            CustomFunctionTopic<TResult, A, B, C> topicToFind = (CustomFunctionTopic<TResult, A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            return topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3);
        }

        public TResult Invoke<TResult, A, B, C, D>(Enum _topicName, A _typeValue, B _typeValue2, C _typeValue3, D _typeValue4)
        {
            CustomFunctionTopic<TResult, A, B, C, D> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            return topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3, _typeValue4);
        }

        public TResult Invoke<TResult, A, B, C, D, E>(Enum _topicName, A _typeValue, B _typeValue2, C _typeValue3, D _typeValue4, E _typeValue5)
        {
            CustomFunctionTopic<TResult, A, B, C, D, E> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName.ToString()));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName.ToString());
            return topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3, _typeValue4, _typeValue5);
        }

        #endregion



        #region AddEvent Overloads

        public void AddEvent(string _topicName, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName)) == null)
            {
                CustomTopic newTopic = new CustomTopic { topicName = _topicName };
                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName);

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);

                        if (topicsDebug.Find(x => x.topicName.Equals(_topicName)) == null)
                        {
                            if (debugMode)
                                Debug.Log("Topic to remove on Scene Change not found in Debug List");
                            return;
                        }

                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.Equals(_topicName)));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<A>(string _topicName, TopicType _topicType = TopicType.Event, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName)) == null)
            {
                CustomTopicBase newTopic;

                if (_topicType == TopicType.Event)
                {
                    CustomTopic<A> eventTypeTopic = new CustomTopic<A> { topicName = _topicName };
                    newTopic = eventTypeTopic;
                }
                else
                {
                    CustomFunctionTopic<A> functionTypeTopic = new CustomFunctionTopic<A> { topicName = _topicName };
                    newTopic = functionTypeTopic;
                }

                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName);

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);

                        if (topicsDebug.Find(x => x.topicName.Equals(_topicName)) == null)
                        {
                            if (debugMode)
                                Debug.Log("Topic to remove on Scene Change not found in Debug List");
                            return;
                        }

                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.Equals(_topicName)));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<A, B>(string _topicName, TopicType _topicType = TopicType.Event, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName)) == null)
            {
                CustomTopicBase newTopic;

                if (_topicType == TopicType.Event)
                {
                    CustomTopic<A, B> eventTypeTopic = new CustomTopic<A, B> { topicName = _topicName };
                    newTopic = eventTypeTopic;
                }
                else
                {
                    CustomFunctionTopic<A, B> functionTypeTopic = new CustomFunctionTopic<A, B> { topicName = _topicName };
                    newTopic = functionTypeTopic;
                }

                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName);

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);

                        if (topicsDebug.Find(x => x.topicName.Equals(_topicName)) == null)
                        {
                            if (debugMode)
                                Debug.Log("Topic to remove on Scene Change not found in Debug List");
                            return;
                        }

                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.Equals(_topicName)));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<A, B, C>(string _topicName, TopicType _topicType = TopicType.Event, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName)) == null)
            {
                CustomTopicBase newTopic;

                if (_topicType == TopicType.Event)
                {
                    CustomTopic<A, B, C> eventTypeTopic = new CustomTopic<A, B, C> { topicName = _topicName };
                    newTopic = eventTypeTopic;
                }
                else
                {
                    CustomFunctionTopic<A, B, C> functionTypeTopic = new CustomFunctionTopic<A, B, C> { topicName = _topicName };
                    newTopic = functionTypeTopic;
                }

                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName);

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);

                        if (topicsDebug.Find(x => x.topicName.Equals(_topicName)) == null)
                        {
                            if (debugMode)
                                Debug.Log("Topic to remove on Scene Change not found in Debug List");
                            return;
                        }

                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.Equals(_topicName)));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<A, B, C, D>(string _topicName, TopicType _topicType = TopicType.Event, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName)) == null)
            {
                CustomTopicBase newTopic;

                if (_topicType == TopicType.Event)
                {
                    CustomTopic<A, B, C, D> eventTypeTopic = new CustomTopic<A, B, C, D> { topicName = _topicName };
                    newTopic = eventTypeTopic;
                }
                else
                {
                    CustomFunctionTopic<A, B, C, D> functionTypeTopic = new CustomFunctionTopic<A, B, C, D> { topicName = _topicName };
                    newTopic = functionTypeTopic;
                }

                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName);

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);

                        if (topicsDebug.Find(x => x.topicName.Equals(_topicName)) == null)
                        {
                            if (debugMode)
                                Debug.Log("Topic to remove on Scene Change not found in Debug List");
                            return;
                        }

                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.Equals(_topicName)));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<A, B, C, D, E>(string _topicName, TopicType _topicType = TopicType.Event, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName)) == null)
            {
                CustomTopicBase newTopic;

                if (_topicType == TopicType.Event)
                {
                    CustomTopic<A, B, C, D, E> eventTypeTopic = new CustomTopic<A, B, C, D, E> { topicName = _topicName };
                    newTopic = eventTypeTopic;
                }
                else
                {
                    CustomFunctionTopic<A, B, C, D, E> functionTypeTopic = new CustomFunctionTopic<A, B, C, D, E> { topicName = _topicName };
                    newTopic = functionTypeTopic;
                }

                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName);

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);

                        if (topicsDebug.Find(x => x.topicName.Equals(_topicName)) == null)
                        {
                            if (debugMode)
                                Debug.Log("Topic to remove on Scene Change not found in Debug List");
                            return;
                        }

                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.Equals(_topicName)));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        public void AddEvent<TResult, A, B, C, D, E>(string _topicName, bool _toBeRemoved = false)
        {
            if (topicsList.Find(x => x.topicName.Equals(_topicName)) == null)
            {
                CustomTopicBase newTopic;

                CustomFunctionTopic<TResult, A, B, C, D, E> functionTypeTopic = new CustomFunctionTopic<TResult, A, B, C, D, E> { topicName = _topicName };
                newTopic = functionTypeTopic;


                topicsList.Add(newTopic);
                EventManagerDebug.AddEvent(_topicName);

                if (_toBeRemoved)
                {
                    instance.AddListener(InternalTopics.RemoveTopics, () =>
                    {
                        topicsList.Remove(newTopic);

                        if (topicsDebug.Find(x => x.topicName.Equals(_topicName)) == null)
                        {
                            if (debugMode)
                                Debug.Log("Topic to remove on Scene Change not found in Debug List");
                            return;
                        }

                        topicsDebug.Remove(topicsDebug.Find(x => x.topicName.Equals(_topicName)));
                    });
                }
            }
            else
            {
                if (debugMode)
                    Debug.Log("Topic with name: " + _topicName + " already registered\n");
            }
        }

        #endregion

        #region AddListener Overloads

        public void AddListener(string _topicName, CustomDelegate _function)
        {
            CustomTopic topicToFind = (CustomTopic)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<A>(string _topicName, CustomDelegate<A> _function)
        {
            CustomTopic<A> topicToFind = (CustomTopic<A>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<A, B>(string _topicName, CustomDelegate<A, B> _function)
        {
            CustomTopic<A, B> topicToFind = (CustomTopic<A, B>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<A, B, C>(string _topicName, CustomDelegate<A, B, C> _function)
        {
            CustomTopic<A, B, C> topicToFind = (CustomTopic<A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<A, B, C, D>(string _topicName, CustomDelegate<A, B, C, D> _function)
        {
            CustomTopic<A, B, C, D> topicToFind = (CustomTopic<A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<A, B, C, D, E>(string _topicName, CustomDelegate<A, B, C, D, E> _function)
        {
            CustomTopic<A, B, C, D, E> topicToFind = (CustomTopic<A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult>(string _topicName, CustomFunction<TResult> _function)
        {
            CustomFunctionTopic<TResult> topicToFind = (CustomFunctionTopic<TResult>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult, A>(string _topicName, CustomFunction<TResult, A> _function)
        {
            CustomFunctionTopic<TResult, A> topicToFind = (CustomFunctionTopic<TResult, A>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult, A, B>(string _topicName, CustomFunction<TResult, A, B> _function)
        {
            CustomFunctionTopic<TResult, A, B> topicToFind = (CustomFunctionTopic<TResult, A, B>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult, A, B, C>(string _topicName, CustomFunction<TResult, A, B, C> _function)
        {
            CustomFunctionTopic<TResult, A, B, C> topicToFind = (CustomFunctionTopic<TResult, A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult, A, B, C, D>(string _topicName, CustomFunction<TResult, A, B, C, D> _function)
        {
            CustomFunctionTopic<TResult, A, B, C, D> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        public void AddListener<TResult, A, B, C, D, E>(string _topicName, CustomFunction<TResult, A, B, C, D, E> _function)
        {
            CustomFunctionTopic<TResult, A, B, C, D, E> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Add: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Add: " + _function.Method.Name + " to this topic: " + _topicName + " already registered\n");
                return;
            }

            topicToFind.topicDelegate += _function;
            EventManagerDebug.AddListener(_topicName, _function.Method.Name, _function.Target);

            object targetObject = _function.Target;

            var targetMono = targetObject as MonoBehaviour;

            if (targetMono == null)
                return;

            bool isDoNotDestroyItself = targetMono.GetComponent<DoNotDestroy>();
            bool hasParent = targetMono.gameObject.transform.parent != null;

            if (!isDoNotDestroyItself && (hasParent && !targetMono.gameObject.transform.parent.GetComponent<DoNotDestroy>() || !hasParent))
            {
                instance.AddListener(InternalTopics.RemoveListenersFromTopics, () =>
                {
                    instance.RemoveListener(_topicName, _function);
                    EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
                });
            }
        }

        #endregion

        #region RemoveListener Overloads

        public void RemoveListener(string _topicName, CustomDelegate _function)
        {
            CustomTopic topicToFind = (CustomTopic)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<A>(string _topicName, CustomDelegate<A> _function)
        {
            CustomTopic<A> topicToFind = (CustomTopic<A>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<A, B>(string _topicName, CustomDelegate<A, B> _function)
        {
            CustomTopic<A, B> topicToFind = (CustomTopic<A, B>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<A, B, C>(string _topicName, CustomDelegate<A, B, C> _function)
        {
            CustomTopic<A, B, C> topicToFind = (CustomTopic<A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<A, B, C, D>(string _topicName, CustomDelegate<A, B, C, D> _function)
        {
            CustomTopic<A, B, C, D> topicToFind = (CustomTopic<A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<A, B, C, D, E>(string _topicName, CustomDelegate<A, B, C, D, E> _function)
        {
            CustomTopic<A, B, C, D, E> topicToFind = (CustomTopic<A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<TResult>(string _topicName, CustomFunction<TResult> _function)
        {
            CustomFunctionTopic<TResult> topicToFind = (CustomFunctionTopic<TResult>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<TResult, A>(string _topicName, CustomFunction<TResult, A> _function)
        {
            CustomFunctionTopic<TResult, A> topicToFind = (CustomFunctionTopic<TResult, A>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<TResult, A, B>(string _topicName, CustomFunction<TResult, A, B> _function)
        {
            CustomFunctionTopic<TResult, A, B> topicToFind = (CustomFunctionTopic<TResult, A, B>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<TResult, A, B, C>(string _topicName, CustomFunction<TResult, A, B, C> _function)
        {
            CustomFunctionTopic<TResult, A, B, C> topicToFind = (CustomFunctionTopic<TResult, A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<TResult, A, B, C, D>(string _topicName, CustomFunction<TResult, A, B, C, D> _function)
        {
            CustomFunctionTopic<TResult, A, B, C, D> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        public void RemoveListener<TResult, A, B, C, D, E>(string _topicName, CustomFunction<TResult, A, B, C, D, E> _function)
        {
            CustomFunctionTopic<TResult, A, B, C, D, E> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic not found for the Listener to Remove: " + _function.Method.Name + " with this topic: " + _topicName + "\n");
                return;
            }

            if (!ListenerExists(topicToFind.topicDelegate.GetInvocationList(), _function.Target, _function.Method.Name))
            {
                if (debugMode)
                    Debug.Log("Listener to Remove: " + _function.Method.Name + " to this topic: " + _topicName + " not found\n");
                return;
            }

            topicToFind.topicDelegate -= _function;
            EventManagerDebug.RemoveListener(_topicName, _function.Method.Name);
        }

        #endregion

        #region Invoke Overloads

        public void Invoke(string _topicName)
        {
            CustomTopic topicToFind = (CustomTopic)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName);
            topicToFind.topicDelegate();
        }

        public void Invoke<A>(string _topicName, A _typeValue)
        {
            CustomTopic<A> topicToFind = (CustomTopic<A>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName);
            topicToFind.topicDelegate(_typeValue);
        }

        public void Invoke<A, B>(string _topicName, A _typeValue, B _typeValue2)
        {
            CustomTopic<A, B> topicToFind = (CustomTopic<A, B>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName);
            topicToFind.topicDelegate(_typeValue, _typeValue2);
        }

        public void Invoke<A, B, C>(string _topicName, A _typeValue, B _typeValue2, C _typeValue3)
        {
            CustomTopic<A, B, C> topicToFind = (CustomTopic<A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName);
            topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3);
        }

        public void Invoke<A, B, C, D>(string _topicName, A _typeValue, B _typeValue2, C _typeValue3, D _typeValue4)
        {
            CustomTopic<A, B, C, D> topicToFind = (CustomTopic<A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName);
            topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3, _typeValue4);
        }

        public void Invoke<A, B, C, D, E>(string _topicName, A _typeValue, B _typeValue2, C _typeValue3, D _typeValue4, E _typeValue5)
        {
            CustomTopic<A, B, C, D, E> topicToFind = (CustomTopic<A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return;
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return;
            }

            EventManagerDebug.Invoke(_topicName);
            topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3, _typeValue4, _typeValue5);
        }

        public TResult Invoke<TResult>(string _topicName)
        {
            CustomFunctionTopic<TResult> topicToFind = (CustomFunctionTopic<TResult>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName);
            return topicToFind.topicDelegate();
        }

        public TResult Invoke<TResult, A>(string _topicName, A _typeValue)
        {
            CustomFunctionTopic<TResult, A> topicToFind = (CustomFunctionTopic<TResult, A>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName);
            return topicToFind.topicDelegate(_typeValue);
        }

        public TResult Invoke<TResult, A, B>(string _topicName, A _typeValue, B _typeValue2)
        {
            CustomFunctionTopic<TResult, A, B> topicToFind = (CustomFunctionTopic<TResult, A, B>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName);
            return topicToFind.topicDelegate(_typeValue, _typeValue2);
        }

        public TResult Invoke<TResult, A, B, C>(string _topicName, A _typeValue, B _typeValue2, C _typeValue3)
        {
            CustomFunctionTopic<TResult, A, B, C> topicToFind = (CustomFunctionTopic<TResult, A, B, C>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName);
            return topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3);
        }

        public TResult Invoke<TResult, A, B, C, D>(string _topicName, A _typeValue, B _typeValue2, C _typeValue3, D _typeValue4)
        {
            CustomFunctionTopic<TResult, A, B, C, D> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName);
            return topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3, _typeValue4);
        }

        public TResult Invoke<TResult, A, B, C, D, E>(string _topicName, A _typeValue, B _typeValue2, C _typeValue3, D _typeValue4, E _typeValue5)
        {
            CustomFunctionTopic<TResult, A, B, C, D, E> topicToFind = (CustomFunctionTopic<TResult, A, B, C, D, E>)topicsList.Find(x => x.topicName.Equals(_topicName));

            if (topicToFind == null)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " not found, cannot invoke it\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length <= 0)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found there is a serious problem with delegate structure since\nInvocation Length is: " + topicToFind.topicDelegate.GetInvocationList().Length + "\n");
                return default(TResult);
            }

            if (topicToFind.topicDelegate.GetInvocationList().Length == 1)
            {
                if (debugMode)
                    Debug.Log("Topic: " + _topicName + " found but no delegates attached\n");
                return default(TResult);
            }

            EventManagerDebug.Invoke(_topicName);
            return topicToFind.topicDelegate(_typeValue, _typeValue2, _typeValue3, _typeValue4, _typeValue5);
        }

        #endregion

        #region Debug Handler

        public List<Topic> topicsDebug;

        [Serializable]
        public class Topic
        {
            [HideInInspector]
            public string topicName;

            public string creator;

            public List<string> callers;

            public List<Function> functions;

            public Topic(string _topicName, string _creator)
            {
                topicName = _topicName;
                creator = _creator;

                callers = new List<string>();

                functions = new List<Function>();
            }
        }

        [Serializable]
        public class Function
        {
            public string functionName;
            public MonoBehaviour functionLink;

            public Function(string _functionName, MonoBehaviour _functionLink)
            {
                functionName = _functionName;
                functionLink = _functionLink;
            }
        }

        private static class EventManagerDebug
        {
            public static void AddEvent(string _topicName)
            {
                string creatorName = new StackFrame(2).GetMethod().DeclaringType.Name;
                instance.topicsDebug.Add(new Topic(_topicName, creatorName));
            }

            public static void AddListener(string _topicName, string _functionName, object _targetObject)
            {
                int index = instance.topicsDebug.FindIndex(x => x.topicName.Equals(_topicName));

                var targetMono = _targetObject as MonoBehaviour;

                instance.topicsDebug[index].functions.Add(new Function(_functionName, targetMono));

            }

            public static void RemoveListener(string _topicName, string _functionName)
            {
                int index = instance.topicsDebug.FindIndex(x => x.topicName.Equals(_topicName));
                instance.topicsDebug[index].functions.Remove(instance.topicsDebug[index].functions.Find(x => x.functionName == _functionName));
            }

            public static void Invoke(string _nameEvent)
            {
                var declaringType = new StackFrame(2).GetMethod().DeclaringType;
                if (declaringType != null)
                {
                    string callerName = declaringType.Name;

                    int index = instance.topicsDebug.FindIndex(x => x.topicName.Equals(_nameEvent));
                    instance.topicsDebug[index].callers.Add(callerName);
                }
            }
        }

        #endregion
    }

    public enum InternalTopics
    {
        RemoveTopics,
        RemoveListenersFromTopics,
    }
}