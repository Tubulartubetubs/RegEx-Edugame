using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UICrate : MonoBehaviour
{
    private Crate crate;
    public BoxCollider2D[] bound;
    public GameObject building1detail;
    public GameObject building2detail;
    public GameObject building3detail;
    public GameObject building4detail;

    public GameObject extra1detail;

    private Transform viewPort;
    private Transform content;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private MovingObject player;

    public GameObject crate1detail;
    public GameObject crate2detail;
    public GameObject crate3detail;
    public GameObject crate4detail;

    private bool doneBool1 = false;
    private bool doneBool2 = false;
    private bool doneBool3 = false;
    private bool doneBool4 = false;

    public GameObject done1;
    public GameObject done2;
    public GameObject done3;
    public GameObject done4;

    public int dropped = 0;
    public int toBeDropped;

    public AudioSource droppedCrate;

    private void Awake()
    {
        Debug.Log(toBeDropped);
        viewPort = transform.Find("Viewport");
        content = viewPort.Find("Content");
        itemSlotContainer = content.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");

        building1detail = GameObject.Find("/Crate Bound/Crate1 Bound/Building1");
        building2detail = GameObject.Find("/Crate Bound/Crate1 Bound/Building2");
        building3detail = GameObject.Find("/Crate Bound/Crate1 Bound/Building3");
        building4detail = GameObject.Find("/Crate Bound/Crate1 Bound/Building4");

        
    }

    private void Update()
    {
        if (doneBool1 == false && bound[0] != null && bound[0].bounds.Contains(player.transform.position))
        {
            building1detail.SetActive(true);
        }
        else
            building1detail.SetActive(false);

        if (doneBool2 == false && bound[1] != null && bound[1].bounds.Contains(player.transform.position))
        {
            building2detail.SetActive(true);
        }
        else
            building2detail.SetActive(false);

        if (doneBool3 == false && bound[2] != null && bound[2].bounds.Contains(player.transform.position))
        {
            building3detail.SetActive(true);
        }
        else
            building3detail.SetActive(false);

        if (doneBool4 == false && bound[3] != null && bound[3].bounds.Contains(player.transform.position))
        {
            building4detail.SetActive(true);
        }
        else
            building4detail.SetActive(false);
    }

    public void SetPlayer(MovingObject player)
    {
        this.player = player;
    }
    public void SetCrate(Crate crate)
    {
        this.crate = crate;

        crate.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    public bool DoneCrate()
    {
        if (dropped == toBeDropped)
        {
            return true;
        }
        else
            return false;
    }


    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate)
            {
                
                continue;
            }
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 1;
        float itemSlotCellSize = 185f;

        foreach (Item item in crate.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.GetComponent<Button_UI>().MouseOverFunc = () =>
            {
                if (item.number == 0)
                {
                    crate1detail.SetActive(true);
                }
                if (item.number == 1)
                {
                    crate2detail.SetActive(true);
                }
                if(item.number == 2)
                {
                    crate3detail.SetActive(true);
                }
                if(item.number == 3)
                {
                    crate4detail.SetActive(true);
                }
            };

            itemSlotRectTransform.GetComponent<Button_UI>().MouseOutOnceFunc = () =>
            {
                crate1detail.SetActive(false);
                crate2detail.SetActive(false);
                crate3detail.SetActive(false);
                crate4detail.SetActive(false);
            };

            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            {
                crate.RemoveItem(item);
                CrateWorld.DropItem(player.GetPosition(), item);
                crate1detail.SetActive(false);
                crate2detail.SetActive(false);
                crate3detail.SetActive(false);
                crate4detail.SetActive(false);
                droppedCrate.Play();

                //Debug.Log(item.number);
                //Debug.Log(bound[0]);
                //if (bound[0].bounds.Contains(player.transform.position) && item.number == 0)
                //{
                //    crate.RemoveItem(item);
                //    CrateWorld.DropItem(player.GetPosition(), item);
                //    crate1detail.SetActive(false);
                //    done1.SetActive(true);
                //    droppedCrate.Play();
                //    dropped++;
                //    doneBool1 = true;
                //}
                //else if (bound[1].bounds.Contains(player.transform.position) && item.number == 1)
                //{
                //    crate.RemoveItem(item);
                //    CrateWorld.DropItem(player.GetPosition(), item);
                //    crate2detail.SetActive(false);
                //    done2.SetActive(true);
                //    droppedCrate.Play();
                //    dropped++;
                //    doneBool2 = true;
                //}
                //else if(bound[2].bounds.Contains(player.transform.position) && item.number == 2)
                //{
                //    crate.RemoveItem(item);
                //    CrateWorld.DropItem(player.GetPosition(), item);
                //    crate3detail.SetActive(false);
                //    done3.SetActive(true);
                //    droppedCrate.Play();
                //    dropped++;
                //    doneBool3 = true;
                //}
                //else if (bound[3].bounds.Contains(player.transform.position) && item.number == 3)
                //{
                //    crate.RemoveItem(item);
                //    CrateWorld.DropItem(player.GetPosition(), item);
                //    crate4detail.SetActive(false);
                //    done4.SetActive(true);
                //    droppedCrate.Play();
                //    dropped++;
                //    doneBool4 = true;
                //}
                //else
                //{
                //    //do nothing
                //}
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            y--;
            if (y < -2)
            {
                y = 1;
                x++;
            }
        }
    }
}
