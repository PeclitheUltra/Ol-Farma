using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGatherer : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnStacksUpdate;
    [SerializeField] private GameObject _gatheringPoint;
    [SerializeField] private float _radius, _offsetForward;
    [SerializeField] private int _maxWheat;
    private Barn _nearestBarn;
    private Vector3 _castPos => transform.position + transform.forward * _offsetForward;
    private List<CutWheat> _wheats = new List<CutWheat>();

    public int GetStackCount() => _wheats.Count;
    public int GetMaxWheat() => _maxWheat;

    private void Start()
    {
        StartCoroutine(GatheringCoroutine());
        StartCoroutine(SellingCoroutine());
    }

    private IEnumerator GatheringCoroutine()
    {
        while (true)
        {
            var hits = Physics.OverlapSphere(_castPos, _radius);
            foreach (var hit in hits)
            {
                var wheat = hit.GetComponent<CutWheat>();
                if (wheat != null && _wheats.Count < _maxWheat && wheat.IsCollectable)
                {
                    _wheats.Add(wheat);
                    OnStacksUpdate.Invoke();
                    wheat.Collect();
                    wheat.transform.parent = _gatheringPoint.transform;
                    float height = (_wheats.Count / 3) * 0.2f;
                    float horizontalPos = (float)(_wheats.Count % 3 - 1) / 3f;
                    wheat.transform.DOLocalMove(new Vector3(horizontalPos, height, 0f), 0.5f).SetEase(Ease.InOutSine);
                    wheat.transform.DOLocalRotate(new Vector3(0, Random.Range(-25f, 25f), 0), 0.5f);
                    wheat.transform.DOScale(0.3f, 0.5f);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator SellingCoroutine()
    {
        while (true)
        {
            if(_nearestBarn != null && _wheats.Count > 0)
            {
                _nearestBarn.SellWheat(_wheats[_wheats.Count - 1]);
                _wheats.RemoveAt(_wheats.Count - 1);
                OnStacksUpdate.Invoke();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var barn = other.GetComponent<Barn>();
        if (barn != null)
        {
            _nearestBarn = barn;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var barn = other.GetComponent<Barn>();
        if(barn != null)
        {
            _nearestBarn = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_castPos, _radius);
    }
}
