using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool hasApple = false;
    private bool hasFlower = false;
    private bool hasBasket = false;
    private bool hasLantern = false;
    
    private int appleCount;
    private int flowerCount;
    
    public TMP_Text itemCountText;

    public Equipment equipment;

    private void Update()
    {
        ShowInventory();
    }

    private void ShowInventory()
    {
        var item = equipment.GetCurrentlyEquipped();
        itemCountText.color = new Color(itemCountText.color.r, itemCountText.color.g, itemCountText.color.b, 1);
        // item = (1, Lanterne), (2, Kurv), (3, Æble), (4, Blomst)
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
                appleCount += 1;
                hasApple = true;
                break;
            case "Flower":
                hasFlower = true;
                flowerCount += 1;
                break;
            case "Basket":
                hasBasket = true;
                break;
            case "Lantern":
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
