using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    #region Variables
    public Movement standartMovement;
    private MovementManager _movementManager;
    [HideInInspector] public bool isOnRotatePlatform;
    public static GroundChecker Instance { set; get;}
    

    #endregion
   
    private void Start()
    {
        _movementManager = GetComponent<MovementManager>();
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StandartPlatform"))
        {
           isOnRotatePlatform = false;
            gameObject.transform.parent = null;
            _movementManager._movement = standartMovement;
        }else if (collision.gameObject.CompareTag("RotateLeftPlatform") ||
                  collision.gameObject.CompareTag("RotateRightPlatform"))
        {
            isOnRotatePlatform = true;
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }
}
