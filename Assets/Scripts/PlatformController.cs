using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformController : MonoBehaviour
{

    [SerializeField] int speed = 3;
    [SerializeField] Vector3 endPos;
    Vector3 startPos;
    bool gogoend = true;

    void Start()
    {
        startPos = transform.position;
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

}

  void OnCollisionEnter2D (Collision2D other)
     {
         if(other.gameObject.tag == "Player"){
             other.gameObject.transform.SetParent(transform);
         }

         if(other.gameObject.tag == "Player"){
             Destroy(other.gameObject);
         }
     }

      void OnCollisionExit2D (Collision2D other)
     {
         if(other.gameObject.tag == "Player"){
             other.gameObject.transform.SetParent(null); // Para quitar el padre al momento de sali de la colission  se cambia el padre a que sea ninguno 
         }
     }

    // void OnTriggerEnter2D(Collider2D other){
    //     if(other.gameObject.tag == "Player"){
    //         SceneManager.LoadScene("lvl1");
    //     }
    }


