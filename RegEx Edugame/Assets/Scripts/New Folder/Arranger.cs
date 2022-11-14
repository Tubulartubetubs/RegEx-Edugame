using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arranger : MonoBehaviour
{
    List<Transform> children;

    RegEx regex;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<Transform>();
        regex = GameObject.Find("DisplayText").GetComponent<RegEx>();

        UpdateChildren();
    }

    public void UpdateChildren()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(i == children.Count)
            {
                children.Add(null);
            }

            var child = transform.GetChild(i);

            if(child != children[i])
            {
                children[i] = child;
            }
        }

        children.RemoveRange(transform.childCount, children.Count - transform.childCount);
        regex.UpdateDisplay();
    }

    public void InsertChip(Transform chip, int index)
    {
        children.Add(chip);
        chip.SetSiblingIndex(index);
        UpdateChildren();
    }

    public int GetIndexByPosition(Transform chip, int skipIndex = -1)
    {
        int result = 0;
        
        for(int i = 0; i < children.Count; i++)
        {
            if(chip.position.x < children[i].position.x)
            {
                break;
            }
            else if(skipIndex != i)
            {
                result++;
            }
        }
        return result;
    }

    public void SwapCard(int index1, int index2)
    {
        Central.SwapChips(children[index1], children[index2]);
        UpdateChildren();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
