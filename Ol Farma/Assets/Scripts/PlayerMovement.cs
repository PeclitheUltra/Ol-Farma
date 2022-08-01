using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsMoving
    {
        get
        {
            return _lastFrameMovement != Vector3.zero;
        }
        private set
        {
            return;
        }
    }
    [SerializeField] private CharacterController _controller;
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private float _movementSpeed;

    private Vector3 _lastFrameMovement;

    void Update()
    {
        Vector3 movementVector = Vector3.zero;
        movementVector += Vector3.forward * -_joystick.Vertical;
        movementVector += Vector3.right * -_joystick.Horizontal;
        movementVector *= _movementSpeed * Time.deltaTime;


        _controller.Move(movementVector);

        if(movementVector != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(movementVector, Vector3.up);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 1800f * Time.deltaTime);
            transform.rotation = rotation;
        }

        _lastFrameMovement = movementVector;
    }
}
