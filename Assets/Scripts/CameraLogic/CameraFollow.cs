using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _rotationAngleX;
    [SerializeField] private float _distance;
    [SerializeField] private float _offsetY;
    [SerializeField] private Transform _following;

    #region MonoBehaviour
    private void OnValidate()
    {
        if (_rotationAngleX < 0f) _rotationAngleX = 0f;
        if (_distance < 0f) _distance = 0f;
        if (_offsetY < 0f) _offsetY = 0f;
    }
    #endregion

    private void LateUpdate()
    {
        if (_following == null)
            return;

        Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
        Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPosition();

        transform.rotation = rotation;
        transform.position = position;
    }

    public void SetFollow(GameObject following)
    {
        _following = following.transform;
    }

    private Vector3 FollowingPosition()
    {
        Vector3 followingPosition = _following.position;
        followingPosition.y += _offsetY;
        return followingPosition;
    }
}
