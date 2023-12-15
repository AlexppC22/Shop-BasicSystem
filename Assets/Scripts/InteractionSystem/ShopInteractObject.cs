using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInteractObject : BaseItemHolder
{
    [SerializeField] string shopName;
    [SerializeField] Button buyButton;

    public string GetShopName()
    {
        return shopName;
    }

    private void Start()
    {
        SetupShop();
    }
    private void SetupShop()
    {
        foreach(var equipment in equipmentLibrary)
        {
            AddEquipment(equipment);
        }
    }

    public void BuyButton()
    {
        if(targetInventory.GetHeldMoney() < selectedEquipmentObject.equipmentCost) 
        {
            Debug.LogError("Not enough money");
        }
        targetInventory.ChangeHeldMoney(-selectedEquipmentObject.equipmentCost);
        targetInventory.AddEquipment(selectedEquipmentObject.equipment);
    }
}
