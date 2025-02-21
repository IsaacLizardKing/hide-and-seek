//Borrowed from Dr. Goadrich's code for "Townies"
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] bool firstInteraction = true;
    [SerializeField] int repeatStartPosition;
    

    public string npcName;
    public DialogueAsset dialogueAsset;
    public Sprite SpriteName; 
    public Vector3 PortPosition; // relative position to the camera for the portrait;
    public Vector3 PortScale;
    
    [HideInInspector]
    public int StartPosition
    {
        get
        {
            if (firstInteraction)
            {
                firstInteraction = false;
                return 0;
            }
            else
            {
                return repeatStartPosition;
            }
        }
    }
}