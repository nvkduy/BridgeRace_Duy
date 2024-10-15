using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ColorType
{
    Red=0,
    Green=1,
    Blue=2,
    Yellow=3,
    Orange = 5,
    None = 100  
}

[CreateAssetMenu(fileName = "ColorData", menuName = "ScriptableObject/ColorOS", order = 1)]
public class ColorOS : ScriptableObject
{
    [SerializeField] public List<Material> colorMaterials;

    public Material GetMaterial(ColorType colorType)
    {
        return colorMaterials[(int)colorType];
    }
    //public Material GetMaterial(int colorType)
    //{
    //    return colorMaterials[colorType];
    //}
}