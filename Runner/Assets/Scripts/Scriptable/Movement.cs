using UnityEngine;

public class Movement : ScriptableObject
{
    public virtual void Process(Rigidbody rigidbody,Animator animator,float Speed,Transform transform)
    {
        if (!GameManager.Instance.CANMOVE)
        {
            rigidbody.velocity = Vector3.forward * Speed * Time.deltaTime + new Vector3(0,rigidbody.velocity.y,0);
            animator.Play("Running");
        }
        
    }
}
