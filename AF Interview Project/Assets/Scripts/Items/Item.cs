namespace AFSInterview.Items
{
	using System;
	using UnityEngine;

	[Serializable]
	public class Item
	{
		[SerializeField] private string name;
		[SerializeField] private int value;
        [SerializeField] private ItemType type;


        public string Name => name;
		public int Value => value;
        public ItemType Type => type;

        public Item(string name, int value, ItemType type)
		{
			this.name = name;
			this.value = value;
            this.type = type;
        }

        public void Use(InventoryController inventoryController)
        {
            Debug.Log("Using " + Name);
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
        public enum ItemType
        {
            DoNothing,
            SellObject,
            RandomObject,
        }
    }
}