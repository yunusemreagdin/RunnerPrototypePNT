using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    #region Variables

    public static StateManager Instance { set; get;}
    
    BaseState currentState;

    public BeforeGameState _beforeGameState = new BeforeGameState();

    public InGameState _inGameState = new InGameState();

    public InPaintState _inPaintState = new InPaintState();

    public FinishState _finishState = new FinishState();

    #endregion
    
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = _beforeGameState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UptadeState(this);
    }
    
    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this); 
    }
}
