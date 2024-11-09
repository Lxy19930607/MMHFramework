using UnityEngine;

namespace MMHFramework
{
    public class MovableObject : MonoBehaviour
    {
        public bool IsActive = true;

        public Vector3 MoveSpeed;

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
            UpdatePosition(deltaTime);
        }

        private void UpdatePosition(float deltaTime)
        {
            transform.position += MoveSpeed * deltaTime;
        }
    }
}