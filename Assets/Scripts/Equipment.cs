using UnityEngine;

public class Equipment : MonoBehaviour
{
    private bool isEquipped = false;
    private int currentlyEquipped;
    
    private GameObject lantern;
    private Animator animLantern;

    private GameObject basket;
    private Animator animBasket;

    private GameObject apple;
    private Animator animApple;

    private GameObject flower;
    private Animator animFlower;
    
    public Inventory inventory;
    public AudioSource equipSound;
    
    void Start()
    {
        lantern = GameObject.Find("Lanterne");
        animLantern = lantern.GetComponent<Animator>();
        lantern.SetActive(false);
        
        basket = GameObject.Find("Basket");
        animBasket = basket.GetComponent<Animator>();
        basket.SetActive(false);
        
        apple = GameObject.Find("Apple");
        //animApple = apple.GetComponent<Animator>();
        apple.SetActive(false);
        
        flower = GameObject.Find("Flower");
        //animFlower = flower.GetComponent<Animator>();
        flower.SetActive(false);

        //Sætter Tågen fra start
        RenderSettings.fogDensity = 0.2f;
    }

    void Update()
    {
        if (isEquipped == false) currentlyEquipped = 0;
        ChooseItem();
    }

    void ChooseItem()
    {
        // Lanterne
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HideItems();
            if (!inventory.HasObject("Lanterne")) return;
            RenderSettings.fogDensity = 0.1f; // 4
            lantern.SetActive(true);
            isEquipped = true;
            equipSound.Play();
            animLantern.Play("Lantern_Draw");
            if (currentlyEquipped == 1)
            {
                if (isEquipped == true)
                {
                    RenderSettings.fogDensity = 0.2f;
                    isEquipped = false;
                    HideItems();
                }
            }
            currentlyEquipped = 1;
        }
        // Kurv
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HideItems();
            if (!inventory.HasObject("Basket")) return;
            basket.SetActive(true);
            isEquipped = true;
            equipSound.Play();
            animBasket.Play("Basket_Draw");
            if (currentlyEquipped == 2)
            {
                if (isEquipped == true)
                {
                    isEquipped = false;
                    HideItems();
                }
            }
            currentlyEquipped = 2;
        }
        // Æble
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HideItems();
            if (!inventory.HasObject("Apple")) return;
            apple.SetActive(true);
            isEquipped = true;
            equipSound.Play();
            //animApple.Play("Apple_Draw");
            if (currentlyEquipped == 3)
            {
                if (isEquipped == true)
                {
                    isEquipped = false;
                    HideItems();
                }
            }
            currentlyEquipped = 3;
        }
        // Blomst
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            HideItems();
            if (!inventory.HasObject("Flower")) return;
            flower.SetActive(true);
            isEquipped = true;
            equipSound.Play();
            //animFlower.Play("Flower_Draw");
            if (currentlyEquipped == 4)
            {
                if (isEquipped == true)
                {
                    isEquipped = false;
                    HideItems();
                }
            }
            currentlyEquipped = 4;
        }
    }

    void HideItems()
    {
        lantern.SetActive(false);
        basket.SetActive(false);
        apple.SetActive(false);
        flower.SetActive(false);
        RenderSettings.fogDensity = 0.2f;
    }

    public int GetCurrentlyEquipped()
    {
        return currentlyEquipped;
    }
}

