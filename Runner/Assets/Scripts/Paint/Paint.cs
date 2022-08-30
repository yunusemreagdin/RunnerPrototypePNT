using UnityEngine;

public class Paint : MonoBehaviour
{
    #region Variables

    public static Paint Instance { set; get;}
    public GameObject mask;
    private bool isPressed;


    #endregion
    
    private void Awake()
    {
        Instance = this;
    }

    public void Paintable()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 1.5f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (isPressed && GameManager.Instance.CANMOVE)
        {
            GameObject maskSprite = Instantiate(mask, mousePos, Quaternion.identity);
            maskSprite.transform.parent = gameObject.transform;
            
        }
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.CANMOVE)
        {
            isPressed = true;
        }else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
        }
    }
}
