using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public GameObject Hider;
    public Vector3 HidePosition;
    public Vector3 RevealPosition;
    public float slurp;
    
    private Vector3 destination;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
       // destination = Hider.transform.position;
       destination = HidePosition;
    }

    // Update is called once per frame
    void Update() {
        if (Hider.transform.position != destination) Hider.transform.position = Vector3.Lerp(Hider.transform.position, destination, slurp);
    }

    public void OnFind() {
        destination = RevealPosition;
        Hider.GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("Enabling collider!");
    }

    public void OnHide() {
        Hider.GetComponent<BoxCollider2D>().enabled = false;
        destination = HidePosition;
    }  
}
