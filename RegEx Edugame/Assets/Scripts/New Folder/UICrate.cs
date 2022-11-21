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
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private MovingObject player;


    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
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
        int y = 0;
        float itemSlotCellSize = 185f;

        foreach (Item item in crate.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            {
                Debug.Log(item.number);
                Debug.Log(bound[0]);
                if (bound[0].bounds.Contains(player.transform.position) && item.number == 0)
                {
                    crate.RemoveItem(item);
                    CrateWorld.DropItem(player.GetPosition(), item);
                }
                else if (bound[1].bounds.Contains(player.transform.position) && item.number == 1)
                {
                    crate.RemoveItem(item);
                    CrateWorld.DropItem(player.GetPosition(), item);
                }
                else if(bound[2].bounds.Contains(player.transform.position) && item.number == 2)
                {
                    crate.RemoveItem(item);
                    CrateWorld.DropItem(player.GetPosition(), item);
                }
                else
                {
                    //do nothing
                }
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            //Text text = itemSlotRectTransform.Find("text").GetComponent<Text>();
            image.sprite = item.GetSprite();
            //TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            //uiText.SetText(item.text);
            y--;
            if (y < -3)
            {
                y = 0;
                x++;
            }
        }
    }
}