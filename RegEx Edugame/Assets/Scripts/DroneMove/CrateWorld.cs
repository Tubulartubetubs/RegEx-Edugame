using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class CrateWorld : MonoBehaviour
{
    public BoxCollider2D bound;


    public static CrateWorld SpawnCrateWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.crateWorld, position, Quaternion.identity);
        CrateWorld crateWorld = transform.GetComponent<CrateWorld>();
        crateWorld.SetItem(item);

        return crateWorld;
    }

    public static CrateWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        CrateWorld crateWorld = SpawnCrateWorld(dropPosition, item);
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
