using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width - 110, 10, 100, 90), "Players");
        if (GUI.Button(new Rect(Screen.width - 100, 40, 80, 20), "Player1"))
        {
            MainController.current.OnButtonClick("daichi");
        }
        if (GUI.Button(new Rect(Screen.width - 100, 70, 80, 20), "Player2"))
        {
            MainController.current.OnButtonClick("takahiro");
        }
    }
}
