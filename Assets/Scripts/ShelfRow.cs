using System.Collections.Generic;
using UnityEngine;

public class ShelfRow : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform[] slots;
    private GameObject[] items;

    void Start()
    {
        items = new GameObject[slots.Length];
    }

    public void AddItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (items[i] == null)
            {
                GameObject newItem = Instantiate(itemPrefab);

                newItem.transform.position = slots[i].position;
                newItem.transform.rotation = slots[i].rotation;
              
                newItem.transform.SetParent(slots[i], true);
            
                items[i] = newItem;

                Debug.Log("Slot " + i + " - ürün eklendi.");
                return;
            }
        }

        Debug.Log("Tüm slotlar dolu.");
    }

    public void RemoveItem()
    {
        for (int i = slots.Length - 1; i >= 0; i--)
        {
            if (items[i] != null)
            {
                Destroy(items[i]);
                items[i] = null;
                Debug.Log("Slot " + i + " - ürün kaldýrýldý.");
                return;
            }
        }

        Debug.Log("Hiç ürün yok.");
    }
}
