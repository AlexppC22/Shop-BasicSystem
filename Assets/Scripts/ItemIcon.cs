using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemIcon : InventoryIcon
{
    private ItemObject itemObject;

    public void SetupIcon(BaseItemHolder inventory)
    {
        this.inventory = inventory;
    }
    public void SetImage(Sprite receivedSprite)
    {
        iconImage.sprite = receivedSprite;
    }
    public void SetItemObject(ItemObject newItemObject)
    {
        itemObject = newItemObject;
    }

    public void SetItemAsSelected()
    {
        inventory.SetSelectedItemObject(itemObject);
    }
}
