using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreVein : MonoBehaviour
{
    [SerializeField] List<Item> ores = new List<Item>();
    public void AddOreToPlayer(BaseItemHolder inventory)
    {
        inventory.AddItem(ores[0]);
    }
}
