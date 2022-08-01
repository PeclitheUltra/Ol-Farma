using DG.Tweening;
using UnityEngine;

public class CutWheat : MonoBehaviour
{
    public bool IsCollectable = false;
    [SerializeField] private Collider _collider;

    public void Collect()
    {
        _collider.enabled = false;
        transform.DOKill();
    }
}
