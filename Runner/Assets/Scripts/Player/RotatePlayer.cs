using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    #region Variables
    public static RotatePlayer Instance { set; get;}
    public Transform backLeft;
    public Transform backRight;
    public Transform frontLeft;
    public Transform frontRight;
    public RaycastHit lr;
    public RaycastHit rr;
    public RaycastHit lf;
    public RaycastHit rf;
    private Vector3 upDir;
    public LayerMask layer_mask;
    

    #endregion
   

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Ray();
    }

    #region Player Raycast
    public void Ray()
    {
        Physics.Raycast(backLeft.position + Vector3.up, Vector3.down,out lr,5f,layer_mask);
        Physics.Raycast(backRight.position + Vector3.up, Vector3.down, out rr,5f,layer_mask);
        Physics.Raycast(frontLeft.position + Vector3.up, Vector3.down, out lf,5f,layer_mask);
        Physics.Raycast(frontRight.position + Vector3.up, Vector3.down, out rf,5f,layer_mask);
        
        Debug.DrawRay(rr.point, Vector3.up);
        Debug.DrawRay(lr.point, Vector3.up);
        Debug.DrawRay(lf.point, Vector3.up);
        Debug.DrawRay(rf.point, Vector3.up);
        //transform.up = upDir;
       
        // Get the vectors that connect the raycast hit points
 
        Vector3 a = rr.point - lr.point;
        Vector3 b = rf.point - rr.point;
        Vector3 c = lf.point - rf.point;
        Vector3 d = rr.point - lf.point;
 
        // Get the normal at each corner
 
        Vector3 crossBA = Vector3.Cross (b, a);
        Vector3 crossCB = Vector3.Cross (c, b);
        Vector3 crossDC = Vector3.Cross (d, c);
        Vector3 crossAD = Vector3.Cross (a, d);
 
        // Calculate composite normal
        Vector3 newUp = (crossBA + crossCB + crossDC + crossAD).normalized;

        transform.up = Vector3.Lerp(transform.up, newUp, 15f * Time.deltaTime);
    }
    

    #endregion
    
}
