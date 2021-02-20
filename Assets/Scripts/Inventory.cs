using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<string> Items = new List<string>();

    public TMP_Text itemCountText;
    
    private bool hasApple = false;
    private bool hasFlower = false;
    private bool hasBasket = false;
    private bool hasLantern = false;
    
    private int appleCount;
    private int flowerCount;

    public Equipment equipment;

    private void Update()
    {
        ShowInventory();
    }

    private void ShowInventory()
    {
        var item = equipment.GetCurrentlyEquipped();
        itemCountText.color = new Color(itemCountText.color.r, itemCountText.color.g, itemCountText.color.b, 1);
        switch (item)
        {
            case 3:
                itemCountText.SetText("{0}", appleCount);
                break;
            case 4:
                itemCountText.SetText("{0}", flowerCount);
                break;
            default:
                itemCountText.SetText("");
                break;
        }
    }
    
    public void AddToInventory(string item)
    {
        switch (item)
        {
            case "Apple":
                Items.Add("Apples");
                appleCount += 1;
                hasApple = true;
                break;
            case "Flower":
                Items.Add("Flower");
                hasFlower = true;
                flowerCount += 1;
                break;
            case "Basket":
                Items.Add("Basket");
                hasBasket = true;
                break;
            case "Lantern":
                Items.Add("Lantern");
                hasLantern = true;
                break;
        }
    }

    public bool HasObject(string item)
    {
        return item switch
        {
            "Lanterne" => hasLantern,
            "Basket" => hasBasket,
            "Apple" => hasApple,
            "Flower" => hasFlower,
            _ => false
        };
    }

    public int FlowerAmount()
    {
        return flowerCount;
    }

    public int AppleAmount()
    {
        return appleCount;
    }
}
