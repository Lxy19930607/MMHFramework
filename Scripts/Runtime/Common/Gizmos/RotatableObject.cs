using UnityEngine;

namespace MMHFramework
{
    public class RotatableObject : MonoBehaviour
    {
        public bool IsActive = true;

        public Vector3 RotateSpeed;

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
            transform.Rotate(RotateSpeed * deltaTime);
        }
    }
}