using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { set; get;}

    private void Awake()
    {
        Instance = this;
    }

    // Karakterin hangi yöne doğru gideceğini ınputu alarak gönderiyoruz.
    public void GetInputs()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GameManager.Instance.inputDirection = InputDirection.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            GameManager.Instance.inputDirection = InputDirection.right;
        }
        else
            GameManager.Instance.inputDirection = InputDirection.forward;
    }
}
