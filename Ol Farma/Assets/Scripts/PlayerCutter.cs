using UnityEngine;

public class PlayerCutter : MonoBehaviour
{
    [SerializeField] private float _radius, _offsetForward;
    private Vector3 _castPos => transform.position + transform.forward * _offsetForward;

    public void Cut()
    {
        var hits = Physics.OverlapSphere(_castPos, _radius);
        foreach (var hit in hits)
        {
            var spot = hit.GetComponent<WheatSpot>();
            if (spot != null)
            {
                spot.CutDown();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_castPos, _radius);
    }
}
