using System;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Create/AgentMovement")]
public class AgentMovement : MonoBehaviour
{
    public static AgentMovement Instance { set; get; }
   
    #region Variables
    public NavMeshAgent agent;
    public Transform end;
    [HideInInspector] public Vector3 startPos;
    public Animator animator;

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        startPos = transform.position;
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.GAMESTART && !GameManager.Instance.CANMOVE)
        {
            animator.Play("Running");
            agent.SetDestination(end.transform.position);
        }
    }
}
