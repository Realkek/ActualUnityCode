using System;
using UnityEngine;

namespace ForCamera
{
    public class CameraFollow : MonoBehaviour
    {
        public float RotatingAngleX;
        public float Distance;
        public float OffsetY; 
        
        
        [SerializeField]
        private Transform _trackingEntity;

       

        private void LateUpdate()
        {
            if (_trackingEntity == null)
                return; 
            Quaternion rotation = Quaternion.Euler(RotatingAngleX, 0,0 );
            var followingPosition = SetFollowingPosition();
            Vector3 position = rotation * new Vector3(0, 0, -Distance) + followingPosition;
            transform.rotation = rotation;
            transform.position = position; 

        }

        public void Follow(GameObject following)
        {
            _trackingEntity = following.transform; 
        }
        private Vector3 SetFollowingPosition()
        {
            Vector3 followingPosition = _trackingEntity.position;
            followingPosition.y += OffsetY;
            return followingPosition;
        }
    }
}
