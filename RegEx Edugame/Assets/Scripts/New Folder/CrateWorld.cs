using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class CrateWorld : MonoBehaviour
{
    public static CrateWorld SpawnCrateWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.crateWorld, position, Quaternion.identity);
        //Debug.Log(transform.GetComponent<CrateWorld>());
        CrateWorld crateWorld = transform.GetComponent<CrateWorld>();
        //Debug.Log("c" + crateWorld);
        crateWorld.SetItem(item);

        return crateWorld;
    }

    public static CrateWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        //CrateWorld crateWorld = SpawnCrateWorld(dropPosition + randomDir * 0.2f, item);
        //crateWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 0.2f, ForceMode2D.Impulse);

        CrateWorld crateWorld = SpawnCrateWorld(dropPosition, item);
        //crateWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 1f, ForceMode2D.Impulse);
        //CrateWorld.SpawnCrateWorld(new Vector3(8.308f, 0.35f), new Item { itemType = Item.ItemType.alternation, text = "KG" });

        return crateWorld;
    }

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
