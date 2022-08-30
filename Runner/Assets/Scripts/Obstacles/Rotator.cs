using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    #region Variables
    public float time;
    public float forcePower;
    

    #endregion
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Opponent"))
        {
            GameManager.Instance.CANMOVE = true;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.right * -forcePower);
            StartCoroutine(Timer(time));
        }
    }
    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.CANMOVE = false;
    }
}
