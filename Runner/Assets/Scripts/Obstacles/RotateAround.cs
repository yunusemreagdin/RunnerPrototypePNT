using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (GameManager.Instance.GAMESTART)
        {
            if (gameObject.CompareTag("RotateLeftPlatform"))
            {
                transform.RotateAround(transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
            }
            else if (gameObject.CompareTag("RotateRightPlatform"))
            {
                transform.RotateAround(transform.position, Vector3.forward, -rotateSpeed * Time.deltaTime);
            }
            else if (gameObject.CompareTag("Rotator"))
            {
                transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
            }else
                transform.RotateAround(transform.position, Vector3.down, rotateSpeed * Time.deltaTime);
        }
    }
}
