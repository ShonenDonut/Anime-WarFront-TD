using TMPro;
using UnityEngine;

public class UnitCardUI : MonoBehaviour
{
    [SerializeField] private string unitName;
    [SerializeField] private TMP_Text statusText;

    private void Start()
    {
        Refresh();
    }

    public void ToggleUnit()
    {
        if (UnitSelectionManager.Instance != null)
        {
            UnitSelectionManager.Instance.ToggleUnit(unitName);
            Refresh();
        }
    }

    public void Refresh()
    {
        if (UnitSelectionManager.Instance == null || statusText == null) return;

        bool isActive = UnitSelectionManager.Instance.IsUnitActive(unitName);
        statusText.text = isActive ? "Active" : "Inactive";
    }
}