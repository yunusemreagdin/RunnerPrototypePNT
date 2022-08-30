using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance { set; get;}
    public Transform player;
    public Vector3 offset;
    public float cameraSpeed;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, cameraSpeed * Time.deltaTime);
    }

    public void FinishStateCamera()
    {
        Camera camera = Camera.main;
        Vector3 newCameraPosition = new Vector3(0, .8f, 6.094f);
        camera.transform.position = new Vector3(0, newCameraPosition.y, newCameraPosition.z);
        camera.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}