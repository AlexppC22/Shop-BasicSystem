using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipmentIcon : InventoryIcon
{
    private EquipmentObject equipmentObject;
    private EquipmentType equipmentType;
    [SerializeField] Image isEquippedImage;

    public void SetupIcon(BaseItemHolder inventory)
    {
        this.inventory = inventory;
    }
    public void SetImage(Sprite receivedSprite)
    {
        iconImage.sprite = receivedSprite;
    }
    public void SetEquipmentObject(EquipmentObject newEquipmentObject)
    {
        equipmentObject = newEquipmentObject;
    }

    public void SetEquipmentAsSelected()
    {
        inventory.SetSelectedEquipment(equipmentObject);
    }

    public void ToggleEquiped(bool isEquipped)
    {
        isEquippedImage.gameObject.SetActive(isEquipped);
    }
}
