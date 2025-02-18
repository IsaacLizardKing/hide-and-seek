//Borrowed from Dr. Goadrich's code for "Townies"
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] bool firstInteraction = true;
    [SerializeField] int repeatStartPosition;
    

    public string npcName;
    public DialogueAsset dialogueAsset;
    public Sprite SpriteName; 

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