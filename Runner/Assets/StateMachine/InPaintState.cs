using UnityEngine;

public class InPaintState : BaseState
{
    public override void UptadeState(StateManager stateManager)
    {
        Debug.Log("PaintState");
        Paint.Instance.Paintable();
    }

    public override void EnterState(StateManager stateManager)
    {
    }
}
