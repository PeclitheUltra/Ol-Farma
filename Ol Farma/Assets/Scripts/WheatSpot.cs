using DG.Tweening;
using System.Collections;
using UnityEngine;

public class WheatSpot : MonoBehaviour
{
    [SerializeField] private GameObject _wheatModel, _cutWheatPrefab;
    [SerializeField] private ParticleSystem _cutFX;
    [SerializeField] private float _growTime;
    private bool _isReady = true;

    [ContextMenu("CutDown")]
    public void CutDown()
    {
        if (!_isReady)
            return;
        _cutFX.Play();
        _wheatModel.transform.localPosition = Vector3.down * 1.49f;
        Vector3 jumpPos = transform.position + transform.right * Random.Range(-1f, 1f) + transform.forward * Random.Range(-1f, 1f);
        Quaternion jumpRot = Quaternion.identity * Quaternion.Euler(0, Random.Range(-45f, 45f), 0);

        var wheat = Instantiate(_cutWheatPrefab, transform.position, Quaternion.identity, null);
        wheat.transform.DOJump(jumpPos, 1f, 1, 0.3f).OnComplete(() =>  wheat.GetComponent<CutWheat>().IsCollectable = true);

        StartCoroutine(GrowCoroutine());
    }

    private IEnumerator GrowCoroutine()
    {
        _isReady = false;
        yield return new WaitForSeconds(_growTime + Random.Range(-0.5f, 0.5f));
        _wheatModel.transform.DOLocalMoveY(-0.5f, 0.2f).SetEase(Ease.OutBack);
        _isReady = true;
    }
}
