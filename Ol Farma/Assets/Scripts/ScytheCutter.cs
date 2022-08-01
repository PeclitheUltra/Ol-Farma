using UnityEngine;

public class ScytheCutter : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var spot = other.GetComponent<WheatSpot>();
        if (spot != null)
        {
            spot.CutDown();
        }
    }
}
