using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _display;
    private int _coins;
    private Vector3 _displayStartPos;

    private void Start()
    {
        _displayStartPos = _display.transform.localPosition;
        Economy.Instance.OnChange.AddListener(UpdateDisplay);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        DOTween.Complete(_coins);
        DOTween.To(() => _coins, x => _coins = x, Economy.Instance.GetCoins(), 1f).OnUpdate(() => _display.text = _coins.ToString());
        StartCoroutine(CustomShake(1f));
    }

    private IEnumerator CustomShake(float time)
    {
        for(float t = 0; t < 1; t += Time.deltaTime / time)
        {
            _display.transform.localPosition = _displayStartPos + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
            yield return null;
        }
        _display.transform.localPosition = _displayStartPos;

    }
}
