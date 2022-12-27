using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSpawner : MonoBehaviour
{
    public List<GameObject> chips;
    public GameObject chipWaiting;
    public string[] chipText;
    public Item.ItemType[] chipSpriteType;
    public Vector3 offset;

    public RegEx displayText;

    // Start is called before the first frame update
    void Start()
    {
        //chipWaiting = GameObject.FindGameObjectWithTag("ChipSlot");
        //for (int i = 0; i < chipSpriteType.Length; i++)
        //{
        //    ItemWorld.SpawnChip(new Item { itemType = chipSpriteType[i], text = chipText[i] });

        //    //LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)csf.transform);
        //}

        displayText = GameObject.Find("DisplayText").GetComponent<RegEx>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnChip(int chipNum)
    {
        //GameObject lastChild = chipWaiting.transform.GetChild(chipWaiting.transform.childCount - 1).gameObject;

        //Instantiate(chips[chipNum], chipWaiting.transform);
        //displayText.UpdateChips();

        //Debug.Log(lastChild.name);
        if (chipWaiting.transform.childCount < 6)
            Instantiate(chips[chipNum], chipWaiting.transform);
        else
            Debug.Log("Too many Chips");
    }
}
