using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugChecker : MonoBehaviour
{
    public bool isConnected = false;

    public string text;
    //Collider2D[] colliders;

    private void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, .1f);
    }

    private void Start()
    {
        //colliders = Physics2D.OverlapCircleAll(transform.position, .2f);
    }

    private void Update()
    {
        CheckCollisions();
    }

    void CheckCollisions()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, .1f);

        //Debug.Log(colliders.Length);

        if (colliders.Length == 3)
        {
            isConnected = false;
            text = "";
        }
    }

    public void SetIsConnected(bool isConnected)
    {
        this.isConnected = isConnected;
    }

    public bool GetIsConnected()
    {
        return isConnected;
    }
}
