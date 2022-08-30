using UnityEngine;

public class MovementManager : MonoBehaviour
{
    #region Variables
    public Movement _movement;
    public Rigidbody rigidbody;
    public Animator animator;
    public float speed;
    

    #endregion
    
    private void FixedUpdate()
    {
        _movement.Process(rigidbody,animator,speed,transform);
    }
}
