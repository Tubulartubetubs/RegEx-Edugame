using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    float moveX, moveY;

    public float speed = 3f;

    public BoxCollider2D bound;

    private Vector3 minBound;
    private Vector3 maxBound;

    [SerializeField] private UIInventory uiInventory;
    private Inventory inventory;

    [SerializeField] private UICrate uiCrate;
    private Crate crate;

    public Vector3[] vectors;
    public Item.ItemType[] chipSpriteType;
    public string[] chipText;

    public Item.ItemType[] crateSpriteType;
    public int[] crateNumber;

    private int chipsCollected = 0;
    public int chipsToBeCollected;

    // Start is called before the first frame update
    void Start()
    {
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        crate = new Crate();
        uiCrate.SetCrate(crate);
        uiCrate.SetPlayer(this);

        //ItemWorld.SpawnItemWorld(new Vector3(8.308f, 0.35f), new Item { itemType = Item.ItemType.alternation, text = "KG"});
        //ItemWorld.SpawnItemWorld(new Vector3(33.203f, 1.136f), new Item { itemType = Item.ItemType.single, text = "65" });

        for(int i = 0; i< chipSpriteType.Length; i++)
        {
            ItemWorld.SpawnItemWorld(vectors[i], new Item { itemType = chipSpriteType[i], text = chipText[i] });
        }

        for (int i = 0; i < crateSpriteType.Length; i++)
        {
            crate.AddItem(new Item { itemType = crateSpriteType[i], number = crateNumber[i] });
        }

        chipsToBeCollected = chipSpriteType.Length;
        //Debug.Log(chipsToBeCollected);


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            chipsCollected++;
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

        if(chipsCollected == chipsToBeCollected)
        {
            //Debug.Log("Collected Every Chips!");
            if (uiCrate.DoneCrate())
            {
                //Debug.Log("Cleared!");
                //Cleared
            }
        }
    }

    public Vector3 GetPosition()
    {
        //Debug.Log(transform.position);
        return transform.position;
    }
}
