using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections;
using Debug = UnityEngine.Debug;
using System.Collections.Generic;

namespace Package.CustomLibrary.Implementation
{
    public enum MethodRegion { Activation, Moving, Scale, SmoothVariationText, SmoothVariationImage }

    /// <summary> All methods implementation goes here </summary>
    public class UtilitiesUI : MonoBehaviour
    {
        public bool debugMode;

        #region Object Activation Methods

        public List<Container> listCoroutine = new List<Container>();

        [Serializable]
        public class Container
        {
            [HideInInspector]
            public string name;


            public int id;
            public MethodRegion region;
            public Coroutine coroutine;

            public Container(int _id, MethodRegion _region, Coroutine _coroutine)
            {
                id = _id;
                region = _region;
                coroutine = _coroutine;
            }
        }

        private void CheckCoroutineInList(GameObject _gameObject, MethodRegion _region)
        {
            List<Container> elementsById = listCoroutine.FindAll(container => container.id.Equals(_gameObject.transform.GetInstanceID()));
            Container elementToFind = elementsById.Find(container => container.region.Equals(_region));

            if (elementToFind != null && elementToFind.region.Equals(_region))
            {
                StopObjectCoroutine(_gameObject.transform.GetInstanceID(), _region);
                CoroutineDebugger.SearchConflict(_gameObject);
            }
        }

        private void StopObjectCoroutine(int _id, MethodRegion _region)
        {
            List<Container> elementsById = listCoroutine.FindAll(x => x.id == _id);
            Container elementToStop = elementsById.Find(x => x.region == _region);

            if (elementToStop != null)
            {
                if (elementToStop.coroutine != null)
                {
                    StopCoroutine(elementToStop.coroutine);
                    elementToStop.coroutine = null;
                }

                listCoroutine.Remove(elementToStop);
            }
        }

        public Coroutine ObjectActivation(GameObject _object, float _timeFadeIn, float _time, float _timeFadeOut)
        {
            CheckCoroutineInList(_object, MethodRegion.Activation);
            Coroutine objectActivationCo = StartCoroutine(ObjectActivationCO(_object, _timeFadeIn, _time, _timeFadeOut));
            listCoroutine.Add(new Container(_object.transform.GetInstanceID(), MethodRegion.Activation, objectActivationCo));
            return objectActivationCo;
        }

        private IEnumerator ObjectActivationCO(GameObject _object, float _timeFadeIn, float _time, float _timeFadeOut)
        {
            Image imTempLink = _object.GetComponent<Image>();

            if (imTempLink == null)
            {
                Debug.Log("There is no image component attached to gameobject");
                yield break;
            }

            Color coOriginal = imTempLink.color;

            if (!_object.activeSelf)
            {
                coOriginal.a = 0;
                imTempLink.color = coOriginal;
            }

            Color coTempCopy = imTempLink.color;

            _object.SetActive(true);

            if (_timeFadeIn.Equals(0))
            {
                coTempCopy.a = 1;
                imTempLink.color = coTempCopy;
            }
            else
            {
                float alphaDelta = 1f / (_timeFadeIn * (1 - coTempCopy.a));

                while (imTempLink.color.a < 1)
                {
                    coTempCopy.a += alphaDelta * Time.deltaTime;
                    imTempLink.color = coTempCopy;
                    yield return null;
                }
            }

            coTempCopy.a = 1;
            imTempLink.color = coTempCopy;

            if (_time > .1f)
                yield return new WaitForSecondsRealtime(_time);

            if (!_timeFadeOut.Equals(0))
            {
                float alphaDelta = 1f / _timeFadeOut;

                while (imTempLink.color.a > 0)
                {
                    coTempCopy.a -= alphaDelta * Time.deltaTime;
                    imTempLink.color = coTempCopy;
                    yield return null;
                }
            }

            if (!_time.Equals(0) || !_timeFadeOut.Equals(0))
            {
                _object.SetActive(false);
            }

            StopObjectCoroutine(_object.transform.GetInstanceID(), MethodRegion.Activation);
        }

        public Coroutine ObjectActivation(CanvasGroup _canvasRef, float _timeFadeIn, float _time, float _timeFadeOut)
        {

            //CheckCoroutineInList(_canvasRef.gameObject, MethodRegion.Activation);

            Coroutine objectActivationCoro = StartCoroutine(ObjectActivationCO(_canvasRef, _timeFadeIn, _time, _timeFadeOut));
            //listCoroutine.Add(new Container(_canvasRef.transform.GetInstanceID(), MethodRegion.Activation, objectActivationCoro));

            return objectActivationCoro;
        }

        private IEnumerator ObjectActivationCO(CanvasGroup _canvasRef, float _timeFadeIn, float _time, float _timeFadeOut)
        {
            if (_canvasRef == null)
            {
                Debug.Log("There is no image component attached to gameobject");
                yield break;
            }

            if (_timeFadeIn.Equals(0))
            {
                _canvasRef.alpha = 1;
                _canvasRef.blocksRaycasts = true;
                _canvasRef.interactable = true;
            }
            else
            {
                float alphaDelta = 1f / (_timeFadeIn * (1 - _canvasRef.alpha));

                while (_canvasRef.alpha < 1)
                {
                    _canvasRef.alpha += alphaDelta * Time.deltaTime;
                    yield return null;
                }
            }

            _canvasRef.alpha = 1;
            _canvasRef.blocksRaycasts = true;
            _canvasRef.interactable = true;

            if (_time > .1f)
                yield return new WaitForSecondsRealtime(_time);

            if (!_timeFadeOut.Equals(0))
            {
                float alphaDelta = 1f / _timeFadeOut;

                _canvasRef.blocksRaycasts = false;
                _canvasRef.interactable = false;

                while (_canvasRef.alpha > 0)
                {
                    _canvasRef.alpha -= alphaDelta * Time.deltaTime;
                    yield return null;
                }
            }

            if (!_time.Equals(0) || !_timeFadeOut.Equals(0))
            {
                _canvasRef.alpha = 0;
                _canvasRef.blocksRaycasts = false;
                _canvasRef.interactable = false;
            }

            StopObjectCoroutine(_canvasRef.transform.GetInstanceID(), MethodRegion.Activation);
        }

        public Coroutine ObjectActivation(CanvasGroup _canvasRef, float _maxAlpha, float _timeFadeIn, float _time, float _timeFadeOut, float _minAlpha)
        {

            CheckCoroutineInList(_canvasRef.gameObject, MethodRegion.Activation);

            Coroutine objectActivationCoro = StartCoroutine(ObjectActivationCO(_canvasRef, _maxAlpha, _timeFadeIn, _time, _timeFadeOut, _minAlpha));
            listCoroutine.Add(new Container(_canvasRef.transform.GetInstanceID(), MethodRegion.Activation, objectActivationCoro));

            return objectActivationCoro;
        }

        private IEnumerator ObjectActivationCO(CanvasGroup _canvasRef, float _maxAlpha, float _timeFadeIn, float _time, float _timeFadeOut, float _minAlpha)
        {
            if (_canvasRef == null)
            {
                Debug.Log("There is no Canvasgroup component attached to gameobject\n");
                yield break;
            }

            if (_timeFadeIn.Equals(0) || _maxAlpha - _canvasRef.alpha <= 0.1f)
            {
                _canvasRef.alpha = _maxAlpha;
                _canvasRef.blocksRaycasts = true;
                _canvasRef.interactable = true;
            }
            else
            {
                float alphaDelta = (_maxAlpha - _minAlpha) / (_timeFadeIn * ((_maxAlpha - _canvasRef.alpha) / (_maxAlpha - _minAlpha)));

                while (_canvasRef.alpha < _maxAlpha)
                {
                    _canvasRef.alpha += alphaDelta * Time.deltaTime;
                    yield return null;
                }
            }

            _canvasRef.alpha = _maxAlpha;
            _canvasRef.blocksRaycasts = true;
            _canvasRef.interactable = true;

            if (_time > .1f)
                yield return new WaitForSecondsRealtime(_time);

            if (!_timeFadeOut.Equals(0))
            {
                float alphaDelta = (_maxAlpha - _minAlpha) / _timeFadeOut;

                _canvasRef.blocksRaycasts = false;
                _canvasRef.interactable = false;

                while (_canvasRef.alpha > _minAlpha)
                {
                    _canvasRef.alpha -= alphaDelta * Time.deltaTime;
                    yield return null;
                }
            }

            if (!_time.Equals(0) || !_timeFadeOut.Equals(0))
            {
                _canvasRef.alpha = _minAlpha;
                _canvasRef.blocksRaycasts = false;
                _canvasRef.interactable = false;
            }

            StopObjectCoroutine(_canvasRef.transform.GetInstanceID(), MethodRegion.Activation);
        }

        #endregion

        #region Object DeActivation Methods

        public Coroutine ObjectDeactivation(GameObject _object, float _time, float _timeFadeOut)
        {
            CheckCoroutineInList(_object, MethodRegion.Activation);

            Coroutine objectDeactivationCo = StartCoroutine(ObjectDeactivationCO(_object, _time, _timeFadeOut));
            listCoroutine.Add(new Container(_object.transform.GetInstanceID(), MethodRegion.Activation, objectDeactivationCo));

            return objectDeactivationCo;
        }

        private IEnumerator ObjectDeactivationCO(GameObject _object, float _time, float _timeFadeOut)
        {
            var imTempLink = _object.GetComponent<Image>();

            if (imTempLink == null)
            {
                Debug.Log("There is no image component attached to gameobject");
                yield break;
            }

            var coOriginal = imTempLink.color;
            var coTempCopy = imTempLink.color;

            if (_time > .1f)
                yield return new WaitForSecondsRealtime(_time);

            if (_timeFadeOut.Equals(0))
            {
                coTempCopy.a = 0;
                imTempLink.color = coTempCopy;
            }
            else
            {
                float alphaDelta = 1f / _timeFadeOut;

                while (imTempLink.color.a > 0)
                {
                    coTempCopy.a -= alphaDelta * Time.deltaTime;
                    imTempLink.color = coTempCopy;
                    yield return null;
                }
            }

            _object.SetActive(false);
            imTempLink.color = coOriginal;
            StopObjectCoroutine(_object.transform.GetInstanceID(), MethodRegion.Activation);
        }

        public Coroutine ObjectDeactivation(CanvasGroup _canvasRef, float _time, float _timeFadeOut)
        {
            CheckCoroutineInList(_canvasRef.gameObject, MethodRegion.Activation);

            Coroutine objectActivationCoro = StartCoroutine(ObjectDeactivationCO(_canvasRef, _time, _timeFadeOut));
            listCoroutine.Add(new Container(_canvasRef.transform.GetInstanceID(), MethodRegion.Activation, objectActivationCoro));

            return objectActivationCoro;
        }

        private IEnumerator ObjectDeactivationCO(CanvasGroup _canvasRef, float _time, float _timeFadeOut)
        {
            if (_time > .1f)
                yield return new WaitForSecondsRealtime(_time);

            if (!_timeFadeOut.Equals(0))
            {
                float alphaDelta = 1f / _timeFadeOut;

                _canvasRef.blocksRaycasts = false;
                _canvasRef.interactable = false;

                while (_canvasRef.alpha > 0)
                {
                    _canvasRef.alpha -= alphaDelta * Time.deltaTime;
                    yield return null;
                }
            }
            else
            {
                _canvasRef.alpha = 0;
                _canvasRef.blocksRaycasts = false;
                _canvasRef.interactable = false;
            }

            StopObjectCoroutine(_canvasRef.gameObject.transform.GetInstanceID(), MethodRegion.Activation);
        }

        public Coroutine ObjectDeactivation(CanvasGroup _canvasRef, float _maxAlpha, float _time, float _timeFadeOut, float _minAlpha)
        {
            CheckCoroutineInList(_canvasRef.gameObject, MethodRegion.Activation);

            Coroutine objectActivationCoro = StartCoroutine(ObjectDeactivationCO(_canvasRef, _maxAlpha, _time, _timeFadeOut, _minAlpha));
            listCoroutine.Add(new Container(_canvasRef.transform.GetInstanceID(), MethodRegion.Activation, objectActivationCoro));

            return objectActivationCoro;
        }

        private IEnumerator ObjectDeactivationCO(CanvasGroup _canvasRef, float _maxAlpha, float _time, float _timeFadeOut, float _minAlpha)
        {
            if (_time > .1f)
                yield return new WaitForSecondsRealtime(_time);

            if (!_timeFadeOut.Equals(0))
            {
                float alphaDelta = (_maxAlpha - _minAlpha) / (_timeFadeOut * ((_canvasRef.alpha - _minAlpha) / (_maxAlpha - _minAlpha)));

                _canvasRef.blocksRaycasts = false;
                _canvasRef.interactable = false;

                while (_canvasRef.alpha > _minAlpha)
                {
                    _canvasRef.alpha -= alphaDelta * Time.deltaTime;
                    yield return null;
                }
            }
            else
            {
                _canvasRef.alpha = 0;
                _canvasRef.blocksRaycasts = false;
                _canvasRef.interactable = false;
            }

            StopObjectCoroutine(_canvasRef.gameObject.transform.GetInstanceID(), MethodRegion.Activation);
        }
        #endregion

        #region Object Moving Methods 

        public Coroutine ObjectMoving(GameObject _objectToMove, GameObject _targetPoint, float _totalTime, GameObject _startPoint)
        {
            CheckCoroutineInList(_objectToMove, MethodRegion.Moving);
            Coroutine objectActivationCoro = StartCoroutine(ObjectMovingCO(_objectToMove, _targetPoint, _totalTime, _startPoint));
            listCoroutine.Add(new Container(_objectToMove.transform.GetInstanceID(), MethodRegion.Moving, objectActivationCoro));
            return objectActivationCoro;
        }

        private IEnumerator ObjectMovingCO(GameObject _objectToMove, GameObject _targetPoint, float _totalTime, GameObject _startPoint)
        {
            RectTransform whereToMove = _targetPoint.GetComponent<RectTransform>();
            RectTransform objToMove = _objectToMove.GetComponent<RectTransform>();

            Vector3 oriPos = objToMove.position;

            float timePassed = 0.0f;

            if (_startPoint != null)
            {
                float maxDistance = Vector3.Distance(_targetPoint.transform.position, _startPoint.transform.position);
                float currentDistance = Vector3.Distance(_objectToMove.transform.position, _targetPoint.transform.position);

                if (debugMode)
                {
                    Debug.Log(currentDistance);
                    Debug.Log(maxDistance);
                }

                float valueInterpolated = Mathf.InverseLerp(0, maxDistance, currentDistance);
                float realTime = valueInterpolated * _totalTime;


                while (timePassed < 1)
                {
                    timePassed += Time.deltaTime / realTime;

                    objToMove.position = Vector3.Lerp(oriPos, whereToMove.position, timePassed);

                    yield return null;
                }
            }
            else
            {
                while (timePassed < 1)
                {
                    timePassed += Time.deltaTime / _totalTime;

                    objToMove.position = Vector3.Lerp(oriPos, whereToMove.position, timePassed);

                    yield return null;
                }
            }

            StopObjectCoroutine(_objectToMove.transform.GetInstanceID(), MethodRegion.Moving);
        }

        public Coroutine ObjectMoving(GameObject _objectToMove, Vector3 _targetPoint, float _totalTime, GameObject _startPoint)
        {
            CheckCoroutineInList(_objectToMove, MethodRegion.Moving);
            Coroutine objectActivationCoro = StartCoroutine(ObjectMovingCO(_objectToMove, _targetPoint, _totalTime, _startPoint));
            listCoroutine.Add(new Container(_objectToMove.transform.GetInstanceID(), MethodRegion.Moving, objectActivationCoro));
            return objectActivationCoro;
        }

        private IEnumerator ObjectMovingCO(GameObject _objectToMove, Vector3 _targetPoint, float _totalTime, GameObject _startPoint)
        {
            RectTransform objToMove = _objectToMove.GetComponent<RectTransform>();

            Vector3 oriPos = objToMove.position;

            float timePassed = 0.0f;

            if (_startPoint != null)
            {
                float maxDistance = Vector3.Distance(_targetPoint, _startPoint.transform.position);
                float currentDistance = Vector3.Distance(_objectToMove.transform.position, _targetPoint);

                if (debugMode)
                {
                    Debug.Log(currentDistance);
                    Debug.Log(maxDistance);
                }

                float valueInterpolated = Mathf.InverseLerp(0, maxDistance, currentDistance);
                float realTime = valueInterpolated * _totalTime;


                while (timePassed < 1)
                {
                    timePassed += Time.deltaTime / realTime;

                    objToMove.position = Vector3.Lerp(oriPos, _targetPoint, timePassed);

                    yield return null;
                }
            }
            else
            {
                while (timePassed < 1)
                {
                    timePassed += Time.deltaTime / _totalTime;

                    objToMove.position = Vector3.Lerp(oriPos, _targetPoint, timePassed);

                    yield return null;
                }
            }

            StopObjectCoroutine(_objectToMove.transform.GetInstanceID(), MethodRegion.Moving);
        }

        #endregion

        #region Object Scaling in

        public Coroutine ObjectScalingIn(GameObject _object, float _timeScaleIn, float _waitTime, float _timeScaleOut)
        {
            CheckCoroutineInList(_object, MethodRegion.Scale);

            Coroutine objectActivationCoro = StartCoroutine(ObjectScalingInCO(_object, _timeScaleIn, _waitTime, _timeScaleOut));

            listCoroutine.Add(new Container(_object.transform.GetInstanceID(), MethodRegion.Scale, objectActivationCoro));

            return objectActivationCoro;

        }

        private IEnumerator ObjectScalingInCO(GameObject _object, float _timeScaleIn, float _waitTime, float _timeScaleOut)
        {
            RectTransform rectTransform = _object.GetComponent<RectTransform>();

            if (rectTransform == null)
            {
                Debug.Log("There is no Rect transform component attached to gameobject");
                yield break;
            }

            Vector3 objectScale = rectTransform.localScale;
            float originalWidth = objectScale.x;
            float originalHeight = objectScale.y;
            float originalDepth = objectScale.z;
            float currentWidth = 0;
            float currentHeight = 0;

            float scaleInTimer = 0.0f;

            if (_timeScaleIn > 0)
            {

                while (scaleInTimer < 1.02f)
                {
                    scaleInTimer += Time.deltaTime / _timeScaleIn;
                    currentWidth = scaleInTimer * originalWidth;
                    currentHeight = scaleInTimer * originalHeight;
                    objectScale = new Vector3(currentWidth, currentHeight, originalDepth);
                    rectTransform.localScale = objectScale;
                    yield return null;
                }


                while (currentWidth > originalWidth && currentHeight > originalHeight)
                {
                    scaleInTimer -= Time.deltaTime / (_timeScaleIn * 4);
                    currentWidth = scaleInTimer * originalWidth;
                    currentHeight = scaleInTimer * originalHeight;
                    objectScale = new Vector3(currentWidth, currentHeight, originalDepth);
                    rectTransform.localScale = objectScale;
                    yield return null;
                }
            }

            objectScale = new Vector3(originalWidth, originalHeight, originalDepth);
            rectTransform.localScale = objectScale;

            if (_waitTime > .1f)
                yield return new WaitForSecondsRealtime(_waitTime);

            if (_timeScaleOut.Equals(0))
                yield break;

            float scaleOutTimer = 1;

            while (currentWidth >= (0.1f * originalWidth) && currentHeight >= (0.1f * originalHeight))
            {
                scaleOutTimer -= Time.deltaTime / _timeScaleOut;
                currentWidth = scaleOutTimer * originalWidth;
                currentHeight = scaleOutTimer * originalHeight;
                objectScale = new Vector3(currentWidth, currentHeight, originalDepth);
                rectTransform.localScale = objectScale;
                yield return null;
            }

            objectScale = new Vector3(originalWidth, originalHeight, originalDepth);
            rectTransform.localScale = objectScale;


            StopObjectCoroutine(_object.transform.GetInstanceID(), MethodRegion.Scale);
        }

        public Coroutine ObjectScalingIn(GameObject _object, float _maxScale, float _timeScaleIn, float _waitTime, float _timeScaleOut, float _minScale)
        {
            CheckCoroutineInList(_object, MethodRegion.Scale);

            Coroutine objectActivationCoro = StartCoroutine(ObjectScalingInCO(_object, _maxScale, _timeScaleIn, _waitTime, _timeScaleOut, _minScale));

            listCoroutine.Add(new Container(_object.transform.GetInstanceID(), MethodRegion.Scale, objectActivationCoro));

            return objectActivationCoro;

        }

        private IEnumerator ObjectScalingInCO(GameObject _object, float _maxScale, float _timeScaleIn, float _waitTime, float _timeScaleOut, float _minScale)
        {
            RectTransform rectTransform = _object.GetComponent<RectTransform>();

            if (rectTransform == null)
            {
                Debug.Log("There is no Rect transform component attached to gameobject");
                yield break;
            }

            Vector3 objectScale = rectTransform.localScale;

            float originalDepth = objectScale.z;
            float currentWidth = objectScale.x;
            float currentHeight = objectScale.y;

            //Debug.Log(Mathf.Abs(objectScale.x - _maxScale));

            if (Mathf.Abs(objectScale.x - _maxScale) <= 0.05f)
            {
                currentWidth = 0;
                currentHeight = 0;
            }

            float scaleStep = (_maxScale - _minScale) / (_timeScaleIn * (_maxScale - currentWidth) / (_maxScale - _minScale));

            if (_timeScaleIn > 0)
            {

                while (currentWidth < _maxScale /* * 1.02f */)
                {
                    float portionScale = scaleStep * Time.deltaTime;

                    //Debug.Log("Portion Scale: " + portionScale + ", ScaleStep: " + scaleStep + ", DeltaTime" + Time.deltaTime + "\n");


                    currentWidth += portionScale;
                    currentHeight += portionScale;
                    objectScale = new Vector3(currentWidth, currentHeight, originalDepth);
                    rectTransform.localScale = objectScale;
                    yield return null;
                }

                /*
                while (currentWidth > _maxScale)
                {

                    float portionScale = (scaleStep * Time.deltaTime) / (_timeScaleIn * 4);

                    //Debug.Log("Portion Scale: " + portionScale + ", ScaleStep: " + scaleStep + ", DeltaTime" + Time.deltaTime + "\n");

                    currentWidth -= portionScale;
                    currentHeight -= portionScale;
                    objectScale = new Vector3(currentWidth, currentHeight, originalDepth);
                    rectTransform.localScale = objectScale;
                    yield return null;
                }
                */
            }

            objectScale = new Vector3(_maxScale, _maxScale, originalDepth);
            rectTransform.localScale = objectScale;


            if (_waitTime > .1f)
            {
                yield return new WaitForSecondsRealtime(_waitTime);

                if (_timeScaleOut.Equals(0))
                    yield break;

                scaleStep = (_maxScale - _minScale) / _timeScaleOut;

                while (currentWidth >= 0.1f * _maxScale)
                {
                    float portionScale = scaleStep * Time.deltaTime;

                    currentWidth -= portionScale;
                    currentHeight -= portionScale;
                    objectScale = new Vector3(currentWidth, currentHeight, originalDepth);
                    rectTransform.localScale = objectScale;
                    yield return null;
                }

                objectScale = new Vector3(_minScale, _minScale, originalDepth);
                rectTransform.localScale = objectScale;
            }




            StopObjectCoroutine(_object.transform.GetInstanceID(), MethodRegion.Scale);
        }
        #endregion

        #region Object Scaling Out

        public Coroutine ObjectScalingOut(GameObject _object, float _waitTime, float _timeScaleOut)
        {
            CheckCoroutineInList(_object, MethodRegion.Scale);

            Coroutine objectActivationCoro = StartCoroutine(ObjectScalingOutCO(_object, _waitTime, _timeScaleOut));

            listCoroutine.Add(new Container(_object.transform.GetInstanceID(), MethodRegion.Scale, objectActivationCoro));

            return objectActivationCoro;
        }

        private IEnumerator ObjectScalingOutCO(GameObject _object, float _waitTime, float _timeScaleOut)
        {
            RectTransform rectTransform = _object.GetComponent<RectTransform>();

            if (rectTransform == null)
            {
                Debug.Log("There is no Rect transform component attached to gameobject");
                yield break;
            }

            Vector3 objectScale = rectTransform.localScale;
            float originalWidth = objectScale.x;
            float originalHeight = objectScale.y;
            float originalDepth = objectScale.z;
            float currentWidth = originalWidth;
            float currentHeight = originalHeight;

            float scaleOutTimer = 1;

            if (_waitTime > .1f)
                yield return new WaitForSecondsRealtime(_waitTime);


            while (currentWidth >= (0.1f * originalWidth) && currentHeight >= (0.1f * originalHeight))
            {
                scaleOutTimer -= Time.deltaTime / _timeScaleOut;
                currentWidth = scaleOutTimer * originalWidth;
                currentHeight = scaleOutTimer * originalHeight;
                objectScale = new Vector3(currentWidth, currentHeight, originalDepth);
                rectTransform.localScale = objectScale;
                yield return null;
            }

            objectScale = new Vector3(originalWidth, originalHeight, originalDepth);
            rectTransform.localScale = objectScale;

            StopObjectCoroutine(_object.transform.GetInstanceID(), MethodRegion.Scale);
        }

        public Coroutine ObjectScalingOut(GameObject _object, float _maxScale, float _waitTime, float _timeScaleOut, float _minScale)
        {
            CheckCoroutineInList(_object, MethodRegion.Scale);

            Coroutine objectActivationCoro = StartCoroutine(ObjectScalingOutCO(_object, _maxScale, _waitTime, _timeScaleOut, _minScale));

            listCoroutine.Add(new Container(_object.transform.GetInstanceID(), MethodRegion.Scale, objectActivationCoro));

            return objectActivationCoro;
        }

        private IEnumerator ObjectScalingOutCO(GameObject _object, float _maxScale, float _waitTime, float _timeScaleOut, float _minScale)
        {
            RectTransform rectTransform = _object.GetComponent<RectTransform>();

            if (rectTransform == null)
            {
                Debug.Log("There is no Rect transform component attached to gameobject");
                yield break;
            }

            Vector3 objectScale = rectTransform.localScale;

            float originalDepth = objectScale.z;
            float currentWidth = objectScale.x;
            float currentHeight = objectScale.y;



            float scaleStep = (_maxScale - _minScale) / (_timeScaleOut * (currentWidth - _minScale) / (_maxScale - _minScale));

            if (_waitTime > .1f)
                yield return new WaitForSecondsRealtime(_waitTime);

            while (currentWidth >= (0.1f * _maxScale))
            {
                float portionScale = scaleStep * Time.deltaTime;

                currentWidth -= portionScale;
                currentHeight -= portionScale;
                objectScale = new Vector3(currentWidth, currentHeight, originalDepth);
                rectTransform.localScale = objectScale;
                yield return null;
            }

            objectScale = new Vector3(_minScale, _minScale, originalDepth);
            rectTransform.localScale = objectScale;

            StopObjectCoroutine(_object.transform.GetInstanceID(), MethodRegion.Scale);
        }
        #endregion

        #region Blink Effect

        public Coroutine BlinkAlpha(Image _image, float _totalTime, float _loopTime, float _min, float _max)
        {
            return StartCoroutine(BlinkAlphaCO(_image, _totalTime, _loopTime, _min, _max));
        }

        private IEnumerator BlinkAlphaCO(Graphic _image, float _totalTime, float _loopTime, float _min, float _max)
        {
            float beforeTime = Time.realtimeSinceStartup;

            if (_min < 0.0f)
                _min = 0.0f;

            if (_max > 1.0f)
                _max = 1.0f;

            var newColor = _image.color;
            var currentAlpha = newColor.a;

            var halfLoopTime = _loopTime / 2;
            var firstFadeOutTime = halfLoopTime * _image.color.a;
            var secondFadeOutTime = halfLoopTime * _min;

            float step = 0;

            while (step < 1)
            {
                step += Time.deltaTime / firstFadeOutTime;
                newColor.a = Mathf.Lerp(currentAlpha, _min, step);
                _image.color = newColor;
                yield return null;
            }

            step = 0;

            if (_totalTime.Equals(Mathf.Infinity))
            {
                while (true)
                {
                    while (_image.color.a < _max)
                    {
                        step += Time.deltaTime / halfLoopTime;
                        newColor.a = Mathf.Lerp(_min, _max, step);
                        _image.color = newColor;
                        yield return null;
                    }

                    while (_image.color.a > _min)
                    {
                        step -= Time.deltaTime / halfLoopTime;
                        newColor.a = Mathf.Lerp(_min, _max, step);
                        _image.color = newColor;
                        yield return null;
                    }

                    yield return null;
                }
            }

            var newTotalTime = _totalTime - firstFadeOutTime - secondFadeOutTime;
            var halfLoopTimeRounded = newTotalTime / Mathf.Round(newTotalTime / _loopTime) / 2;

            while (newTotalTime > 0.0f)
            {
                while (_image.color.a < _max)
                {
                    newTotalTime -= Time.deltaTime;
                    step += Time.deltaTime / halfLoopTimeRounded;
                    newColor.a = Mathf.Lerp(_min, _max, step);
                    _image.color = newColor;
                    yield return null;
                }

                while (_image.color.a > _min)
                {
                    newTotalTime -= Time.deltaTime;
                    step -= Time.deltaTime / halfLoopTimeRounded;
                    newColor.a = Mathf.Lerp(_min, _max, step);
                    _image.color = newColor;
                    yield return null;
                }

                yield return null;
            }

            currentAlpha = _image.color.a;
            const float valueToSubtract = 0.2f;

            while (_image.color.a > 0.0f)
            {
                step += Time.deltaTime / (secondFadeOutTime - valueToSubtract);
                newColor.a = Mathf.Lerp(currentAlpha, 0, step);
                _image.color = newColor;
                yield return null;
            }

            newColor.a = 0;
            _image.color = newColor;

            if (debugMode)
                Debug.Log("Blink sprite function has lasted " + string.Format("{0:0.00}", Time.realtimeSinceStartup - beforeTime) + "s\n");
        }

        #endregion

        #region Scale Effect

        public Coroutine ScaleWithCurve(AnimationCurve _scaleCurve, GameObject _gameObject, float _duration)
        {
            CheckCoroutineInList(_gameObject, MethodRegion.Scale);

            Coroutine scaleWithCurveCoro = StartCoroutine(ScaleWithCurveCO(_scaleCurve, _gameObject, _duration));

            listCoroutine.Add(new Container(_gameObject.transform.GetInstanceID(), MethodRegion.Scale, scaleWithCurveCoro));

            return scaleWithCurveCoro;
        }

        private IEnumerator ScaleWithCurveCO(AnimationCurve _scaleCurve, GameObject _gameObject, float _duration)
        {
            Vector3 rightScale = _gameObject.transform.localScale;
            Vector3 localScale = _gameObject.transform.localScale;
            Transform transformGO = _gameObject.GetComponent<Transform>();
            float time = 0f;
            float scale;

            while (time <= 1f)
            {
                scale = _scaleCurve.Evaluate(time);
                time = time + Time.deltaTime / _duration;
                localScale.x = scale;
                localScale.y = scale;
                transformGO.localScale = localScale;

                yield return null;
            }
            _gameObject.transform.localScale = rightScale;

            StopObjectCoroutine(_gameObject.transform.GetInstanceID(), MethodRegion.Scale);
        }

        public Coroutine FlipCard(Sprite _spriteTarget, Image _image, float _duration, GameObject _gameObject)
        {

            CheckCoroutineInList(_image.gameObject, MethodRegion.Scale);

            Coroutine flipCardCO = StartCoroutine(FlipCardCO(_spriteTarget, _image, _duration, _gameObject));

            listCoroutine.Add(new Container(_image.transform.GetInstanceID(), MethodRegion.Scale, flipCardCO));

            return flipCardCO;
        }

        private IEnumerator FlipCardCO(Sprite _spriteTarget, Image _image, float _duration, GameObject _gameObject)
        {
            if (_image == null)
            {
                Debug.Log("There is no image component attached to gameobject");
                yield break;
            }

            if (_gameObject == null)
                _gameObject = _image.gameObject;

            AnimationCurve _scaleCurve;
            RectTransform rectGO = _gameObject.GetComponent<RectTransform>();
            Vector3 localScale = _gameObject.transform.localScale;
            Vector3 rightScale = _gameObject.transform.localScale;
            float time = 0f;
            _scaleCurve = AnimationCurve.EaseInOut(0, 1, 1, 1);
            _scaleCurve.AddKey(0.5f, 0);
            System.Action ScaleFunction = () =>
           {
               float scale = _scaleCurve.Evaluate(time);
               time = time + Time.deltaTime / _duration;

               localScale.x = scale;
               rectGO.localScale = localScale;
           };
            while (time <= 0.5f)
            {
                ScaleFunction();
                yield return null;
            }

            _image.sprite = _spriteTarget;
            time = 0.5f;
            while (time <= 1f)
            {
                ScaleFunction();
                yield return null;
            }

            _gameObject.transform.localScale = rightScale;

            StopObjectCoroutine(_gameObject.transform.GetInstanceID(), MethodRegion.Scale);
        }

        public Coroutine DoubleFlipCard(Sprite _spriteTarget, Sprite _spriteMiddle, Image _image, float _duration, GameObject _gameObject)
        {

            CheckCoroutineInList(_image.gameObject, MethodRegion.Scale);

            Coroutine doubleFlipCardCO = StartCoroutine(DoubleFlipCardCO(_spriteTarget, _spriteMiddle, _image, _duration, _gameObject));

            listCoroutine.Add(new Container(_gameObject.transform.GetInstanceID(), MethodRegion.Scale, doubleFlipCardCO));

            return doubleFlipCardCO;
        }

        private IEnumerator DoubleFlipCardCO(Sprite _spriteTarget, Sprite _spriteMiddle, Image _image, float _duration, GameObject _gameObject)
        {
            if (_image == null)
            {
                Debug.Log("There is no image component attached to gameobject");
                yield break;
            }


            if (_gameObject == null)
                _gameObject = _image.gameObject;

            AnimationCurve _scaleCurve;

            Vector3 localScale = _gameObject.transform.localScale;
            Vector3 rightScale = _gameObject.transform.localScale;
            RectTransform rectGO = _gameObject.GetComponent<RectTransform>();
            float time = 0f;
            _scaleCurve = AnimationCurve.EaseInOut(0, 1, 1, 1);
            _scaleCurve.AddKey(0.25f, 0);
            _scaleCurve.AddKey(0.5f, 1);
            _scaleCurve.AddKey(.75f, 0);

            System.Action ScaleFunction = () =>
            {
                float scale = _scaleCurve.Evaluate(time);
                time = time + Time.deltaTime / _duration;

                localScale.x = scale;
                rectGO.localScale = localScale;
            };

            while (time <= 0.25f)
            {
                ScaleFunction();
                yield return null;
            }
            _image.sprite = _spriteMiddle;
            time = 0.25f;
            while (time <= 0.75f)
            {
                ScaleFunction();
                yield return null;
            }
            _image.sprite = _spriteTarget;
            time = 0.75f;
            while (time <= 1)
            {
                ScaleFunction();
                yield return null;
            }
            _gameObject.transform.localScale = rightScale;

            StopObjectCoroutine(_image.transform.GetInstanceID(), MethodRegion.Scale);
        }


        #endregion

        #region Smooth Variation Effect

        public Coroutine SmoothVariation(Text _text, int _targetValue, float _timeNeeded, int _maxValue, int _minValue)
        {
            CheckCoroutineInList(_text.gameObject, MethodRegion.SmoothVariationText);

            Coroutine smoothVariationCoro = StartCoroutine(SmoothVariationCO(_text, _targetValue, _timeNeeded, _maxValue, _minValue));

            listCoroutine.Add(new Container(_text.gameObject.transform.GetInstanceID(), MethodRegion.SmoothVariationText, smoothVariationCoro));

            return smoothVariationCoro;

        }

        private IEnumerator SmoothVariationCO(Text _text, int _targetValue, float _timeNeeded, int _maxValue, int _minValue)
        {
            int currentValue;

            if (!int.TryParse(_text.text, out currentValue))
            {
                Debug.LogError("There is an issue trying parse " + _text.gameObject.name + " text value to int value");
                yield break;
            }

            float currentFloatValue = currentValue;
            int difference = _targetValue - currentValue;

            float timeStep;

            if (_maxValue - _minValue == 0)
                timeStep = _timeNeeded;
            else
                timeStep = _timeNeeded / ((float)(_targetValue - currentValue) / Mathf.Abs(_maxValue - _minValue)) * (_maxValue - _minValue);

            if (_targetValue > currentValue)
            {
            while (currentValue < _targetValue)
            {
                currentFloatValue += (Time.deltaTime / timeStep) * difference;
                currentValue = (int)currentFloatValue;
                _text.text = currentValue.ToString();

                yield return null;
            }
                
            }
            else if (_targetValue < currentValue)
            {
                while (currentValue > _targetValue)
                {
                    currentFloatValue += (Time.deltaTime / timeStep) * difference;
                    currentValue = (int)currentFloatValue;
                    _text.text = currentValue.ToString();

                    yield return null;
                }
            }



            _text.text = _targetValue.ToString();

            StopObjectCoroutine(_text.gameObject.transform.GetInstanceID(), MethodRegion.SmoothVariationText);
        }

        public Coroutine SmoothVariation(Image _image, float _targetValue, float _timeNeeded, float _maxValue, float _minValue)
        {
            CheckCoroutineInList(_image.gameObject, MethodRegion.SmoothVariationImage);

            Coroutine smoothVariationCoro = StartCoroutine(SmoothVariationCO(_image, _targetValue, _timeNeeded, _maxValue, _minValue));

            listCoroutine.Add(new Container(_image.gameObject.transform.GetInstanceID(), MethodRegion.SmoothVariationImage, smoothVariationCoro));

            return smoothVariationCoro;

        }

        private IEnumerator SmoothVariationCO(Image _image, float _targetValue, float _timeNeeded, float _maxValue, float _minValue)
        {
            float currentValue = _image.fillAmount;

            float difference = _targetValue - currentValue;

            float timeStep;

            if (Math.Abs(_maxValue - _minValue) < 0.01f)
                timeStep = _timeNeeded;
            else
                timeStep = _timeNeeded / ((float)(_targetValue - currentValue) / Mathf.Abs(_maxValue - _minValue)) * (_maxValue - _minValue);


            float timer = 0;


            while (timer < timeStep)
            {
                timer += Time.deltaTime;

                currentValue += (Time.deltaTime / timeStep) * difference;
                _image.fillAmount = currentValue;
                yield return null;
            }

            _image.fillAmount = _targetValue;

            StopObjectCoroutine(_image.gameObject.transform.GetInstanceID(), MethodRegion.SmoothVariationImage);
        }

        #endregion

        #region Blink Scale Effect

        // TODO: Da rivedere
        public Coroutine BlinkScaleSprite(GameObject _object, float _totalTime, float _loopTime, float _min, float _max)
        {
            return StartCoroutine(BlinkScaleSpriteCO(_object, _totalTime, _loopTime, _min, _max));
        }

        private static IEnumerator BlinkScaleSpriteCO(GameObject _object, float _totalTime, float _loopTime, float _min, float _max)
        {
            if (_min < 0.1f)
                _min = 0.1f;
            else if (_min > 1)
                _min = 1;

            if (_max < 1)
                _max = 1;

            Vector3 currentScale = _object.transform.localScale;

            var currentScaleFactor = currentScale.x;

            var halfLoopTime = _loopTime / 2;
            var firstFadeOutTime = halfLoopTime;
            var secondFadeOutTime = halfLoopTime;

            float step = 1;

            while (currentScale.x > _min * currentScaleFactor)
            {
                step -= Time.deltaTime / firstFadeOutTime;
                currentScale = step * currentScaleFactor * Vector3.one;
                _object.transform.localScale = currentScale;
                yield return null;
            }

            var newTotalTime = _totalTime - firstFadeOutTime - secondFadeOutTime;
            var halfLoopTimeRounded = newTotalTime / Mathf.Round(newTotalTime / _loopTime) / 2;

            while (newTotalTime > 0.0f)
            {
                step = 0;

                while (currentScale.x < ((_max * currentScaleFactor) - 0.01f))
                {
                    newTotalTime -= Time.deltaTime;
                    step += Time.deltaTime / halfLoopTimeRounded;
                    currentScale = step * currentScaleFactor * _max * Vector3.one;
                    _object.transform.localScale = currentScale;
                    yield return null;
                }

                step = 1;

                while (currentScale.x > ((_min * currentScaleFactor) + 0.01f))
                {
                    newTotalTime -= Time.deltaTime;
                    step -= Time.deltaTime / halfLoopTimeRounded;
                    currentScale = step * currentScaleFactor * _max * Vector3.one;
                    _object.transform.localScale = currentScale;
                    yield return null;
                }

                yield return null;
            }

            step = 0;

            while (currentScale.x < (currentScaleFactor - 0.01f))
            {
                step += Time.deltaTime / secondFadeOutTime;
                currentScale = step * currentScaleFactor * Vector3.one;
                _object.transform.localScale = currentScale;
                yield return null;
            }

            currentScale = currentScaleFactor * Vector3.one;
            _object.transform.localScale = currentScale;
        }

        #endregion

        #region Text Methods

        public Coroutine WriteTextInTypewriterStyle(Text _textComponent, string _text, float _speedFromCharAndOther, bool _canSkip)
        {
            return StartCoroutine(WriteTextInTypewriterStyleCO(_textComponent, _text, _speedFromCharAndOther, _canSkip));
        }

        private IEnumerator WriteTextInTypewriterStyleCO(Text _textComponent, string _text, float _speedFromCharAndOther, bool _canSkip)
        {
            if (_canSkip)
            {
                bool isFirstLoop = Input.GetMouseButtonDown(0);

                foreach (char textChar in _text)
                {
                    float temp_speedChar = 0.0f;

                    if (textChar.Equals(' ') && textChar.Equals('\n'))
                        continue;

                    while (_speedFromCharAndOther > temp_speedChar)
                    {
                        temp_speedChar += Time.deltaTime;

                        if (isFirstLoop)
                        {
                            if (Input.GetMouseButtonUp(0))
                                isFirstLoop = false;
                        }

                        if (Input.GetMouseButtonDown(0) && !isFirstLoop)
                        {
                            _textComponent.text = _text;
                            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                            yield break;
                        }

                        yield return null;
                    }

                    _textComponent.text += textChar;
                }
            }
            else
            {
                foreach (char textChar in _text)
                {
                    if (!textChar.Equals(' ') || !textChar.Equals('\n'))
                        yield return new WaitForSecondsRealtime(_speedFromCharAndOther);

                    _textComponent.text += textChar;
                }
            }
        }

        #endregion

        #region Buttons

        public void EnableInteraction(params Button[] _buttons)
        {
            foreach (var button in _buttons)
                button.interactable = true;
        }

        public void DisableInteraction(params Button[] _buttons)
        {
            foreach (var button in _buttons)
                button.interactable = false;
        }

        public void AllowSpecificInteraction(params Button[] _buttonsToKeepEnabled)
        {
            Button[] allButtons = FindObjectsOfType<Button>();
            List<Button> parameterButtons = _buttonsToKeepEnabled.ToList();

            int numberOfDisabledButtons = 0;

            foreach (var instanceButton in allButtons)
            {
                foreach (var parameterButton in parameterButtons)
                {
                    if (!parameterButton.gameObject.Equals(instanceButton.gameObject))
                    {

                        numberOfDisabledButtons++;
                        instanceButton.interactable = false;

                        continue;
                    }

                    if (debugMode)
                        Debug.Log("Button to enable found\n");

                    instanceButton.interactable = true;
                }
            }

            if (debugMode)
                Debug.Log("Disabled buttons are " + numberOfDisabledButtons + "\n");
        }

        #endregion

        #region Lerp Canvas Group

        public Coroutine LerpCanvasGroupAlpha(CanvasGroup _canvasGroup, float _targetAlpha, float _time, bool _blocksRaycasts)
        {
            return StartCoroutine(LerpCanvasGroupAlphaCO(_canvasGroup, _targetAlpha, _time, _blocksRaycasts));
        }

        private IEnumerator LerpCanvasGroupAlphaCO(CanvasGroup _canvasGroup, float _targetAlpha, float _time, bool _blocksRaycasts)
        {
            const float thresold = 0.05f;

            if (_targetAlpha > 1.0f)
                _targetAlpha = 1.0f;
            else if (_targetAlpha < 0.0f)
                _targetAlpha = 0.0f;

            float temp_currentAlpha = _canvasGroup.alpha;

            if (Mathf.Abs(_targetAlpha - temp_currentAlpha) <= thresold || _time <= thresold)
            {
                _canvasGroup.alpha = _targetAlpha;
                _canvasGroup.blocksRaycasts = _blocksRaycasts;
                yield break;
            }

            _canvasGroup.blocksRaycasts = false;

            float step = 0.0f;

            while (step < 1.0f)
            {
                step += Time.deltaTime / _time;
                _canvasGroup.alpha = Mathf.Lerp(temp_currentAlpha, _targetAlpha, step);
                yield return null;
            }

            _canvasGroup.blocksRaycasts = _blocksRaycasts;
        }

        #endregion

        public Coroutine FillAmountImage(Image _image, float _fillSeconds, float _startValue, float _targetValue)
        {
            return StartCoroutine(FillAmountImageCO(_image, _fillSeconds, _startValue, _targetValue));
        }

        public IEnumerator FillAmountImageCO(Image _image, float _fillSeconds, float _startValue, float _targetValue)
        {
            float temp_fillSeconds = _fillSeconds;
            float step = 0;

            while (step < 1)
            {
                step += Time.deltaTime / temp_fillSeconds;
                _image.fillAmount = Mathf.Lerp(_startValue, _targetValue, step);
                yield return null;
            }
        }

        public Coroutine ScaleObject(RectTransform _rect, float _scaleTime, Vector3 _startScale, Vector3 _targetScale)
        {
            return StartCoroutine(ScaleObjectCO(_rect, _scaleTime, _startScale, _targetScale));
        }

        private IEnumerator ScaleObjectCO(RectTransform _rect, float _scaleTime, Vector3 _startScale, Vector3 _targetScale)
        {
            float step = 0;

            while (step < 1)
            {
                step += Time.deltaTime / _scaleTime;
                _rect.localScale = Vector3.Lerp(_startScale, _targetScale, step);
                yield return new WaitForEndOfFrame();
            }

            _rect.localScale = _targetScale;
        }

        #region Interaction

        public void BlocksRaycast(bool _value, params CanvasGroup[] _canvasGroups)
        {
            foreach (var canvasGroup in _canvasGroups)
                canvasGroup.blocksRaycasts = _value;
        }

        #endregion

        #region SYSTEM

        public void StopUiCoroutine(Coroutine coroutineToStop)
        {
            if (coroutineToStop != null)
                StopCoroutine(coroutineToStop);
        }

        internal void GarbageCollector()
        {
            foreach (var activeCo in listCoroutine)
            {
                if (activeCo.coroutine != null)
                    StopCoroutine(activeCo.coroutine);
            }
            listCoroutine.Clear();
            listCoroutine.TrimExcess();
        }

        #endregion
    }
}