using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject MenuP;

    public void conti(){

        MenuP.SetActive(false);
        Time.timeScale=1;

    }

    public void resta(){

        SceneManager.LoadScene("lvl1");
    }

    public void next(){

        SceneManager.LoadScene("lvl1");
    }

    public void main(){

        SceneManager.LoadScene("Menu");
    }

    public void Credits(){

        SceneManager.LoadScene("Credits");
    }

    
}
