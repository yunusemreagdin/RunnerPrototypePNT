using System;
using UnityEngine;
using UnityEngine.AI;

public class Finish : MonoBehaviour
{
    public static Finish Instance{ set; get;}
    #region Variables

    public Transform first;
    public Transform second;
    public Transform third;
    public float counter = 0;
    public Transform failedPlayer;
    private float faieldAgentCounter;
    public Transform failedAgent;

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (counter == 0)
            {
                PlayerControl(other.gameObject, first);
            }
            else if (counter == 1)
            {
                PlayerControl(other.gameObject, second);
            }
            else if (counter == 2)
            {
                PlayerControl(other.gameObject, third);
            }
            else
                PlayerControl(other.gameObject, failedPlayer);
            
            StateManager.Instance.SwitchState(StateManager.Instance._finishState);
        }

        if (other.gameObject.CompareTag("Opponent"))
        {
            if (counter == 0)
            {
                OpponentControl(other.gameObject, first);
            }
            else if (counter == 1)
            {
                OpponentControl(other.gameObject, second);
            }
            else if (counter == 2)
            {
                OpponentControl(other.gameObject, third);
            }
            else
                FailedControl(other.gameObject, failedAgent);
        }
    }

    void OpponentControl(GameObject opponent, Transform rank)
    {
        opponent.transform.position = rank.transform.position;
        opponent.transform.eulerAngles = rank.transform.eulerAngles;
        //opponent.GetComponent<RotatePlayer>().enabled = false;
        opponent.GetComponent<AgentMovement>().enabled = false;
        opponent.GetComponent<NavMeshAgent>().enabled = false;
        opponent.GetComponent<Animator>().Play("Happy Idle");
        counter++;
    }

    void PlayerControl(GameObject player, Transform failed)
    {
        player.transform.position = failed.transform.position;
        player.transform.eulerAngles = failed.transform.eulerAngles;
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        GameManager.Instance.CANMOVE = true;
        GameManager.Instance.GAMESTART = false;
        GameManager.Instance.player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        GameManager.Instance.player.GetComponent<Animator>().Play("Happy Idle");
        GameManager.Instance.player.GetComponent<Animator>().Play("Wall");
        GameManager.Instance.wall.SetActive(true);
        GameManager.Instance.player.GetComponent<RotatePlayer>().enabled = false;
        counter++;
    }

    void FailedControl(GameObject agents, Transform faieldAgents)
    {
        agents.transform.position = faieldAgents.transform.position;
        agents.transform.eulerAngles = faieldAgents.transform.eulerAngles;
        agents.GetComponent<AgentMovement>().enabled = false;
        agents.GetComponent<NavMeshAgent>().enabled = false;
        agents.GetComponent<Animator>().Play("Happy Idle");
        failedAgent.position =
            new Vector3(failedAgent.position.x + .2f, failedAgent.position.y, failedAgent.position.z);
    }
}