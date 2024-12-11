using UnityEngine;

public class ParalaxScript : MonoBehaviour
{

    [SerializeField] float effect;
    GameObject mainCamera;
    Vector3 LastCamPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera  =Camera.main.gameObject;
        LastCamPosition = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraMovement = mainCamera.transform.position - LastCamPosition;
        transform.position += new Vector3 (cameraMovement.x * effect, cameraMovement.y * effect, 0);
        LastCamPosition = mainCamera.transform.position;
    }
}
