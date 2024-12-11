using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void StartGame(){

    SceneManager.LoadScene("lvl1");

   }

   public void EndGame(){

    Application.Quit();
    Debug.Log("se ha salido");
   }
}
