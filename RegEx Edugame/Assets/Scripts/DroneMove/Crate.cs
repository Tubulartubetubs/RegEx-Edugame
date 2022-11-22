using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Crate()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.green, number = 0 });
        AddItem(new Item { itemType = Item.ItemType.blue, number = 1 });
        AddItem(new Item { itemType = Item.ItemType.yellow, number = 2 });
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList() {
        return itemList;
    }

}
