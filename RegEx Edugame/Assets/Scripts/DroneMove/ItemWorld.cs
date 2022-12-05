using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        //Debug.Log(transform);
        itemWorld.SetItem(item);

        return itemWorld;
    }

    //public static ItemWorld SpawnChip(Item item) //for chip scene
    //{
    //    RectTransform transform1 = Instantiate(ItemAssets.Instance.chip, new Vector3(0,0,0), Quaternion.identity);
    //    ItemWorld itemWorld = transform1.GetComponent<ItemWorld>();
    //    Debug.Log(itemWorld);
    //    itemWorld.SetItem(item);
        

    //    return itemWorld;
    //}

    private Item item;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
