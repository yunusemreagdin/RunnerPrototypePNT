
public class FinishState : BaseState
{
    public override void UptadeState(StateManager stateManager)
    {
    }

    public override void EnterState(StateManager stateManager)
    {
        GameManager.Instance.SetActiveFalse(GameManager.Instance.ranking);
        GameManager.Instance.SetActiveFalse(GameManager.Instance.progressBar);
        CameraFollow.Instance.FinishStateCamera();
        stateManager.SwitchState(stateManager._inPaintState);
    }
}
