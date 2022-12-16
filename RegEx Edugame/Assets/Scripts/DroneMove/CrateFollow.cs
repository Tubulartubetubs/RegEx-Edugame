using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0.45f, 0);
        target = GameObject.Find("/Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
