using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EquipmentType
{
    Clothes
}
[Serializable]
public class EquipmentObject
{
    public Equipment equipment;
    public EquipmentIcon icon;
    public EquipmentType equipType;
    public string equipmentName;
    public int equipmentCost;
    public Sprite equipmentGameSprite;

    public void SetIcon(EquipmentIcon icon)
    {
        this.icon = icon;
    }
}
[CreateAssetMenu(fileName = "Equipment", menuName = "ScriptableObjects/Equipment")]
public class Equipment : ScriptableObject
{
    public string equipmentName;
    public int equipmentCost;
    public EquipmentType equipType;
    public Sprite equipmentIconSprite;
    public Sprite equipmentGameSprite;
    public EquipmentIcon equipmentPrefab;
    public EquipmentIcon icon;

    public EquipmentIcon CreateIcon(Transform parent)
    {
        var prefab = Instantiate(equipmentPrefab, parent);
        icon = prefab.GetComponent<EquipmentIcon>();
        icon.SetImage(equipmentIconSprite);
        return icon;
    }

    public EquipmentObject CreateEquipmentObject()
    {
        EquipmentObject newItemObject = new EquipmentObject();

        newItemObject.equipmentName = equipmentName;
        newItemObject.equipmentCost = equipmentCost;
        newItemObject.icon = icon;
        newItemObject.equipType = equipType;
        newItemObject.equipment = this;
        newItemObject.equipmentGameSprite = equipmentGameSprite;

        return newItemObject;
    }
}
