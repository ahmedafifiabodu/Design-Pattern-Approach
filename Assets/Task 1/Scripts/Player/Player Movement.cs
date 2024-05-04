using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private CharacterController _characterController;
    private Vector3 _velocity;

    private void Awake() => ServiceLocator.Instance.RegisterService(this);

    private void Start() => _characterController = GetComponent<CharacterController>();

    internal void ProcessMove(Vector2 _input)
    {
        Vector3 moveDirection = transform.right * _input.x + transform.forward * _input.y;
        moveDirection.y = 0;

        moveDirection.Normalize();

        Vector3 horizontalVelocity = moveDirection * speed;

        _velocity.y += Physics.gravity.y * Time.deltaTime;

        Vector3 finalVelocity = horizontalVelocity + _velocity;

        _characterController.Move(finalVelocity * Time.deltaTime);

        if (_characterController.isGrounded)
            _velocity.y = 0;
    }
}