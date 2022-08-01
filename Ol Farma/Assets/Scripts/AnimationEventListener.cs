using UnityEngine;

public class AnimationEventListener : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerCutter _cutter;

    public void Slash()
    {
        _cutter.Cut();
    }

    public void End()
    {
        _animator.ResetTrigger("Slash");
    }
}
