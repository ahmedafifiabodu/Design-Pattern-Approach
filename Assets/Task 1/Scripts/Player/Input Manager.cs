using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem _playerInput;
    private InputSystem.PlayerActions _playerActions;

    private PlayerMovement _playerMotor;
    private PlayerLook _playerLook;

    private void Awake()
    {
        _playerInput = new InputSystem();
        _playerActions = _playerInput.Player;
    }

    private void Start()
    {
        _playerMotor = ServiceLocator.Instance.GetService<PlayerMovement>();
        _playerLook = ServiceLocator.Instance.GetService<PlayerLook>();

        _playerActions.Look.performed += _ => _playerLook.ProcesLook(_.ReadValue<Vector2>());

        _playerActions.Zoom.performed += _ => _playerLook.ZoomIn();
        _playerActions.Zoom.canceled += _ => _playerLook.ZoomOut();
    }

    private void FixedUpdate() => _playerMotor.ProcessMove(_playerActions.Movement.ReadValue<Vector2>());

    private void LateUpdate() => _playerLook.ProcesLook(_playerActions.Look.ReadValue<Vector2>());

    private void OnEnable() => _playerActions.Enable();

    private void OnDisable() => _playerActions.Disable();
}