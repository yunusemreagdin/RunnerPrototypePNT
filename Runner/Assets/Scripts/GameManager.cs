using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get;}

    #region Variables
    public bool GAMESTART;
    public bool CANMOVE;
    public GameObject player;
    public GameObject wall;
    public GameObject progressBar;
    public GameObject ranking;
    [HideInInspector] public InputDirection inputDirection;
    #endregion

    #region Singleteon
    private void Awake()
    {
        Instance = this;
    }
    

    #endregion
    
    public void SetActiveFalse(GameObject setActive)
    {
        setActive.gameObject.SetActive(false);
    }
}
    #region Enum
    public enum InputDirection
    {
    forward,
    right,
    left
    }
#endregion

