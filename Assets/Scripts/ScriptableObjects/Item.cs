using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
[Serializable]
public class ItemObject
{
    public Item item;
    public ItemIcon icon;
    public string itemName;
    public int itemCost;

    public void SetIcon(ItemIcon icon)
    {
        this.icon = icon;
    }
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int itemCost;

    public ItemIcon itemPrefab;
    public Sprite itemSprite;

    public ItemIcon icon;

    public ItemIcon CreateIcon(Transform parent)
    {
        var prefab = Instantiate(itemPrefab, parent);
        icon = prefab.GetComponent<ItemIcon>();
        icon.SetImage(itemSprite);
        return icon;
    }

    public ItemObject CreateItemObject()
    {
        ItemObject newItemObject = new ItemObject();

        newItemObject.itemName = itemName;
        newItemObject.itemCost = itemCost;
        newItemObject.icon = icon;
        newItemObject.item = this;

        return newItemObject;
    }
}
