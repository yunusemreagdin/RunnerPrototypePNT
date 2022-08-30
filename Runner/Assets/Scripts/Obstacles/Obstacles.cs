using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }else if (collision.gameObject.CompareTag("Opponent"))
        {
            Debug.Log("OOponent");
            collision.transform.position = collision.gameObject.GetComponent<AgentMovement>().startPos;
        }
    }
}
