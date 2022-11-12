using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Central : MonoBehaviour
{
    public Transform invisibleChip;

    List<Arranger> arrangers;

    Arranger workingArranger;
    int oriIndex;

    // Start is called before the first frame update
    void Start()
    {
        arrangers = new List<Arranger>();

        var arrs = transform.GetComponentsInChildren<Arranger>();

        for(int i = 0; i < arrs.Length; i++)
        {
            arrangers.Add(arrs[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SwapChips(Transform sour, Transform dest)
    {
        Transform sourParent = sour.parent;
        Transform destParent = dest.parent;

        int sourIndex = sour.GetSiblingIndex();
        int destIndex = dest.GetSiblingIndex();

        sour.SetParent(destParent);
        sour.SetSiblingIndex(destIndex);

        dest.SetParent(sourParent);
        dest.SetSiblingIndex(sourIndex);
    }

    void SwapChipsInHierarchy(Transform sour, Transform dest)
    {
        SwapChips(sour, dest);

        arrangers.ForEach(t => t.UpdateChildren());
    }

    bool ContainPos(RectTransform rt, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt, pos); //if rt has pos in it
    }

    void BeginDrag(Transform chip)
    {
        //Debug.Log("BeginDrag: " + chip.name);
        workingArranger = arrangers.Find(t => ContainPos(t.transform as RectTransform, chip.position));
        oriIndex = chip.GetSiblingIndex();

        SwapChipsInHierarchy(invisibleChip, chip);
    }

    void Drag(Transform chip)
    {
        //Debug.Log("Drag: " + chip.name);

        var whichArrangerChip = arrangers.Find(t => ContainPos(t.transform as RectTransform, chip.position));

        if(whichArrangerChip == null)
        {
            bool updateChildren = transform != invisibleChip.parent;

            invisibleChip.SetParent(transform);

            if (updateChildren)
            {
                arrangers.ForEach(t => t.UpdateChildren());
            }
        }
        else
        {
            bool insert = invisibleChip.parent == transform;

            if (insert)
            {
                int index = whichArrangerChip.GetIndexByPosition(chip);

                invisibleChip.SetParent(whichArrangerChip.transform);
                whichArrangerChip.InsertChip(invisibleChip, index);
            }
            else
            {
                int invisibleChipIndex = invisibleChip.GetSiblingIndex();
                int targetIndex = whichArrangerChip.GetIndexByPosition(chip, invisibleChipIndex);

                if (invisibleChipIndex != targetIndex)
                {
                    whichArrangerChip.SwapCard(invisibleChipIndex, targetIndex);
                }
                //Debug.Log(whichArrangerChip.GetIndexByPosition(chip, invisibleChip.GetSiblingIndex()));
            }
        } 
    }

    void EndDrag(Transform chip)
    {
        //Debug.Log("EndDrag: " + chip.name);

        if(invisibleChip.parent == transform)
        {
            workingArranger.InsertChip(chip, oriIndex);
            chip.SetParent(workingArranger.transform);
            workingArranger = null;
            oriIndex = -1;
        }
        else
        {
            SwapChipsInHierarchy(invisibleChip, chip);
        }
    }
}
