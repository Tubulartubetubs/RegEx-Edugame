using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingObject : MonoBehaviour
{
    public Animator anim;

    float moveX, moveY;

    public float speed = 3f;

    public BoxCollider2D bound;

    private Vector3 minBound;
    private Vector3 maxBound;

    [SerializeField] private UIInventory uiInventory;
    private Inventory inventory;

    [SerializeField] private UICrate uiCrate;
    private Crate crate;

    public Item.ItemType[] chipInventorySpriteType;
    public string[] chipInventoryText;

    public Vector3[] chipVectors;
    public Item.ItemType[] chipSpriteType;
    public string[] chipText;

    public Item.ItemType[] crateSpriteType;
    public int[] crateNumber;

    private int chipsCollected = 0;
    public int chipsToBeCollected;

    public GameObject chipsDone;

    public AudioSource collectedChip;

    public GameObject clearScreen;
    //[SerializeField] ContentSizeFitter csf;


    // Start is called before the first frame update
    void Start()
    {
        //scenePass = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<SwitchScenes>();
        anim = GetComponent<Animator>();

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
            ItemWorld.SpawnItemWorld(chipVectors[i], new Item { itemType = chipSpriteType[i], text = chipText[i] });
            //LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)csf.transform);
        }
        
        for (int i = 0; i < crateSpriteType.Length; i++)
        {
            crate.AddItem(new Item { itemType = crateSpriteType[i], number = crateNumber[i] });
        }

        for (int i = 0; i < chipInventorySpriteType.Length; i++)
        {
            inventory.AddItem(new Item { itemType = chipInventorySpriteType[i], text = chipInventoryText[i] });
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
            collectedChip.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        anim.SetFloat("Speed", moveX);

        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);

        float clampX = Mathf.Clamp(this.transform.position.x, minBound.x, maxBound.x);
        float clampY = Mathf.Clamp(this.transform.position.y, minBound.y, maxBound.y);

        this.transform.position = new Vector3(clampX, clampY, this.transform.position.z);

        if(chipsCollected == chipsToBeCollected)
        {
            //Debug.Log("Collected Every Chips!");
            chipsDone.SetActive(true);
            if (uiCrate.DoneCrate())
            {
                clearScreen.SetActive(true);
            }
        }
    }

    public Vector3 GetPosition()
    {
        //Debug.Log(transform.position);
        return transform.position;
    }
}
