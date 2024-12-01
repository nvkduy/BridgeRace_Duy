using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GroundBrick : MonoBehaviour
{
    [SerializeField] ColorOS colorData;
    [SerializeField] MeshRenderer m_Renderer;

    internal Floor floor;
    public ColorType ColorTypeBrick { get; private set; }

    public void ChangeColorBrick(ColorType colorType)
    {
        ColorTypeBrick = colorType;
        m_Renderer.material = colorData.GetMaterial(colorType);
    }

    public void OnDespawn()
    {
       floor.NewSpawnBrick(Random.Range(1.5f, 2.5f), transform.position,ColorTypeBrick);
    }
}