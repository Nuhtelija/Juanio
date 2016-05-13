using UnityEngine;
using System.Collections;
/// <summary>
///define our items
/// </summary>
public enum ItemType {WATER, ETHANOL, VODKA};

public class Item : Inventory
{

    public ItemType type;

    public Sprite spriteNeutral;

    public Sprite spriteHighlighted;

    public int maxSize;

    public static int used;
    /// <summary>
    /// Do different actions if item what is used is either water, ethanol or vodka
    /// </summary>
    public void Use()
    {
        switch (type)
        {
            case ItemType.WATER:
                Debug.Log("Water used.");
                used++;
                break;
            case ItemType.ETHANOL:
                Debug.Log("Ethanol used.");
                used++;
                break;
            case ItemType.VODKA:
                Debug.Log("Vodka given");
                Destroy(GameObject.Find("Door").gameObject);
                used = 0;
                break;
            default:
                break;
        }
    }
}
