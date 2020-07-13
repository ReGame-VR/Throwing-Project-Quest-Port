using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanel : MonoBehaviour
{
    public List<string> levels = new List<string>();
    public List<GameObject> buttons = new List<GameObject>();
    public Dictionary<GameObject, string> buttonMap = new Dictionary<GameObject, string>();

    // Start is called before the first frame update
    void Start()
    {
        //levels = RandomizeList(levels);
        //ChangeNameOfObjects(levels);
        //AssignLevelsToButtons(buttons, levels);
    }

    
    //Randomizes levels for buttons. NOT USED
    public List<string> RandomizeList(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }

        return list;
    }

    //Assigning levels to buttons. NOT USED
    public void AssignLevelsToButtons(List<GameObject> buttons, List<string> randomizedList)
    {
        for(int i = 0; i < buttonMap.Count; i++)
        {
            buttonMap.Add(buttons[i], randomizedList[i]);
        }
    }

    //Change level names. NOT USED
    public void ChangeNameOfObjects(List<string> list)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].name = list[i];
            buttons[i].GetComponent<ButtonPressDetector>().setLevel = buttons[i].name;
        }
    }
}
