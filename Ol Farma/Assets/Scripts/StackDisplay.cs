using TMPro;
using UnityEngine;

public class StackDisplay : MonoBehaviour
{
    [SerializeField] private PlayerGatherer _gatherer;
    [SerializeField] private TextMeshProUGUI _display;

    private void Awake()
    {
        _gatherer.OnStacksUpdate.AddListener(UpdateDisplay);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _display.text = $"{_gatherer.GetStackCount()}/{_gatherer.GetMaxWheat()}";
    }
}
