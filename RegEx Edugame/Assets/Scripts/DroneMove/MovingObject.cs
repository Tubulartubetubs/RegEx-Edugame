using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    float moveX, moveY;

    public float speed = 5f;

    public BoxCollider2D bound;

    private Vector3 minBound;
    private Vector3 maxBound;

    [SerializeField] private UIInventory uiInventory;
    private Inventory inventory;
    
    /*private void Awake()
    {
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        
        ItemWorld.SpawnItemWorld(new Vector3(1.6f, 0.5f), new Item { itemType = Item.ItemType.alternation, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(1.6f, 0.8f), new Item { itemType = Item.ItemType.single, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(1.6f, 1.2f), new Item { itemType = Item.ItemType.digits, amount = 1 });
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);

        float clampX = Mathf.Clamp(this.transform.position.x, minBound.x, maxBound.x);
        float clampY = Mathf.Clamp(this.transform.position.y, minBound.y, maxBound.y);

        this.transform.position = new Vector3(clampX, clampY, this.transform.position.z);
    }
}
