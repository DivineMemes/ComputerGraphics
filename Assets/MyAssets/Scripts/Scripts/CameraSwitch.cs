using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;
    public int cameraNumber;
    public KeyCode[] keyCodes;
    // Use this for initialization
    void Start()
    {
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
        }
        cameras[0].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        int selectedIndex = -1;
        // see which one was pressed
        for (int i = 0; i < keyCodes.Length; ++i)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                selectedIndex = i;
            }
        }
        if (selectedIndex == -1)
        {
            return;
        }
        // turn off everything except the one I pressed
        for (int i = 0; i < keyCodes.Length; ++i)
        {
            if (i != selectedIndex)
            {
                cameras[i].enabled = false;
            }
        }
        cameras[selectedIndex].enabled = true;
        return;
    }
}