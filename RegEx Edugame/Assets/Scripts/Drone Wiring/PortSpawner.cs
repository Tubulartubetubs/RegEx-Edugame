using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortSpawner : MonoBehaviour
{
    public List<GameObject> ports;
    public GameObject portArea;
    public DisplayText displayText;
    GameObject spawnedPort;

    // Start is called before the first frame update
    void Start()
    {
        portArea = GameObject.FindGameObjectWithTag("Port Area");
        displayText = GameObject.Find("DisplayText").GetComponent<DisplayText>();

        for(int i= 0; i < 5; i++)
        {
            spawnedPort = Instantiate(ports[i], portArea.transform);
            displayText.ports.Add(spawnedPort);
        }
    }

}
