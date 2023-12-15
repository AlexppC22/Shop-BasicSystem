using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryIcon : MonoBehaviour
{
    [SerializeField] protected Image iconBackGround;
    [SerializeField] protected Image iconImage;
    [SerializeField] protected Button iconButton;
    protected BaseItemHolder inventory;

    public void SelectIcon()
    {
        iconBackGround.color = Color.cyan;
    }

    public void UnSelectIcon()
    {
        iconBackGround.color = Color.white;
    }
}
