namespace AFSInterview.Items
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private List<InventoryItem> inventory;
        [SerializeField] private int money;
        [SerializeField]
        private Item[] allItems;
        ItemsManager manager;

        public int Money => money;
        public int ItemsCount => inventory.Count;

        private void Start()
        {
            manager = FindObjectOfType<ItemsManager>();
            manager.SetMoneyString();
        }
        public void SellAllItemsUpToValue(int maxValue)
        {
            for (var i = 0; i < inventory.Count; i++)
            {
                var itemValue = inventory[i].item.Value;
                if (itemValue > maxValue)
                    continue;

                money += itemValue;
                manager.SetMoneyString();
                inventory.RemoveAt(i);
            }
        }

        public void UseItem()
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                var itemToUse = inventory[i];
                itemToUse.Use(this);

                if (itemToUse.Type == InventoryItem.ItemType.DoNothing)
                {
                    continue;
                }
                else
                {
                    inventory.RemoveAt(i);
                    manager.SetMoneyString();
                    break;
                }
            }
        }

        public void AddMoney(int cash)
          {
                money += cash;
                manager.SetMoneyString();
                Debug.Log("Dodano" + cash);
          }

        public void RandomObject()
        {
            Debug.Log("AddRandomObject");
        }

        public void AddItem(Item item)
          {
                inventory.Add(new InventoryItem(item,InventoryItem.ItemType.DoNothing));
          }
        }
}
