using System.Collections;
using UnityEngine;

public class Donut : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    private Vector3 startPosition;
    [SerializeField] private Transform targetPosition, tempPosition;
    private Vector3[] moveLocations;
    private bool onceCheck = true;

    private void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        MoveObject();
    }

    public void MoveObject()
    {
        if (GameManager.Instance.GAMESTART)
        {
            if (transform.position != targetPosition.position)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    targetPosition.position, MoveSpeed * Time.deltaTime);
                onceCheck = true;
            }
            else if (onceCheck)
            {
                onceCheck = false;
                ChangeTarget();
            }
        }
        
    }
    private void ChangeTarget()
    {
        if (targetPosition.position == tempPosition.position)
        {
            targetPosition.position = startPosition;
        }
        else
        {
            StartCoroutine(Wait());

            IEnumerator Wait()
            {
                yield return new WaitForSeconds(5f);
                targetPosition.position = tempPosition.position;
            }
        }
    }
}