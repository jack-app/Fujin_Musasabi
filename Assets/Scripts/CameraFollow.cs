using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;

    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            mainCam.transform.position = new Vector3(targetObject.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z);
        }
    }
}
