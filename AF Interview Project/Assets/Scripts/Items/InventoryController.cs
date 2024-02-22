namespace AFSInterview.Items
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private List<Item> items;
        [SerializeField] private int money;
        ItemsManager manager;

        public int Money => money;
        public int ItemsCount => items.Count;

        private void Start()
        {
            manager = FindObjectOfType<ItemsManager>();
            manager.SetMoneyString();
        }
        public void SellAllItemsUpToValue(int maxValue)
        {
            for (var i = 0; i < items.Count; i++)
            {
                var itemValue = items[i].Value;
                if (itemValue > maxValue)
                    continue;

                money += itemValue;
                manager.SetMoneyString();
                items.RemoveAt(i);
            }
        }

        public void UseItem()
        {
            for (int i = 0; i < items.Count; i++)
            {
                var itemToUse = items[i];
                itemToUse.Use(this);

                if (itemToUse.Type == Item.ItemType.DoNothing)
                {
                    continue;
                }
                else
                {
                    items.RemoveAt(i);
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
                items.Add(item);
          }
        }
    }
