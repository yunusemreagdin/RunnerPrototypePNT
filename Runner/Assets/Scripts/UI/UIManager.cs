using UnityEngine;

public class UIManager : MonoBehaviour
{
   public void StartGame()
   {
      GameManager.Instance.GAMESTART = true;
   }
   
}
