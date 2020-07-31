using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanel : MonoBehaviour
{
    public List<ButtonPressDetector> buttons = new List<ButtonPressDetector>();
    public Gameplay gameplay;
    
    public void ButtonSwitch()
    {
        switch (gameplay.totalLevelCount)
        {
                case 0:
                    ButtonActivation(0);
                    break;
                case 1:
                    ButtonActivation(1);
                    break;
                case 2: 
                    ButtonActivation(2);
                    break;
                case 3:
                    ButtonActivation(3);
                    break;
                case 4:
                    ButtonActivation(4);
                    break;
        }   
    }

    private void ButtonActivation(int numOfButton)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i != numOfButton)
            {
                buttons[i].FreezeButtonPosition();
            }
            else
            {
                buttons[i].UnfreezeButtonPosition();
            }
        }
    }
}
