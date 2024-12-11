using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrabController : MonoBehaviour
{

    [SerializeField] int speed = 3;
    [SerializeField] Vector3 endPos;
    Vector3 startPos;
    bool gogoend = true;

[SerializeField] SpriteRenderer sprite;
float prevXposition;
    void Start()
    {
        startPos = transform.position;

        prevXposition =transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gogoend){

            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime); // La velocidad se 
        
             if( transform.position == endPos ){        

                 gogoend = false;
                 }
        } else {
            transform.position = Vector3.MoveTowards(transform.position,startPos, speed * Time.deltaTime);
             if( transform.position == startPos){
    
            gogoend =true;
    
            }
        }

        if (transform.position.x > prevXposition){

            sprite.flipX = true;
        } else if (transform.position.x< prevXposition){
            sprite.flipX = false;

        }

        prevXposition = transform.position.x;

}

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" && !GameManager.invulnerable){ // Ahora la exclamasion es indicativo de que es falso, no que niegue lo que ya esta escrito.

            other.gameObject.GetComponent<PlayerController>().damage();
        }
    }
}

