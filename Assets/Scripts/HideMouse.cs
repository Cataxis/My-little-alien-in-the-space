using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouse : MonoBehaviour
{
    public bool mouse;
    void Start()
    {
        if(mouse)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        
    }

}
