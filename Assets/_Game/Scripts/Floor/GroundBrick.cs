﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBrick : MonoBehaviour
{
    [SerializeField] ColorOS colorData;
    [SerializeField] MeshRenderer m_Renderer;

    public ColorType colorType { get; private set; }

    public void OnInit()
    {
        ChangeColorBrick();
    }

    public void ChangeColorBrick()
    {
        colorType = (ColorType)Random.Range(0, 4);
        m_Renderer.material = colorData.GetMaterial(colorType);
    }
}