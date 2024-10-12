using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private List<GameObject> bricks;
    private int index = 0;
    [SerializeField]  ColorData color;

    private void SpawnBrick()
    {
        
    }
    private void RemoveBrick()
    {

    }
    private void ChangeColorBrick(int Index)
    {
       
            if (color != null && color.colorMaterials.Count>Index)
            {
                SkinnedMeshRenderer meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
                if (meshRenderer != null)
                {
                    Material selectedMaterial = color.colorMaterials[Index];
                    meshRenderer.material = selectedMaterial;
                }
            }

    }
}
