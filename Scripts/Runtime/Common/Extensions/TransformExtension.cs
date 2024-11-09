using UnityEngine;

namespace MMHFramework
{
    public static class TransformExtension
    {
        public static void SetPositionX(this Transform transform,float value)
        {
            transform.position = transform.position.SetX(value);
        }

        public static void SetPositionY(this Transform transform,float value)
        {
            transform.position = transform.position.SetY(value);
        }

        public static void SetPositionZ(this Transform transform,float value)
        {
            transform.position = transform.position.SetZ(value);
        }

        public static void SetLocalPositionX(this Transform transform,float value)
        {
            transform.localPosition = transform.localPosition.SetX(value);
        }

        public static void SetLocalPositionY(this Transform transform,float value)
        {
            transform.localPosition = transform.localPosition.SetY(value);
        }

        public static void SetLocalPositionZ(this Transform transform,float value)
        {
            transform.localPosition = transform.localPosition.SetZ(value);
        }

        public static void SetEulerAnglesX(this Transform transform,float value)
        {
            transform.eulerAngles = transform.eulerAngles.SetX(value);
        }

        public static void SetEulerAnglesY(this Transform transform,float value)
        {
            transform.eulerAngles = transform.eulerAngles.SetY(value);
        }

        public static void SetEulerAnglesZ(this Transform transform,float value)
        {
            transform.eulerAngles = transform.eulerAngles.SetZ(value);
        }

        public static void SetLocalEulerAnglesX(this Transform transform,float value)
        {
            transform.localEulerAngles = transform.localEulerAngles.SetX(value);
        }

        public static void SetLocalEulerAnglesY(this Transform transform,float value)
        {
            transform.localEulerAngles = transform.localEulerAngles.SetY(value);
        }

        public static void SetLocalEulerAnglesZ(this Transform transform,float value)
        {
            transform.localEulerAngles = transform.localEulerAngles.SetZ(value);
        }

        public static void SetLocalScaleX(this Transform transform,float value)
        {
            transform.localScale = transform.localScale.SetX(value);
        }

        public static void SetLocalScaleY(this Transform transform,float value)
        {
            transform.localScale = transform.localScale.SetY(value);
        }

        public static void SetLocalScaleZ(this Transform transform,float value)
        {
            transform.localScale = transform.localScale.SetZ(value);
        }
    }
}