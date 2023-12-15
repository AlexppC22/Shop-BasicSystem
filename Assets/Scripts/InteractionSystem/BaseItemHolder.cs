using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BaseItemHolder : MonoBehaviour
{
    [SerializeField] RectTransform ItensUIParent;
    [SerializeField] RectTransform equipmentUIParent;

    [SerializeField] protected BaseItemHolder targetInventory;
    [SerializeField] protected GameObject inventoryUI;

    [SerializeField] protected List<Item> itemLibrary;
    [SerializeField] protected List<Equipment> equipmentLibrary;

    [SerializeField] protected List<ItemObject> heldItems = new List<ItemObject>();
    [SerializeField] protected List<EquipmentObject> heldEquipments = new List<EquipmentObject>();
    [SerializeField] TextMeshProUGUI heldMoneyText;
    [SerializeField] TextMeshProUGUI itemCostText;
    [SerializeField] TextMeshProUGUI equipmentCostText;

    protected int heldMoney;
    protected ItemObject selectedItemObject;
    protected EquipmentObject selectedEquipmentObject;

    public BaseItemHolder GetInventory()
    {
        return this;
    }
    public int GetHeldMoney()
    {
        return heldMoney;
    }

    public void ChangeHeldMoney(int moneyChange)
    {
        heldMoney += moneyChange;
        heldMoneyText.text = heldMoney.ToString();
    }

    public void SetSelectedItemObject(ItemObject newItemObject)
    {
        if(newItemObject == selectedItemObject) 
        {
            return;
        }
        if(selectedItemObject != null)
        {
            selectedItemObject.icon.UnSelectIcon();
        }
        selectedItemObject = newItemObject;
        selectedItemObject.icon.SelectIcon();
        itemCostText.text = selectedItemObject.itemCost.ToString();
    }

    public void SetSelectedEquipment(EquipmentObject newEquipmentObject)
    {
        if (newEquipmentObject == selectedEquipmentObject)
        {
            return;
        }
        if (selectedEquipmentObject != null)
        {
            selectedEquipmentObject.icon.UnSelectIcon();
        }
        selectedEquipmentObject = newEquipmentObject;
        selectedEquipmentObject.icon.SelectIcon();
        if(equipmentCostText != null)
        {
            equipmentCostText.text = selectedEquipmentObject.equipmentCost.ToString();
        }
    }

    public void SetTargetInventory(BaseItemHolder newInventory)
    {
        if(newInventory == targetInventory) 
        {
            return;
        }

        targetInventory = newInventory;
    }

    public void ToggleUI(bool toggle)
    {
        inventoryUI.SetActive(toggle);
    }

    public void AddItem(Item itemToAdd)
    {
        ItemObject newItemObject = new ItemObject();
        if(heldItems.Count > 23) 
        {
            Debug.LogError("AddItem - Full Inventory");
            return;
        }
        if (!itemLibrary.Contains(itemToAdd))
        {
            Debug.LogError("AddItem - Ivalid Item");
            return;
        }
        else
        {
            Item item = itemLibrary.Where(item => item == itemToAdd).FirstOrDefault();
            newItemObject = item.CreateItemObject();
            var icon = itemToAdd.CreateIcon(ItensUIParent);
            icon.SetupIcon(this);
            icon.SetItemObject(newItemObject);
            newItemObject.SetIcon(icon);
            heldItems.Add(newItemObject);
        }
    }

    public void SellSelectedItem()
    {
        RemoveItem(selectedItemObject);
    }

    public void RemoveItem(ItemObject itemToRemove)
    {
        if (!heldItems.Contains(itemToRemove))
        {
            Debug.LogError("RemoveItem - Ivalid Item");
            return;
        }
        else
        {
            if(itemToRemove == selectedItemObject) 
            {
                itemToRemove.icon.UnSelectIcon();
                selectedItemObject = null;
                itemCostText.text = "-";
            }

            itemToRemove.icon.gameObject.SetActive(false);
            heldItems.Remove(itemToRemove);
            Destroy(itemToRemove.icon.gameObject);
        }
    }

    public void AddEquipment(Equipment newEquipment)
    {
        if (heldEquipments.Count > 11)
        {
            Debug.LogError("AddEquipment - Full Inventory");
            return;
        }
        EquipmentObject newEquipmentObejct = new EquipmentObject();
        if (!equipmentLibrary.Contains(newEquipment))
        {
            Debug.LogError("AddEquipment - Ivalid Equipment");
            return;
        }
        else
        {
            Equipment equipment = equipmentLibrary.Where(equipment => equipment == newEquipment).FirstOrDefault();
            newEquipmentObejct = equipment.CreateEquipmentObject();
            var icon = newEquipment.CreateIcon(equipmentUIParent);
            icon.SetupIcon(this);
            icon.SetEquipmentObject(newEquipmentObejct);
            newEquipmentObejct.SetIcon(icon);
            heldEquipments.Add(newEquipmentObejct);
        }
    }

    public void RemoveEquipment(EquipmentObject equipmentToRemove)
    {
        if (heldEquipments.Contains(equipmentToRemove))
        {
            heldEquipments.Remove(equipmentToRemove);
        }
    }
}
