using UnityEngine;

[CreateAssetMenu(menuName = "Create/StandartMovement")]
public class StandartMovement : Movement
{
    [SerializeField] private float swipeSpeed;

    public override void Process(Rigidbody _rigidbody,Animator animator,float speed,Transform transform)
    {
        if (GameManager.Instance.GAMESTART && !GameManager.Instance.CANMOVE) 
        {
            base.Process(_rigidbody,animator,speed,transform);
           if (GameManager.Instance.inputDirection == InputDirection.left)
           {
               _rigidbody.velocity +=  Vector3.left * swipeSpeed * Time.deltaTime;
            
           }
           else if (GameManager.Instance.inputDirection == InputDirection.right)
           {
               _rigidbody.velocity += Vector3.right * swipeSpeed * Time.deltaTime;
           } 
        }
    }
}