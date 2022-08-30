using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
    [SerializeField] private Transform[] Positions;
    [SerializeField] private float MoveSpeed;
    private Transform NextPosition;
    private int NextPositionIndex;
    private float timer;

    private void Start()
    {
        NextPosition = Positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }


    public void MoveObject()
    {
        if (GameManager.Instance.GAMESTART)
        {
            if (transform.position == NextPosition.position)
            {
                NextPositionIndex++;
                if (NextPositionIndex >= Positions.Length)
                {
                    NextPositionIndex = 0;
                }

                NextPosition = Positions[NextPositionIndex];
            }
            else
                transform.position = Vector3.MoveTowards(transform.position,
                    NextPosition.position, MoveSpeed * Time.deltaTime);
        }
        
    }
}