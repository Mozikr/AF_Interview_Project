namespace AFSInterview.Items
{
	using System.Collections.Generic;
	using UnityEngine;

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

		public void AddItem(Item item)
		{
			items.Add(item);
		}
	}
}