using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSpawner : MonoBehaviour
{
    public List<GameObject> chips;
    public GameObject chipWaiting;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //chipWaiting = GameObject.FindGameObjectWithTag("ChipSlot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnChip(int chipNum)
    {
        GameObject lastChild = chipWaiting.transform.GetChild(chipWaiting.transform.childCount - 1).gameObject;

        Debug.Log(lastChild.name);
        if (chipWaiting.transform.childCount < 7)
            Instantiate(chips[chipNum], chipWaiting.transform);
        else
            Debug.Log("Too many Chips");
    }
}
