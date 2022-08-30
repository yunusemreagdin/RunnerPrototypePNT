using UnityEngine;

public class BeforeGameState : BaseState
{
    public override void UptadeState(StateManager stateManager)
    {
        Debug.Log("BeforeGameState");
        if (GameManager.Instance.GAMESTART)
        {
            stateManager.SwitchState(stateManager._inGameState);
        }
    }
    public override void EnterState(StateManager stateManager)
    {
        GameManager.Instance.player.GetComponent<MovementManager>().enabled = false;
    }
}
