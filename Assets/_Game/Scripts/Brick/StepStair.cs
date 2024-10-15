using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepStair : MonoBehaviour
{
    [SerializeField] ColorOS colorData;
    [SerializeField] MeshRenderer m_Renderer;

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là Player hay không
        Player player = other.GetComponentInChildren<Player>();
        if (player!=null)
        {

            Debug.Log("vacham");
            //Gán colorType của playe = color mới
            ColorType newColor = player.colorType;
            Material newMaterial = colorData.GetMaterial(newColor);
            m_Renderer.material = newMaterial;
        }


    }
}
