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

        foreach(GameObject port in ports)
        {
            spawnedPort = Instantiate(port, portArea.transform);
            displayText.ports.Add(spawnedPort);
        }
    }

}
