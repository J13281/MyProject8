using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ButtonController : MonoBehaviour
{
    public void OnClick1()
    {
        MainController.current.OnButtonClick("");
    }
}