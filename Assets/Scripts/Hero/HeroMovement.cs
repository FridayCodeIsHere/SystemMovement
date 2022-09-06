using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private CharacterController _characterController;
    private Camera _camera;
    private IInputService _inputService;


    #region MonoBehaviour
    private void OnValidate()
    {
        if (_speed < 0f) _speed = 0f;
    }
    #endregion

    private void Awake()
    {
        _inputService = Game.InputService;
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _camera = Camera.main;
        if (_camera.TryGetComponent(out CameraFollow camera))
        {
            camera.SetFollow(this.gameObject);
        }
    }

    private void Update()
    {
        Vector3 movementVector = Vector3.zero;

        if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
        {
            movementVector = _camera.transform.TransformDirection(_inputService.Axis);
            movementVector.y = 0f;
            movementVector.Normalize();
            transform.forward = movementVector;
        }

        movementVector += Physics.gravity;
        _characterController.Move(movementVector * _speed * Time.deltaTime);

    }
}
