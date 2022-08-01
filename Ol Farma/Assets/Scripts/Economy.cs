using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public static Economy Instance;
    [HideInInspector] public UnityEvent OnChange;
    [SerializeField] private GameObject _coinPrefab, _coinIcon;
    private int _coins;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            Debug.LogWarning("Bruh");
        }
    }

    public int GetCoins() => _coins;
    public void AddCoins(Transform source, int value)
    {
        Vector3 spawnPos = Camera.main.WorldToScreenPoint(source.position);
        var coin = Instantiate(_coinPrefab, spawnPos, Quaternion.identity, transform);
        coin.transform.DOMove(_coinIcon.transform.position, 0.5f).SetEase(Ease.InCubic).OnComplete(() => {
            _coins += value;
            OnChange.Invoke();
            coin.transform.DOScale(1.5f, 0.2f);
            coin.GetComponent<Image>().DOFade(0f, 0.2f);
            Destroy(coin, 0.3f);
        });
    }
}
