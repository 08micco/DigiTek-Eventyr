using UnityEngine;

public class Interact : MonoBehaviour
{
    public Camera playerCamera;
    public Inventory inventory;
    private int pickupRange = 3;
    void Update()
    {
        RaycastHit hitInfo; // Holder information om det gameobject vi rammer
        Ray r = new Ray(playerCamera.transform.position, playerCamera.transform.forward); // Ray fra kameraet og lige frem
        // Hvis man kigger på noget
        if (Physics.Raycast(r, out hitInfo) && hitInfo.distance <= pickupRange)
        {
            var resetTime = 1.0f;
            // Hvis man rammer visse objekter kan man interagere med dem
            if (hitInfo.transform.CompareTag("Apple"))
            {
                var outlineApple = hitInfo.collider.gameObject.GetComponent<Outline>();
                outlineApple.enabled = true;
                
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Destroy(hitInfo.collider.gameObject);
                    inventory.AddToInventory("Apple");
                }
                
            }
            else if (hitInfo.transform.CompareTag("Flower") && hitInfo.distance <= pickupRange)
            {
                var outlineFlower = hitInfo.collider.gameObject.GetComponent<Outline>();
                outlineFlower.enabled = true;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Destroy(hitInfo.collider.gameObject);
                    inventory.AddToInventory("Flower");
                }
            }
            else if (hitInfo.transform.CompareTag("Lantern") && hitInfo.distance <= pickupRange)
            {
                var outlineLantern = hitInfo.collider.gameObject.GetComponent<Outline>();
                outlineLantern.enabled = true;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Destroy(hitInfo.collider.gameObject);
                    inventory.AddToInventory("Lantern");
                }
                
            }
            else if (hitInfo.transform.CompareTag("Basket") && hitInfo.distance <= pickupRange)
            {
                var outlineBasket = hitInfo.collider.gameObject.GetComponent<Outline>();
                outlineBasket.enabled = true;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Destroy(hitInfo.collider.gameObject);
                    inventory.AddToInventory("Basket");
                }
            }

            resetTime -= Time.deltaTime;
            if (resetTime < 0) resetTime = 1;
        }
    }
/*
    private void LateUpdate()
    {
        outlineApple.enabled = false;
        outlineFlower.enabled = false;
        outlineLantern.enabled = false;
        outlineBasket.enabled = false;
    }
    */
}
