using TMPro;
using UnityEngine;

public class UnitCardUI : MonoBehaviour
{
    [Header("Unit Info")]
    [SerializeField] private string unitName;
    [SerializeField] private int unitCost = 50;

    [Header("UI")]
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private TMP_Text currencyText;

    private void Start()
    {
        // Goku can be free/default if you want
        if (unitName == "Goku")
        {
            UnitShopData.OwnUnit(unitName);
        }

        Refresh();
    }

    public void BuyOrSelectUnit()
    {
        if (UnitShopData.IsUnitOwned(unitName))
        {
            UnitShopData.SelectUnit(unitName);
            Refresh();
            return;
        }

        if (!PlayerData.CanAfford(unitCost))
        {
            if (statusText != null)
                statusText.text = "Not enough currency";

            return;
        }

        PlayerData.SpendCurrency(unitCost);
        UnitShopData.OwnUnit(unitName);
        UnitShopData.SelectUnit(unitName);

        Refresh();
    }

    public void Refresh()
    {
        bool owned = UnitShopData.IsUnitOwned(unitName);
        bool selected = UnitShopData.GetSelectedUnit() == unitName;

        if (statusText != null)
        {
            if (selected)
                statusText.text = "Selected";
            else if (owned)
                statusText.text = "Owned";
            else
                statusText.text = "Cost: " + unitCost;
        }

        if (buttonText != null)
        {
            buttonText.text = owned ? "Select" : "Buy";
        }

        if (currencyText != null)
        {
            currencyText.text = "Currency: " + PlayerData.GetCurrency();
        }
    }
}