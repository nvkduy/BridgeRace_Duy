using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepStair : MonoBehaviour
{
    [SerializeField] ColorOS colorData;
    [SerializeField] MeshRenderer m_Renderer;
    public ColorType ColorTypeStep { get; private set; }
   
    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là Player hay không
        Character character = Cache.GetCharacter(other);
        if (character!=null)
        {
            if (character.playerBrick.Count > 0 && character.ColorType !=ColorTypeStep)
            {
                
                //Gán colorType của player = color mới
                ColorTypeStep = character.ColorType;
                m_Renderer.material = colorData.GetMaterial(ColorTypeStep);       
                character.RemoveBrickGround();

            }      
        }

    }
}
