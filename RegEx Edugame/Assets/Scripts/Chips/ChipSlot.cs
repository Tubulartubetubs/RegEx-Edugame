using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSlot : MonoBehaviour
{
    public GameObject player;
    public bool closest = false;

    private void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < .5f)
        {
            closest = true;
        }
        else
            closest = false;
    }
}
