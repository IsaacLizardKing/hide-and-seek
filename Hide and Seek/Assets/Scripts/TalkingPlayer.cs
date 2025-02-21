//Borrowed from Dr. Goadrich's code for "Townies"
using UnityEngine;

public class TalkingPlayer : MonoBehaviour
{
    [SerializeField] float talkDistance = 2;
    bool inConversation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        Debug.Log("Interact");
        if (inConversation) {
            Debug.Log("Skipping Line");
            GameManager.Instance.SkipLine();
        }
        else
        {
            Debug.Log("Looking for Hiding Spot");
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, talkDistance, GameManager.Instance.playerFacing, 1.25f, LayerMask.GetMask("Hiding Spot"));
            if (hit) {
                if (hit.collider.gameObject.TryGetComponent(out NPC npc))
                {
                    GameManager.Instance.StartDialogue(npc.dialogueAsset.dialogue, npc.StartPosition, npc.npcName, npc.SpriteName, (npc.PortPosition, npc.PortScale));  
                    if(hit.collider.gameObject.TryGetComponent(out HidingSpot hs)){
                        hs.OnFind();
                    }
                }
            } else {
                Debug.Log("Looking for NPC");
                RaycastHit2D nit = Physics2D.CircleCast(transform.position, talkDistance, GameManager.Instance.playerFacing, 1.25f, LayerMask.GetMask("NPC"));
                if (nit)
                {
                    Debug.Log("Hit Something!!" + nit.collider.gameObject.name);

                    if (nit.collider.gameObject.TryGetComponent(out NPC npc))
                    {
                        GameManager.Instance.StartDialogue(npc.dialogueAsset.dialogue, npc.StartPosition, npc.npcName, npc.SpriteName, (npc.PortPosition, npc.PortScale));
                        
                    }
                }
            }
        }
    }

    void JoinConversation()
    {
        inConversation = true;
    }

    void LeaveConversation()
    {
        inConversation = false;
    }

    private void OnEnable()
    {
        GameManager.OnDialogueStarted += JoinConversation;
        GameManager.OnDialogueEnded += LeaveConversation;
    }

    private void OnDisable()
    {
        GameManager.OnDialogueStarted -= JoinConversation;
        GameManager.OnDialogueEnded -= LeaveConversation;
    }
}