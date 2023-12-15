using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;
    
    [SerializeField] PlayerInventorySystem inventory;
    [SerializeField] InteractionSystem interactionSystem;
    bool isInShopRange;
    [SerializeField] ShopInteractObject shopToInteract;
    [SerializeField] OreVein oreToInteract;
    bool isInIOreRange;

    bool shopIsOpen = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInShopRange && !shopIsOpen)
            {
                inventory.SetTargetInventory(shopToInteract);
                shopToInteract.SetTargetInventory(inventory);
                interactionSystem.SetFeedbackText("Opened Shop");
                ToggleShop(true);

            }
            else if(shopIsOpen)
            {
                interactionSystem.SetFeedbackText("Closed Shop");
                ToggleShop(false);
            }

            if(isInIOreRange)
            {
                interactionSystem.SetFeedbackText("Mining!");
                oreToInteract.AddOreToPlayer(inventory);
            }
        }
    }

    private void ToggleShop(bool toggle)
    {
        shopToInteract.ToggleUI(toggle);
        shopIsOpen = toggle;
        inventory.SetInShop(toggle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.CompareTag("ShopKeeper"))
        {
            shopToInteract = collision.gameObject.transform.GetComponent<ShopInteractObject>();
            shopToInteract.SetTargetInventory(inventory);
            interactionSystem.SetUIText("Press E to open the Shop");
            isInShopRange = true;
            inventory.SetInShop(true);
        }
        if (collision.gameObject.transform.CompareTag("OreVein"))
        {
            oreToInteract = collision.gameObject.transform.GetComponent<OreVein>();
            interactionSystem.SetUIText("Press E to mine for emeralds");
            isInIOreRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.transform.CompareTag("ShopKeeper"))
        {
            ToggleShop(false);
            interactionSystem.ToggleUIText(false); 
            isInShopRange = false;
        }
        if (collision.gameObject.transform.CompareTag("OreVein"))
        {
            isInIOreRange = false;
            interactionSystem.ToggleUIText(false);
        }
    }
}