namespace AFSInterview.Items
{
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

    public class ItemsManager : MonoBehaviour
    {
        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private int itemSellMaxValue;
        [SerializeField] private Transform itemSpawnParent;
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private BoxCollider itemSpawnArea;
        [SerializeField] private float itemSpawnInterval;
        [SerializeField] private TextMeshProUGUI moneyText;

        private float nextItemSpawnTime;
        private List<GameObject> itemPool = new List<GameObject>();

        private void Start()
        {
            // Inicjalizacja puli obiektów przy starcie
            InitializeObjectPool();
        }

        private void InitializeObjectPool()
        {
            for (int i = 0; i < 10; i++) // Możesz dostosować ilość obiektów w puli
            {
                GameObject newItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
                newItem.SetActive(false);
                itemPool.Add(newItem);
            }
        }

        private void Update()
        {
            if (Time.time >= nextItemSpawnTime)
                SpawnNewItem();

            if (Input.GetMouseButtonDown(0))
                TryPickUpItem();

            if (Input.GetKeyDown(KeyCode.Space))
                inventoryController.SellAllItemsUpToValue(itemSellMaxValue);

            if (Input.GetKeyDown(KeyCode.E))
                inventoryController.UseItem();
        }

        private void SpawnNewItem()
        {
            nextItemSpawnTime = Time.time + itemSpawnInterval;

            // Pobieranie obiektu z puli
            GameObject newItem = GetObjectFromPool();

            if (newItem != null)
            {
                var spawnAreaBounds = itemSpawnArea.bounds;
                var position = new Vector3(
                    Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
                    0f,
                    Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
                );

                newItem.transform.position = position;
                newItem.SetActive(true);
            }
        }

        private void TryPickUpItem()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var layerMask = LayerMask.GetMask("Item");
            if (!Physics.Raycast(ray, out var hit, 100f, layerMask) || !hit.collider.TryGetComponent<IItemHolder>(out var itemHolder))
                return;

            var item = itemHolder.GetItem(true);
            inventoryController.AddItem(item);
            Debug.Log("Picked up " + item.Name + " with value of " + item.Value + " and now have " + inventoryController.ItemsCount + " inventory");

            // Zwracanie obiektu do puli
            ReturnObjectToPool(hit.collider.gameObject);
        }

        private GameObject GetObjectFromPool()
        {
            foreach (var item in itemPool)
            {
                if (item != null && !item.activeInHierarchy)
                    return item;
            }

            // Jeśli nie ma dostępnych obiektów w puli, możesz dodać nowy obiekt do puli
            GameObject newItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            newItem.SetActive(false);
            itemPool.Add(newItem);

            return newItem;
        }

        private void ReturnObjectToPool(GameObject item)
        {
            item.SetActive(false);
        }

        public void SetMoneyString()
        {
            moneyText.text = "Money: " + inventoryController.Money;
        }
    }
}
