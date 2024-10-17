using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepStair : MonoBehaviour
{
    [SerializeField] ColorOS colorData;
    [SerializeField] MeshRenderer m_Renderer;
    public ColorType colorType { get; private set; }
   
    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là Player hay không
        Player player = other.GetComponent<Player>();
        if (player!=null)
        {
            if (player.playerBrick.Count > 0 && player.colorType!=colorType)
            {
                
                //Gán colorType của playe = color mới
                colorType = player.colorType;
                m_Renderer.material = colorData.GetMaterial(colorType);       
                player.RemoveBrickGround();
                
            }      
        }

    }
}
