using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelationSlider : MonoBehaviour
{
    public Material postProcess;
    public Slider slider;
    public float pixl;
	public void Pixel ()
    {
        pixl = slider.value;
        postProcess.SetFloat("_Pixelate", pixl);
	}
}
