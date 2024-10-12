using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBrick : MonoBehaviour
{
    [SerializeField] public ColorType colorType;

    [SerializeField] public MeshRenderer meshRenderer;

    public void OnInit() // khoi tao
    {
        ///random mau
        colorType = (ColorType)Random.Range(0, 4);
        //doi mau material
        meshRenderer.material = DataManager.instance.colorData.GetMaterial(colorType);
    }
    
}
