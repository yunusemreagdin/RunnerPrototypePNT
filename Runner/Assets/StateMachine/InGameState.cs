using UnityEngine;

public class InGameState : BaseState
{
    public override void UptadeState(StateManager stateManager)
    {
        //CameraFollow.Instance.CameraFollowPlayer();
        InputManager.Instance.GetInputs();
        Ranking.Instance.Rank();
        LevelProgress.Instance.ProgressBar();
        Debug.Log("InGame");
    }

    public override void EnterState(StateManager stateManager)
    {
        Ranking.Instance.rankPanel.SetActive(true);
        GameManager.Instance.player.GetComponent<MovementManager>().enabled = true;
    }
}
