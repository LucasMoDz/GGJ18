using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Package.CustomLibrary
{
    ///<summary> Provides tested functions for UI. </summary>
    public class UtilitiesUI
    {
        public const float SPEED_TIME_CHAR_TYPEWRITER = 0.025f;

        #region Private Singleton

        private static Implementation.UtilitiesUI _instance;

        private static Implementation.UtilitiesUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Object.FindObjectOfType<Implementation.UtilitiesUI>();

                    if (Application.isPlaying)
                    {
                        EventManager.EventManager.AddEvent(TopicName.LibraryUIGarbageCollector);
                        EventManager.EventManager.AddListener(TopicName.LibraryUIGarbageCollector, _instance.GarbageCollector);
                    }
                }

                return _instance;
            }
        }

        #endregion

        #region Object Activation Methods

        /// <summary> Fade/Activate an image component. </summary>
        /// <param name="_object"> Gameobject with image component. </param>
        /// <param name="_timeFadeIn"> If not put, image will be activated and not faded. </param>
        /// <param name="_time"> Wait time after fade in and before fade out. </param>
        /// <param name="_timeFadeOut"> If not put, image will be deactivated and not faded. </param>
        public static Coroutine ObjectActivation(GameObject _object, float _timeFadeIn = 0, float _time = 0, float _timeFadeOut = 0)
        {
            return Instance.ObjectActivation(_object, _timeFadeIn, _time, _timeFadeOut);
        }

        /// <summary> Fade/Activate an image component. </summary>
        /// <param name="_canvasRef"> Canvasgroup component. </param>
        /// <param name="_timeFadeIn"> If not put, image will be activated and not faded. </param>
        /// <param name="_time"> Wait time after fade in and before fade out. </param>
        /// <param name="_timeFadeOut"> If not put, image will be deactivated and not faded. </param>
        public static Coroutine ObjectActivation(CanvasGroup _canvasRef, float _timeFadeIn = 0, float _time = 0, float _timeFadeOut = 0)
        {
            return Instance.ObjectActivation(_canvasRef, _timeFadeIn, _time, _timeFadeOut);
        }

        /// <summary> Fade/Activate an image component. </summary>
        /// <param name="_canvasRef"> Canvasgroup component. </param>
        /// <param name="_maxAlpha"> Maximum Alpha that can be reached. </param>
        /// <param name="_timeFadeIn"> If not put, image will be activated and not faded. </param>
        /// <param name="_time"> Wait time after fade in and before fade out. </param>
        /// <param name="_timeFadeOut"> If not put, image will be deactivated and not faded. </param>
        /// <param name="_minAlpha"> Minimum Alpha that can be reached. </param>
        public static Coroutine ObjectEnhancedActivation(CanvasGroup _canvasRef, float _maxAlpha = 1, float _timeFadeIn = 0, float _time = 0, float _timeFadeOut = 0, float _minAlpha = 0)
        {
            return Instance.ObjectActivation(_canvasRef, _maxAlpha, _timeFadeIn, _time, _timeFadeOut, _minAlpha);
        }

        #endregion

        #region Object DeActivation Methods

        public static Coroutine ObjectDeactivation(GameObject _object, float _time = 0, float _timeFadeOut = 0)
        {
            return Instance.ObjectDeactivation(_object, _time, _timeFadeOut);
        }

        public static Coroutine ObjectDeactivation(CanvasGroup _canvasRef, float _time = 0, float _timeFadeOut = 0)
        {
            return Instance.ObjectDeactivation(_canvasRef, _time, _timeFadeOut);
        }

        public static Coroutine ObjectEnhancedDeactivation(CanvasGroup _canvasRef, float _maxAlpha = 1, float _time = 0, float _timeFadeOut = 0, float _minAlpha = 0)
        {
            return Instance.ObjectDeactivation(_canvasRef, _maxAlpha, _time, _timeFadeOut, _minAlpha);
        }
        #endregion

        #region Object Moving Methods

        /// <summary> Move UI GameObject to target point. </summary>
        /// <param name="_object"> GameObject to move. </param>
        /// <param name="_targetPoint"> GameObject target. </param>
        /// <param name="_totalTime"> Total movement time. </param>
        /// <param name="_startPoint"> GameObject where to start movement. </param>
        public static Coroutine ObjectMoving(GameObject _object, GameObject _targetPoint, float _totalTime = 0, GameObject _startPoint = null)
        {
            return Instance.ObjectMoving(_object, _targetPoint, _totalTime, _startPoint);
        }


        /// <summary> Move UI GameObject to target point. </summary>
        /// <param name="_object"> GameObject to move. </param>
        /// <param name="_targetPoint"> GameObject target. </param>
        /// <param name="_totalTime"> Total movement time. </param>
        /// <param name="_startPoint"> GameObject where to start movement. </param>
        public static Coroutine ObjectMoving(GameObject _object, Vector3 _targetPoint, float _totalTime = 0, GameObject _startPoint = null)
        {
            return Instance.ObjectMoving(_object, _targetPoint, _totalTime, _startPoint);
        }

        #endregion

        #region Object Scaling in

        public static Coroutine ObjectScalingIn(GameObject _object, float _timeScaleIn = 0, float _waitTime = 0, float _timeScaleOut = 0)
        {
            return Instance.ObjectScalingIn(_object, _timeScaleIn, _waitTime, _timeScaleOut);
        }

        public static Coroutine ObjectEnhancedScalingIn(GameObject _object, float _maxScale = 1, float _timeScaleIn = 0, float _waitTime = 0, float _timeScaleOut = 0, float _minScale = 0)
        {
            return Instance.ObjectScalingIn(_object, _maxScale, _timeScaleIn, _waitTime, _timeScaleOut, _minScale);
        }

        #endregion

        #region Object Scaling Out

        public static Coroutine ObjectScalingOut(GameObject _object, float _waitTime = 0, float _timeScaleOut = 0)
        {
            return Instance.ObjectScalingOut(_object, _waitTime, _timeScaleOut);
        }

        public static Coroutine ObjectEnhancedScalingOut(GameObject _object, float _maxScale = 1, float _waitTime = 0, float _timeScaleOut = 0, float _minScale = 0)
        {
            return Instance.ObjectScalingOut(_object, _maxScale, _waitTime, _timeScaleOut, _minScale);
        }

        #endregion

        #region Scale Effect

        /// <summary>Animation scale for the given Gameobject </summary>
        /// <param name="_scaleCurve">Gameobject scale in base of AnimationCurve</param>
        /// <param name="_gameObject">Which gameobject will be affected</param>
        /// <param name="_duration">The duration of animation </param>
        public static Coroutine ScaleWithCurve(AnimationCurve _scaleCurve, GameObject _gameObject, float _duration = 1)
        {
            return Instance.ScaleWithCurve(_scaleCurve, _gameObject, _duration);
        }

        /// <summary>Flip animation of a card</summary>
        /// <param name="_spriteTarget">Which sprite swap at the end of flip</param>
        /// <param name="_image">Image component to swap sprite</param>
        /// <param name="_duration">The duration of entire flip</param>
        /// <param name="_gameObject">Wich gameobject will be affected (default gameobject of image component)</param>
        public static Coroutine FlipCard(Sprite _spriteTarget, Image _image, float _duration = 1, GameObject _gameObject = null)
        {
            return Instance.FlipCard(_spriteTarget, _image, _duration, _gameObject);
        }

        /// <summary>Flip animation of a card two times</summary>
        /// <param name="_spriteTarget">Which sprite swap at the end of flip</param>
        /// <param name="_spriteMiddle">The first sprite swap of flip</param>
        /// <param name="_image">Image component to swap sprite</param>
        /// <param name="_duration">The duration of entire flip</param>
        /// <param name="_gameObject">Wich gameobject will be affected (default gameobject of image component)</param>
        /// <returns></returns>
        public static Coroutine DoubleFlipCard(Sprite _spriteTarget, Sprite _spriteMiddle, Image _image, float _duration = 1, GameObject _gameObject = null)
        {
            return Instance.DoubleFlipCard(_spriteTarget, _spriteMiddle, _image, _duration, _gameObject);
        }

        /// <summary> Scale UI gameobject with custom time, start and target value. </summary>
        /// <param name="_rect"> UI gameObject to be scaled. </param>
        /// <param name="_scaleTime"> Total scale time. </param>
        /// <param name="_startScale"> Vector3 start scale. </param>
        /// <param name="_targetScale"> Vector3 target scale. </param>
        /// <returns> Return scale coroutine. </returns>
        public static Coroutine ScaleObject(RectTransform _rect, float _scaleTime, Vector3 _startScale, Vector3 _targetScale)
        {
            return Instance.ScaleObject(_rect, _scaleTime, _startScale, _targetScale);
        }

        #endregion

        #region Smooth Variation Effect

        public static Coroutine SmoothVariation(Text _text, int _targetValue, float _speedMultiplier = 0.5f, int _maxValue = 1, int _minValue = 0)
        {
            return Instance.SmoothVariation(_text, _targetValue, _speedMultiplier, _maxValue, _minValue);
        }

        public static Coroutine SmoothVariation(Image _image, float _targetValue, float _speedMultiplier = 0.5f, float _maxValue = 1, float _minValue = 0)
        {
            return Instance.SmoothVariation(_image, _targetValue, _speedMultiplier, _maxValue, _minValue);
        }

        #endregion

        #region Blink Effect

        /// <summary> Blink alpha channel of image component. </summary>
        /// <param name="_image"> Image to be blinked. </param>
        /// <param name="_totalTime"> Total blink time. </param>
        /// <param name="_loopTime"> Time of a single loop. </param>
        /// <param name="_min"> Minimum alpha value. </param>
        /// <param name="_max"> Maximum alpha value. </param>
        public static Coroutine BlinkAlpha(Image _image, float _totalTime = Mathf.Infinity, float _loopTime = 1, float _min = 0, float _max = 1)
        {
            return Instance.BlinkAlpha(_image, _totalTime, _loopTime, _min, _max);
        }

        #endregion

        #region Blink Scale Effect

        public static Coroutine BlinkScaleSprite(GameObject _object, float _totalTime = Mathf.Infinity, float _loopTime = 1, float _min = 0.1f, float _max = 1)
        {
            return Instance.BlinkScaleSprite(_object, _totalTime, _loopTime, _min, _max);
        }

        #endregion

        #region Other Methods

        /// <summary> Enable interaction of one or more buttons. </summary>
        /// <param name="_buttons"> Buttons to be enabled interaction. </param>
        public static void EnableInteraction(params Button[] _buttons)
        {
            Instance.EnableInteraction(_buttons);
        }

        /// <summary> Disable interaction of one or more buttons. </summary>
        /// <param name="_buttons"> Buttons to be disabled interaction. </param>
        public static void DisableInteraction(params Button[] _buttons)
        {
            Instance.DisableInteraction(_buttons);
        }

        /// <summary> Enable interaction to parameters only, disabling others. </summary>
        /// <param name="_buttonsToKeepEnabled"> Buttons to keep enabled. </param>
        public static void AllowSpecificInteraction(params Button[] _buttonsToKeepEnabled)
        {
            Instance.AllowSpecificInteraction(_buttonsToKeepEnabled);
        }

        /// <summary> Lerp alpha channel of canvas group from current value to target parameter. </summary>
        /// <param name="_canvasGroup"> Canvas group to lerp alpha. </param>
        /// <param name="_targetAlpha"> Target value of canvas group alpha. </param>
        /// <param name="_time"> Lerp time form current alpha to target. </param>
        /// <param name="_blocksRaycasts"> Block raycasts when method is over. True to allow interaction, false to avoid it. </param>
        public static Coroutine LerpCanvasGroupAlpha(CanvasGroup _canvasGroup, float _targetAlpha, float _time = 0, bool _blocksRaycasts = true)
        {
            return Instance.LerpCanvasGroupAlpha(_canvasGroup, _targetAlpha, _time, _blocksRaycasts);
        }

        /// <summary> Set block raycasts of one or more canvas groups. </summary>
        /// <param name="_value"> True if you want allow interaction, false to avoid it. </param>
        /// <param name="_canvasGroups"></param>
        public static void BlocksRaycast(bool _value, params CanvasGroup[] _canvasGroups)
        {
            Instance.BlocksRaycast(_value, _canvasGroups);
        }

        /// <summary> Stop Coroutine variable. </summary>
        public static void StopUiCoroutine(Coroutine _coroutineToStop)
        {
            Instance.StopUiCoroutine(_coroutineToStop);
        }
        #endregion

        #region Fill Amount Image

        /// <summary> Fill an image in time needed. </summary>
        /// <param name="_image"> Image to fill. </param>
        /// <param name="_fillSeconds"> Total fill time. </param>
        /// <param name="_startValue"> Start value fill amount, default is 0. </param>
        /// <param name="_targetValue"> Target value fill amount, default is 1. </param>
        /// <returns> Return fill amount coroutine. </returns>
        public static Coroutine FillAmountImage(Image _image, float _fillSeconds, float _startValue = 0, float _targetValue = 1)
        {
            return Instance.FillAmountImage(_image, _fillSeconds, _startValue, _targetValue);
        }

        #endregion

        #region Text Methods

        public static Coroutine WriteTextInTypewriterStyle(Text _textComponent, string _text, float _speedFromCharAndOther, bool _canSkip = true)
        {
            return Instance.WriteTextInTypewriterStyle(_textComponent, _text, _speedFromCharAndOther, _canSkip);
        }

        #endregion
    }
}