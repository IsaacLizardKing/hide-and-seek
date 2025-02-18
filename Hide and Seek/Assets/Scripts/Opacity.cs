using UnityEngine;
using UnityEngine.Tilemaps;

public class Opacity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public float lerpSpeed = 0.01f;
    public Tilemap tlmp; 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.transform.position.y < 0) {
            var color = tlmp.color;
            tlmp.color = new Color (color[0], color[1], color[2], color[3] - color[3] * lerpSpeed);
        }
    }
}
