using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventorySystem : BaseItemHolder
{
    private Equipment equipedHelmet;
    private EquipmentObject equipedClothes;

    [SerializeField] Button sellItensButton;
    [SerializeField] Button equipClothesButton;

    [SerializeField] SpriteRenderer clothesRenderer;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleUI(!inventoryUI.activeInHierarchy);
        }
    }

    public void SellItem()
    {
        ChangeHeldMoney(selectedItemObject.itemCost);
        RemoveItem(selectedItemObject);
        Debug.Log($"Current Money - {heldMoney}");
    }

    public void SetInShop(bool inShop)
    {
        sellItensButton.interactable = inShop;
    }

    public void EquipClothes()
    {
        if (selectedEquipmentObject.equipType != EquipmentType.Clothes)
        {
            Debug.LogError("Invalid equipment Type");
            return;
        }

        if (equipedClothes == selectedEquipmentObject)
        {
            Debug.LogError("Clothes already equipped");
            return;
        }

        if (equipedClothes != null)
        {
            equipedClothes.icon.ToggleEquiped(false);
        }

        equipedClothes = selectedEquipmentObject;
        equipedClothes.icon.ToggleEquiped(true);

        clothesRenderer.sprite = equipedClothes.equipmentGameSprite;
        clothesRenderer.gameObject.SetActive(true);
    }

    public void UnequipClothes()
    {
        if (equipedClothes == null)
        {
            Debug.LogError("No Clothes equipped");
            return;
        }

        clothesRenderer.gameObject.SetActive(false);
        equipedClothes.icon.ToggleEquiped(false);
        equipedClothes = null;

    }
}
