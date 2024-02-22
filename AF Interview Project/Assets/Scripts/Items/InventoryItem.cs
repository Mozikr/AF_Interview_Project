using AFSInterview.Items;
using System;
using UnityEngine;
using static AFSInterview.Items.InventoryController;

namespace AFSInterview
{
    [Serializable]
    public class InventoryItem
    {
        public Item item;
        public ItemType Type;

        public enum ItemType
        {
            DoNothing,
            SellObject,
            RandomObject,
        }

        public InventoryItem(Item item, ItemType type)
        {
            this.item = item;
            Type = type;
        }

        public void Use(InventoryController inventoryController)
        {
            switch (Type)
            {
                case ItemType.DoNothing:
                    break;
                case ItemType.SellObject:
                    inventoryController.AddMoney(30);
                    break;
                case ItemType.RandomObject:
                    inventoryController.RandomObject();
                    break;
                default:
                    Debug.LogWarning("Unhandled item type: " + Type);
                    break;
            }
        }
    }
}
