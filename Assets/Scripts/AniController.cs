using UnityEngine;

public class AniController : MonoBehaviour
{
  public void endShoot(){
    Animator anim = GetComponent<Animator>();
    anim.SetBool("isShooting", false);
  }
}
