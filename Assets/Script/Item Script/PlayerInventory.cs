using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;

    private void Awake()
    {
        Instance = this;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(10, 10), new Item { itemType = Item.ItemType.Sword, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(-10, 10), new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(0, -10), new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            // Touching Item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
