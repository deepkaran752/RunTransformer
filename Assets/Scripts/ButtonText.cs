using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonText : MonoBehaviour
{
    public string buttonText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string ButtonPress(Button button)
    {
        TMP_Text text = button.GetComponentInChildren<TMP_Text>();
        if (buttonText != null)
        {
            buttonText = text.text;
        }

        return buttonText;
    }
}
