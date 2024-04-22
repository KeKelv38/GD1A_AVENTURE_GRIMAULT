using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int crystalCount;
    public Text crystalCountText;

    public static Inventory inventory;

    public List<Item> content = new List<Item>();
    public int contentCurrentIndex = 0;

    private void Awake()
    {
        if (inventory != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'inventaire dans la scène");
            return;
        }
        inventory = this;
    }

    public void GetNextItem()
    {
        contentCurrentIndex++;
    }

    public void GetPreviousItem()
    {
        contentCurrentIndex--;
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

    public void ConsumeItem()
    {
        Item currentItem = content[contentCurrentIndex];
        BasicMovement.basicMovement.Movespeed += currentItem.speedGiven;
        content.Remove(currentItem);
    }
}
