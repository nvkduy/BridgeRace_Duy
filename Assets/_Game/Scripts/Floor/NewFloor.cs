using System.Collections.Generic;
using UnityEngine;

public class NewFloor : MonoBehaviour
{
    [SerializeField] internal Floor floor;
    public List<ColorType> colorTypes = new List<ColorType>();


    // Remove old bricks of old Floor and spawn new bricks of new Floor
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Character"))
        {

            Character character = Cache.GetCharacter(collider);
            if (character == null)
            {
                Debug.LogWarning("Character is null");
                return;
            }

            if (character.floor != null && character.floor != floor)
            {

                NewFloor oldFloor = character.floor.GetComponent<NewFloor>();
                if (oldFloor != null)
                {
                    character.floor.RemoveBricksByColor(character.ColorType); 
                }
            }
                if (!colorTypes.Contains(character.ColorType))
                {
                    colorTypes.Add(character.ColorType);
                    character.floor = floor;
                    floor.InitColor(character);
            }
        
        }
    }
}
