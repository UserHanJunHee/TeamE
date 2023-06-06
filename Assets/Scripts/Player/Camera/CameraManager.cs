using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    PlayerInputManager inputManager;

    public Transform targetTransform;
    public Transform cameraPivot;
    public Transform cameraTransform;
    public LayerMask collisionLayer;
    private float defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;


    public float cameraCollisionOffSet = 0.2f;
    public float minCollisionOffSet = 0.2f;

    public float cameraCollisionRadius = 2;
    public float cameraFollowSpeed = 0.2f;
    public float cameraLoockSpeed = 2;
    public float camerPivotSpeed = 2;

    public float lookAngle; //카메라 위 아래
    public float pivotAngle; //카메라 왼쪽 오른쪽

    public float minPivotAngle = -35;
    public float maxPivotAngle = 35;

    private void Awake()
    {
        inputManager = FindObjectOfType<PlayerInputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }


    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targerRotation;

        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLoockSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * camerPivotSpeed) ;

        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targerRotation = Quaternion.Euler(rotation);
        transform.rotation = targerRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targerRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targerRotation;

    }

    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if(Physics.SphereCast
            (cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayer))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition = targetPosition - (distance - cameraCollisionOffSet);
        }

        if(Mathf.Abs(targetPosition) < minCollisionOffSet)
        {
            targetPosition = targetPosition - minCollisionOffSet;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
