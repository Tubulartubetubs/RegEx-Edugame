using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UICrate : MonoBehaviour
{
    public Crate crate;
    public BoxCollider2D[] bound;
    public BoxCollider2D[] extrabound;
    public GameObject building1detail;
    public GameObject building2detail;
    public GameObject building3detail;
    public GameObject building4detail;

    public GameObject extra01detail;
    public GameObject extra02detail;
    public GameObject extra03detail;
    public GameObject extra04detail;
    public GameObject extra05detail;
    public GameObject extra06detail;
    public GameObject extra07detail;
    public GameObject extra08detail;
    public GameObject extra09detail;
    public GameObject extra10detail;
    public GameObject extra11detail;
    public GameObject extra12detail;
    public GameObject extra13detail;
    public GameObject extra14detail;
    public GameObject extra15detail;
    public GameObject extra16detail;

    private Transform viewPort;
    private Transform content;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    public MovingObject player;

    public GameObject crate1detail;
    public GameObject crate2detail;
    public GameObject crate3detail;
    public GameObject crate4detail;

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
        player = GameObject.Find("/Player").GetComponent<MovingObject>();
        viewPort = transform.Find("Viewport");
        content = viewPort.Find("Content");
        itemSlotContainer = content.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");

        extra01detail = GameObject.Find("/Extra Bound/Extra01 Bound/Building1");
        extra02detail = GameObject.Find("/Extra Bound/Extra02 Bound/Building1");
        extra03detail = GameObject.Find("/Extra Bound/Extra03 Bound/Building1");
        extra04detail = GameObject.Find("/Extra Bound/Extra04 Bound/Building1");
        extra05detail = GameObject.Find("/Extra Bound/Extra05 Bound/Building1");
        extra06detail = GameObject.Find("/Extra Bound/Extra06 Bound/Building1");
        extra07detail = GameObject.Find("/Extra Bound/Extra07 Bound/Building1");
        extra08detail = GameObject.Find("/Extra Bound/Extra08 Bound/Building1");
        extra09detail = GameObject.Find("/Extra Bound/Extra09 Bound/Building1");
        extra10detail = GameObject.Find("/Extra Bound/Extra10 Bound/Building1");
        extra11detail = GameObject.Find("/Extra Bound/Extra11 Bound/Building1");
        extra12detail = GameObject.Find("/Extra Bound/Extra12 Bound/Building1");
        extra13detail = GameObject.Find("/Extra Bound/Extra13 Bound/Building1");
        extra14detail = GameObject.Find("/Extra Bound/Extra14 Bound/Building1");
        extra15detail = GameObject.Find("/Extra Bound/Extra15 Bound/Building1");
        extra16detail = GameObject.Find("/Extra Bound/Extra16 Bound/Building1");

        extrabound = new BoxCollider2D[16];
        extrabound[0] = GameObject.Find("/Extra Bound/Extra01 Bound").GetComponent<BoxCollider2D>();
        extrabound[1] = GameObject.Find("/Extra Bound/Extra02 Bound").GetComponent<BoxCollider2D>();
        extrabound[2] = GameObject.Find("/Extra Bound/Extra03 Bound").GetComponent<BoxCollider2D>();
        extrabound[3] = GameObject.Find("/Extra Bound/Extra04 Bound").GetComponent<BoxCollider2D>();
        extrabound[4] = GameObject.Find("/Extra Bound/Extra05 Bound").GetComponent<BoxCollider2D>();
        extrabound[5] = GameObject.Find("/Extra Bound/Extra06 Bound").GetComponent<BoxCollider2D>();
        extrabound[6] = GameObject.Find("/Extra Bound/Extra07 Bound").GetComponent<BoxCollider2D>();
        extrabound[7] = GameObject.Find("/Extra Bound/Extra08 Bound").GetComponent<BoxCollider2D>();
        extrabound[8] = GameObject.Find("/Extra Bound/Extra09 Bound").GetComponent<BoxCollider2D>();
        extrabound[9] = GameObject.Find("/Extra Bound/Extra10 Bound").GetComponent<BoxCollider2D>();
        extrabound[10] = GameObject.Find("/Extra Bound/Extra11 Bound").GetComponent<BoxCollider2D>();
        extrabound[11] = GameObject.Find("/Extra Bound/Extra12 Bound").GetComponent<BoxCollider2D>();
        extrabound[12] = GameObject.Find("/Extra Bound/Extra13 Bound").GetComponent<BoxCollider2D>();
        extrabound[13] = GameObject.Find("/Extra Bound/Extra14 Bound").GetComponent<BoxCollider2D>();
        extrabound[14] = GameObject.Find("/Extra Bound/Extra15 Bound").GetComponent<BoxCollider2D>();
        extrabound[15] = GameObject.Find("/Extra Bound/Extra16 Bound").GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (bound[0] != null && bound[0].bounds.Contains(player.transform.position))
        {
            building1detail.SetActive(true);
        }
        else
            building1detail.SetActive(false);

        if (bound[1] != null && bound[1].bounds.Contains(player.transform.position))
        {
            building2detail.SetActive(true);
        }
        else
            building2detail.SetActive(false);

        if (bound[2] != null && bound[2].bounds.Contains(player.transform.position))
        {
            building3detail.SetActive(true);
        }
        else
            building3detail.SetActive(false);

        if (bound[3] != null && bound[3].bounds.Contains(player.transform.position))
        {
            building4detail.SetActive(true);
        }
        else
            building4detail.SetActive(false);

        if (extrabound[0].bounds.Contains(player.transform.position))
        {
            extra01detail.SetActive(true);
        }
        else
            extra01detail.SetActive(false);

        if (extrabound[1].bounds.Contains(player.transform.position))
        {
            extra02detail.SetActive(true);
        }
        else
            extra02detail.SetActive(false);

        if (extrabound[2].bounds.Contains(player.transform.position))
        {
            extra03detail.SetActive(true);
        }
        else
            extra03detail.SetActive(false);

        if (extrabound[3].bounds.Contains(player.transform.position))
        {
            extra04detail.SetActive(true);
        }
        else
            extra04detail.SetActive(false);

        if (extrabound[4].bounds.Contains(player.transform.position))
        {
            extra05detail.SetActive(true);
        }
        else
            extra05detail.SetActive(false);

        if (extrabound[5].bounds.Contains(player.transform.position))
        {
            extra06detail.SetActive(true);
        }
        else
            extra06detail.SetActive(false);

        if (extrabound[6].bounds.Contains(player.transform.position))
        {
            extra07detail.SetActive(true);
        }
        else
            extra07detail.SetActive(false);

        if (extrabound[7].bounds.Contains(player.transform.position))
        {
            extra08detail.SetActive(true);
        }
        else
            extra08detail.SetActive(false);

        if (extrabound[8].bounds.Contains(player.transform.position))
        {
            extra09detail.SetActive(true);
        }
        else
            extra09detail.SetActive(false);

        if (extrabound[9].bounds.Contains(player.transform.position))
        {
            extra10detail.SetActive(true);
        }
        else
            extra10detail.SetActive(false);

        if (extrabound[10].bounds.Contains(player.transform.position))
        {
            extra11detail.SetActive(true);
        }
        else
            extra11detail.SetActive(false);

        if (extrabound[11].bounds.Contains(player.transform.position))
        {
            extra12detail.SetActive(true);
        }
        else
            extra12detail.SetActive(false);

        if (extrabound[12].bounds.Contains(player.transform.position))
        {
            extra13detail.SetActive(true);
        }
        else
            extra13detail.SetActive(false);

        if (extrabound[13].bounds.Contains(player.transform.position))
        {
            extra14detail.SetActive(true);
        }
        else
            extra14detail.SetActive(false);

        if (extrabound[14].bounds.Contains(player.transform.position))
        {
            extra15detail.SetActive(true);
        }
        else
            extra15detail.SetActive(false);

        if (extrabound[15].bounds.Contains(player.transform.position))
        {
            extra16detail.SetActive(true);
        }
        else
            extra16detail.SetActive(false);
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
                if (bound[0].bounds.Contains(player.transform.position) && item.number == 0)
                {
                    done1.SetActive(true);
                    dropped++;
                    Debug.Log("dropped: "+dropped);
                }
                else if (bound[1].bounds.Contains(player.transform.position) && item.number == 1)
                {
                    done2.SetActive(true);
                    dropped++;
                    Debug.Log("dropped: " + dropped);
                }
                else if (bound[2].bounds.Contains(player.transform.position) && item.number == 2)
                {
                    done3.SetActive(true);
                    dropped++;
                    Debug.Log("dropped: " + dropped);
                }
                else if (bound[3].bounds.Contains(player.transform.position) && item.number == 3)
                {
                    done4.SetActive(true);
                    dropped++;
                    Debug.Log("dropped: " + dropped);
                }
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
