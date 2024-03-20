using UnityEngine;

namespace CodeBase.Logic.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 1f;
        [SerializeField] private float _zoomSpeed = 1f;
        [SerializeField] private float _minZoomDistance = 2f;
        [SerializeField] private float _maxZoomDistance = 10f;

        private Transform _target;

        public void Construct(Transform target)
        {
            _target = target;
        }

        private void LateUpdate()
        {
            transform.LookAt(_target.position);

            if (Input.GetMouseButton(0))
                RotationCamera();

            Vector2 scrollDelta = Input.mouseScrollDelta;

            if (scrollDelta.y != 0)
                ZoomCamera(scrollDelta);

            UpdateCameraPosition();
        }

        private void ZoomCamera(Vector2 scrollDelta)
        {
            Vector3 direction = (transform.position - _target.position).normalized;
            float zoomDistance = Mathf.Clamp((transform.position - _target.position).magnitude - scrollDelta.y * _zoomSpeed,
                _minZoomDistance, _maxZoomDistance);

            transform.position = _target.position + direction * zoomDistance;
        }

        private void RotationCamera()
        {
            float horizontal = Input.GetAxis("Mouse X") * _rotationSpeed;
            float vertical = Input.GetAxis("Mouse Y") * _rotationSpeed;

            transform.RotateAround(_target.position, Vector3.up, -horizontal);
            transform.RotateAround(_target.position, transform.right, vertical);
        }

        private void UpdateCameraPosition()
        {
            Vector3 direction = (transform.position - _target.position).normalized;
            float distance = Mathf.Clamp((transform.position - _target.position).magnitude, _minZoomDistance,
                _maxZoomDistance);

            transform.position = _target.position + direction * distance;
        }
    }
}