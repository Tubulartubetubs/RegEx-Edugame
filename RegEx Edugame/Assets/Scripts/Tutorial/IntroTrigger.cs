using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTrigger : MonoBehaviour
{
    public Introduction introduction;

    public GameObject introHandler;

    // Start is called before the first frame update
    void Start()
    {
        introHandler = GameObject.Find("Intro Handler");
        StartCoroutine(Trigger());
    }

    private IEnumerator Trigger()
    {
        yield return new WaitForSeconds(.1f);
        TriggerIntro();
    }

    public void TriggerIntro()
    {
        introHandler.GetComponent<IntroHandler>().StartIntro(introduction);
    }
}
