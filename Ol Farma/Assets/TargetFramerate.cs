using UnityEngine;

public class TargetFramerate : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
