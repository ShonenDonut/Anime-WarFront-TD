using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionManager : MonoBehaviour
{
    public static UnitSelectionManager Instance;

    public List<string> activeUnits = new List<string>();
    [SerializeField] private int maxActiveUnits = 2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleUnit(string unitName)
    {
        if (activeUnits.Contains(unitName))
        {
            activeUnits.Remove(unitName);
        }
        else
        {
            if (activeUnits.Count < maxActiveUnits)
            {
                activeUnits.Add(unitName);
            }
        }
    }

    public bool IsUnitActive(string unitName)
    {
        return activeUnits.Contains(unitName);
    }
}