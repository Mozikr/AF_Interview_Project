namespace AFSInterview.Items
{
	using System;
	using UnityEngine;

    [CreateAssetMenu]
    public class Item : ScriptableObject
	{
		[SerializeField] private string name;
		[SerializeField] private int value;

        public string Name => name;
		public int Value => value;

        public Item(string name, int value)
		{
			this.name = name;
			this.value = value;
        }
    }
}