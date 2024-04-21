using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int crystalCount;
    public Text crystalCountText;

    public static Inventory inventory;

    private void Awake()
    {
        if(inventory != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'inventaire dans la scène");
            return;
        }
        inventory = this;
    }

    public void AddCrystal(int count)
    {
        crystalCount += count;
        crystalCountText.text = crystalCount.ToString();
    }

    public void RemoveCrystals(int count)
    {
        crystalCount -= count;
        crystalCountText.text = crystalCount.ToString();
    }
}
