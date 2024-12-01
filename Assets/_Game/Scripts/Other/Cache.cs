using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache : MonoBehaviour
{
    private static Dictionary<Collider, Character> characterCache = new Dictionary<Collider, Character>();
    private static Dictionary<Collider,StepStair> stepStairCache = new Dictionary<Collider, StepStair>();
    private static Dictionary<Collider, GroundBrick> groundBrickCache = new Dictionary<Collider, GroundBrick>();
    //private static Dictionary<Collider,GroundBrick> botGetGroundBrickCache = new Dictionary<Bot, GroundBrick>();


    public static Character GetCharacter(Collider collider)
    {
        if (characterCache.ContainsKey(collider))
        {
            return characterCache[collider];
        }
        else
        {
            Character character = collider.GetComponent<Character>();
            if (character != null)
            {
                characterCache.Add(collider, character);
            }
            return character;
        }
    }

    public static StepStair GetStepStair(Collider collider)
    {
        if (stepStairCache.ContainsKey(collider))
        {
            return stepStairCache[collider];
        }
        else
        {
            StepStair stepStair = collider.GetComponent<StepStair>();
            if (stepStair != null)
            {
                stepStairCache.Add(collider, stepStair);
            }
            return stepStair;
        }
    }

    public static GroundBrick GetGroundBrick(Collider collider)
    {
        if (groundBrickCache.ContainsKey(collider))
        {
            return groundBrickCache[collider];
        }
        else
        {
            GroundBrick groundBrick = collider.GetComponent<GroundBrick>();
            if (groundBrick != null)
            {
                groundBrickCache.Add(collider, groundBrick);
            }
            return groundBrick;
        }
    }



}
