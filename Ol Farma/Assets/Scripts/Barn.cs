using DG.Tweening;
using UnityEngine;

public class Barn : MonoBehaviour
{
    [SerializeField] private int _coinsPerStack;

    public void SellWheat(CutWheat wheat)
    {
        wheat.transform.parent = transform;
        wheat.transform.DOLocalMove(new Vector3(0f, 0f, 0f), 0.5f).SetEase(Ease.InSine).OnComplete(() => TurnWheatIntoCoins(wheat));
        Economy.Instance.AddCoins(transform, _coinsPerStack);
    }

    private void TurnWheatIntoCoins(CutWheat wheat)
    {
        Destroy(wheat.gameObject);
    }
}
