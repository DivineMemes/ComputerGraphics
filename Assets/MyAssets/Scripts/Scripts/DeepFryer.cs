﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
/*[WonderTwinPowersActivate(FormOF(PostProcesses))]*/
public class DeepFryer : MonoBehaviour
{
    public Material curMaterial;
    public Shader curShader;
    Material material
    {
        get
        {
            if (curMaterial == null)
            {
                curMaterial = new Material(curShader);
                curMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            return curMaterial;
        }
    }

    void Start()
    {
        //curShader = Resources.
        //curShader = Shader.Find("Hidden/PostEffects");
        GetComponent<Camera>().allowHDR = true;
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            Debug.Log("not supported");
            return;
        }
        if (!curShader && !curShader.isSupported)
        {
            enabled = false;
            Debug.Log("not supported");
        }
        GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
    }


    void Update()
    {
        if (!GetComponent<Camera>().enabled)
        {
            return;
        }
    }
    void OnDisable()
    {
        if (curMaterial)
        {
            //DestroyImmediate(curMaterial, true);
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (curShader != null)
        {
            Graphics.Blit(source, destination, curMaterial, 0);
        }
    }
}