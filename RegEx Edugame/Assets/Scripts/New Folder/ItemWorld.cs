using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        //Debug.Log(transform.GetComponent<ItemWorld>());
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        //Debug.Log("i"+itemWorld);
        itemWorld.SetItem(item);

        return itemWorld;
    }
    /*public static ItemWorld SpawnCrateWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.crateWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }*/

    /*public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        //ItemWorld itemWorld = SpawnItemWorld(dropPosition, item);
        //itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 1f, ForceMode2D.Impulse);
        //ItemWorld.SpawnItemWorld(new Vector3(8.308f, 0.35f), new Item { itemType = Item.ItemType.alternation, text = "KG" });
        ItemWorld itemWorld = SpawnCrateWorld(dropPosition + randomDir * 0.5f, item);
        itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 0.5f, ForceMode2D.Impulse);

        return itemWorld;
    }*/

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
