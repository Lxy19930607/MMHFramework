using UnityEngine;

namespace MMHFramework
{
    public class ScalableObject : MonoBehaviour
    {
        public bool IsActive = true;

        public Vector3 ScaleSpeed;

        private void Update()
        {
            UpdateState(Time.deltaTime);
        }

        private void UpdateState(float deltaTime)
        {
            if(!IsActive)
            {
                return;
            }
            UpdateScale(deltaTime);
        }

        private void UpdateScale(float deltaTime)
        {
            transform.localScale += ScaleSpeed * deltaTime;
        }
    }
}