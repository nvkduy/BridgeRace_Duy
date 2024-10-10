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
    Pink = 4,
    Orange = 5,
}

[CreateAssetMenu(fileName = "ColorData", menuName = "ScriptableObject/ColorData", order = 1)]
public class ColorData : ScriptableObject
{
    public List<Material> colorMaterials;
}
