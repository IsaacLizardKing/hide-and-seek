using UnityEngine;

public class PlayerLayerResolver : MonoBehaviour
{
    public GameObject player;

    private SpriteRenderer rend;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if(this.transform.position.y < player.transform.position.y) {
            rend.sortingOrder = 5;
        } else {
            rend.sortingOrder = 3;
        }
    }
}
