using UnityEngine;
using DG.Tweening;

namespace MMHFramework
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIGroup : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _CanvasGroup;

        [SerializeField]
        private bool _ShowOnEnable = false;

        private Tweener _MoveTweener;

        private Tweener _RotateTweener;

        private Tweener _ScaleTweener;

        private Tweener _FadeTweener;

        private void Reset()
        {
            _CanvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            if(_ShowOnEnable)
            {
                FadeIn(0f);
            }
            else
            {
                FadeOut(0f);
            }
        }

        public void Show()
        {
            FadeIn(0f);
        }

        public void Hide()
        {
            FadeOut(0f);
        }

        public void StopMove()
        {
            if(_MoveTweener != null)
            {
                _MoveTweener.Kill();
                _MoveTweener = null;
            }
        }

        public Tweener MoveTo(Vector3 value,float duration)
        {
            StopMove();
            _MoveTweener = transform.DOMove(value,duration);
            return _MoveTweener;
        }

        public Tweener MoveTo(Vector3 startValue,Vector3 endValue,float duration)
        {
            StopMove();
            transform.position = startValue;
            _MoveTweener = transform.DOMove(endValue,duration);
            return _MoveTweener;
        }

        public Tweener MoveXTo(float value,float duration)
        {
            StopMove();
            _MoveTweener = transform.DOMoveX(value,duration);
            return _MoveTweener;
        }

        public Tweener MoveXTo(float startValue,float endValue,float duration)
        {
            StopMove();
            transform.SetPositionX(startValue);
            _MoveTweener = transform.DOMoveX(endValue,duration);
            return _MoveTweener;
        }

        public Tweener MoveYTo(float value,float duration)
        {
            StopMove();
            _MoveTweener = transform.DOMoveY(value,duration);
            return _MoveTweener;
        }

        public Tweener MoveYTo(float startValue,float endValue,float duration)
        {
            StopMove();
            transform.SetPositionY(startValue);
            _MoveTweener = transform.DOMoveY(endValue,duration);
            return _MoveTweener;
        }

        public Tweener MoveZTo(float value,float duration)
        {
            StopMove();
            _MoveTweener = transform.DOMoveZ(value,duration);
            return _MoveTweener;
        }

        public Tweener MoveZTo(float startValue,float endValue,float duration)
        {
            StopMove();
            transform.SetPositionZ(startValue);
            _MoveTweener = transform.DOMoveZ(endValue,duration);
            return _MoveTweener;
        }

        public Tweener LocalMoveTo(Vector3 value,float duration)
        {
            StopMove();
            _MoveTweener = transform.DOLocalMove(value,duration);
            return _MoveTweener;
        }

        public Tweener LocalMoveTo(Vector3 startValue,Vector3 endValue,float duration)
        {
            StopMove();
            transform.localPosition = startValue;
            _MoveTweener = transform.DOLocalMove(endValue,duration);
            return _MoveTweener;
        }

        public Tweener LocalMoveXTo(float value,float duration)
        {
            StopMove();
            _MoveTweener = transform.DOLocalMoveX(value,duration);
            return _MoveTweener;
        }

        public Tweener LocalMoveXTo(float startValue,float endValue,float duration)
        {
            StopMove();
            transform.SetLocalPositionX(startValue);
            _MoveTweener = transform.DOLocalMoveX(endValue,duration);
            return _MoveTweener;
        }

        public Tweener LocalMoveYTo(float value,float duration)
        {
            StopMove();
            _MoveTweener = transform.DOLocalMoveY(value,duration);
            return _MoveTweener;
        }

        public Tweener LocalMoveYTo(float startValue,float endValue,float duration)
        {
            StopMove();
            transform.SetLocalPositionY(startValue);
            _MoveTweener = transform.DOLocalMoveY(endValue,duration);
            return _MoveTweener;
        }

        public Tweener LocalMoveZTo(float value,float duration)
        {
            StopMove();
            _MoveTweener = transform.DOLocalMoveZ(value,duration);
            return _MoveTweener;
        }

        public Tweener LocalMoveZTo(float startValue,float endValue,float duration)
        {
            StopMove();
            transform.SetLocalPositionZ(startValue);
            _MoveTweener = transform.DOLocalMoveZ(endValue,duration);
            return _MoveTweener;
        }

        public void StopRotate()
        {
            if(_RotateTweener != null)
            {
                _RotateTweener.Kill();
                _RotateTweener = null;
            }
        }

        public Tweener RotateTo(Vector3 value,float duration)
        {
            StopRotate();
            _RotateTweener = transform.DORotate(value,duration);
            return _RotateTweener;
        }

        public Tweener RotateTo(Vector3 startValue,Vector3 endValue,float duration)
        {
            StopRotate();
            transform.eulerAngles = startValue;
            _RotateTweener = transform.DORotate(endValue,duration);
            return _RotateTweener;
        }

        public Tweener LocalRotateTo(Vector3 value,float duration)
        {
            StopRotate();
            _RotateTweener = transform.DOLocalRotate(value,duration);
            return _RotateTweener;
        }

        public Tweener LocalRotateTo(Vector3 startValue,Vector3 endValue,float duration)
        {
            StopRotate();
            transform.localEulerAngles = startValue;
            _RotateTweener = transform.DOLocalRotate(endValue,duration);
            return _RotateTweener;
        }

        public Tweener RotateQuaternionTo(Quaternion value,float duration)
        {
            StopRotate();
            _RotateTweener = transform.DORotateQuaternion(value,duration);
            return _RotateTweener;
        }

        public Tweener RotateQuaternionTo(Quaternion startValue,Quaternion endValue,float duration)
        {
            StopRotate();
            transform.rotation = startValue;
            _RotateTweener = transform.DORotateQuaternion(endValue,duration);
            return _RotateTweener;
        }

        public Tweener LocalRotateQuaternionTo(Quaternion value,float duration)
        {
            StopRotate();
            _RotateTweener = transform.DOLocalRotateQuaternion(value,duration);
            return _RotateTweener;
        }

        public Tweener LocalRotateQuaternionTo(Quaternion startValue,Quaternion endValue,float duration)
        {
            StopRotate();
            transform.localRotation = startValue;
            _RotateTweener = transform.DOLocalRotateQuaternion(endValue,duration);
            return _RotateTweener;
        }

        public void StopScale()
        {
            if(_ScaleTweener != null)
            {
                _ScaleTweener.Kill();
                _ScaleTweener = null;
            }
        }

        public Tweener ScaleTo(float value,float duration)
        {
            StopScale();
            _ScaleTweener = transform.DOScale(value,duration);
            return _ScaleTweener;
        }

        public Tweener ScaleTo(float startValue,float endValue,float duration)
        {
            StopScale();
            transform.localScale = Vector3.one * startValue;
            _ScaleTweener = transform.DOScale(endValue,duration);
            return _ScaleTweener;
        }

        public Tweener ScaleTo(Vector3 value,float duration)
        {
            StopScale();
            _ScaleTweener = transform.DOScale(value,duration);
            return _ScaleTweener;
        }

        public Tweener ScaleTo(Vector3 startValue,Vector3 endValue,float duration)
        {
            StopScale();
            transform.localScale = startValue;
            _ScaleTweener = transform.DOScale(endValue,duration);
            return _ScaleTweener;
        }

        public Tweener ScaleXTo(float value,float duration)
        {
            StopScale();
            _ScaleTweener = transform.DOScaleX(value,duration);
            return _ScaleTweener;
        }

        public Tweener ScaleXTo(float startValue,float endValue,float duration)
        {
            StopScale();
            transform.SetLocalScaleX(startValue);
            _ScaleTweener = transform.DOScaleX(endValue,duration);
            return _ScaleTweener;
        }

        public Tweener ScaleYTo(float value,float duration)
        {
            StopScale();
            _ScaleTweener = transform.DOScaleY(value,duration);
            return _ScaleTweener;
        }

        public Tweener ScaleYTo(float startValue,float endValue,float duration)
        {
            StopScale();
            transform.SetLocalScaleY(startValue);
            _ScaleTweener = transform.DOScaleY(endValue,duration);
            return _ScaleTweener;
        }

        public Tweener ScaleZTo(float value,float duration)
        {
            StopScale();
            _ScaleTweener = transform.DOScaleZ(value,duration);
            return _ScaleTweener;
        }

        public Tweener ScaleZTo(float startValue,float endValue,float duration)
        {
            StopScale();
            transform.SetLocalScaleZ(startValue);
            _ScaleTweener = transform.DOScaleZ(endValue,duration);
            return _ScaleTweener;
        }

        public void StopFade()
        {
            if(_FadeTweener != null)
            {
                _FadeTweener.Kill();
                _FadeTweener = null;
            }
        }

        public Tweener FadeTo(float value,float duration)
        {
            StopFade();
            _FadeTweener = _CanvasGroup.DOFade(value,duration);
            return _FadeTweener;
        }

        public Tweener FadeTo(float startValue,float endValue,float duration)
        {
            StopFade();
            _CanvasGroup.alpha = startValue;
            _FadeTweener = _CanvasGroup.DOFade(endValue,duration);
            return _FadeTweener;
        }

        public Tweener FadeIn(float duration)
        {
            return FadeTo(1f,duration);
        }

        public Tweener FadeOut(float duration)
        {
            return FadeTo(0f,duration);
        }

        public void Stop()
        {
            StopMove();
            StopRotate();
            StopScale();
            StopFade();
        }
    }
}