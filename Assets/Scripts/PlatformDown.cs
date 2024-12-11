using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class PlatformDown : MonoBehaviour
{
[SerializeField]    private float tiempoesp;

[SerializeField] GameObject PlataAdios;
private Rigidbody2D rb;

void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   private void OnCollisionEnter2D(Collision2D other){

    if(other.gameObject.CompareTag("Player"))
    {
        Invoke("adiosplata", 2);
            Debug.Log("esta llamando");
    }
   }

   void adiosplata()
    {
        print("adiosplata");
        PlataAdios.SetActive(false);
        Invoke("HolaPlata", 5);

    }

     void HolaPlata()
    {

        PlataAdios.SetActive(true);
    }

}
