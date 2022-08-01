using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        _animator.SetBool("IsMoving", _movement.IsMoving);
    }

    public void Slash()
    {
        _animator.SetTrigger("Slash");
    }
}
