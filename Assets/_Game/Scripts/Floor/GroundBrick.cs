using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GroundBrick : MonoBehaviour
{
    [SerializeField] ColorOS colorData;
    [SerializeField] MeshRenderer m_Renderer;
    private Character character;

    internal Floor floor;
    public ColorType colorType { get; private set; }


    public void ChangeColorBrick()
    {
        Debug.Log("colorTypes count: " + ColorManager.Instance.colorTypes.Count);
        if (ColorManager.Instance.colorTypes.Count == 0)
        {
            Debug.LogError("colorTypes is empty. Cannot change color.");
            return;  // Nếu danh sách rỗng, thoát khỏi phương thức
        }
        // colorType = (ColorType)Random.Range(0, 4);
        int randomIndex = Random.Range(0, ColorManager.Instance.colorTypes.Count);
       ColorType colorType = ColorManager.Instance.colorTypes[randomIndex];

        m_Renderer.material = colorData.GetMaterial(colorType);
    }

    public void OnDespawn()
    {
        
        floor.NewSpawnBrick(Random.Range(1.5f, 2.5f), transform.position);
    }
}