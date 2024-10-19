using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GroundBrick : MonoBehaviour
{
    [SerializeField] ColorOS colorData;
    [SerializeField] MeshRenderer m_Renderer;
    [SerializeField] Character character;

    public Floor floor;
    public ColorType colorType { get; private set; }

    public void OnInit()
    {
        if (character == null)
        {
            character = FindObjectOfType<Character>(); ;
        }
        ChangeColorBrick();
    }

    public void ChangeColorBrick()
    {
        Debug.Log("colorTypes count: " + character.colorTypes.Count);
        if (character.colorTypes.Count == 0)
        {
            Debug.LogError("colorTypes is empty. Cannot change color.");
            return;  // Nếu danh sách rỗng, thoát khỏi phương thức
        }
        // colorType = (ColorType)Random.Range(0, 4);
        int randomIndex = Random.Range(0, character.colorTypes.Count);
        colorType = character.colorTypes[randomIndex];

        m_Renderer.material = colorData.GetMaterial(colorType);
    }

    public void OnDespawn()
    {
        
        floor.NewSpawnBrick(Random.Range(1.5f, 2.5f), transform.position);
    }
}