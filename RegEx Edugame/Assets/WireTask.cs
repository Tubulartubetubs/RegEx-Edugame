using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTask : MonoBehaviour
{

    public List<Color> _wireColors = new List<Color>();
    public List<string> wireTexts = new List<string>();
    public List<Wire> _leftWires = new List<Wire>();

    public List<Wire> _rightWires = new List<Wire>();

    public Wire CurrentDraggedWire;

    public Wire CurrentHoveredWire;

    private List<Color> _availableColors;
    private List<string> availableTexts;
    private List<int> _availableLeftWireIndex;

    private List<int> _availableRightWireIndex;

    public bool IsTaskCompleted = false;

    // Start is called before the first frame update
    private void Start()
    {

        _availableColors = new List<Color>(_wireColors);
        availableTexts = new List<string>(wireTexts);
        _availableLeftWireIndex = new List<int>();
        _availableRightWireIndex = new List<int>();

        for (int i = 0; i < _leftWires.Count; i++)
        {
            _availableLeftWireIndex.Add(i);
        }
        for (int i = 0; i < _rightWires.Count; i++)
        {
            _availableRightWireIndex.Add(i);
        }

        while(_availableColors.Count > 0 && availableTexts.Count > 0 && _availableLeftWireIndex.Count > 0 && _availableRightWireIndex.Count > 0)
        {
            Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];
            string pickedText = availableTexts[Random.Range(0, availableTexts.Count)];
            int pickedLeftWireIndex = Random.Range(0, _availableLeftWireIndex.Count);
            int pickedRightWireIndex = Random.Range(0, _availableRightWireIndex.Count);

            _leftWires[_availableLeftWireIndex[pickedLeftWireIndex]].SetColor(pickedColor);
            _leftWires[_availableLeftWireIndex[pickedLeftWireIndex]].GetComponent<WireText>().wireText.SetText(pickedText);
            _rightWires[_availableRightWireIndex[pickedRightWireIndex]].SetColor(pickedColor);
            _rightWires[_availableRightWireIndex[pickedRightWireIndex]].GetComponent<WireText>().wireText.SetText(pickedText);

            _availableColors.Remove(pickedColor);
            availableTexts.Remove(pickedText);
            _availableLeftWireIndex.RemoveAt(pickedLeftWireIndex);
            _availableRightWireIndex.RemoveAt(pickedRightWireIndex);
        }

        StartCoroutine(CheckTaskCompletion());

    }

    private IEnumerator CheckTaskCompletion()
    {
        while (!IsTaskCompleted) //no need maybe?
        {
            int successfulwires = 0;
            for (int i = 0; i < _rightWires.Count; i++)
            {
                if (_rightWires[i].isSuccess)
                {
                    successfulwires++;
                }
            }
            if (successfulwires >= _rightWires.Count)
            {
                //Debug.Log("Task Conpleted");
            }
            else
            {
                //Debug.Log("Task incompleted");
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
