using System;
using System.Collections.Generic;
using static Define;

public class ItemManager
{
    
    public Item GetItemObject(string itemName)
    {
        if (string.IsNullOrEmpty(itemName))
            return null;

        var itemTypeArr = Enum.GetValues(typeof(ItemType));
        ItemType findItemType = ItemType.End;
        foreach (ItemType itemType in itemTypeArr)
        {
            if (itemType.ToString().Equals(itemName))
            {
                findItemType = itemType;
                break;
            }
        }

        if (findItemType == ItemType.End)
            return null;

        Item item = null;
        Dictionary<int, Item> itemDict = GameManager.Data.ItemDict;
        if (itemDict.TryGetValue( (int)findItemType, out item) == false)
            return null;

        return item;
    }
}
