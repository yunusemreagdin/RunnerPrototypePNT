using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public static LevelProgress Instance { set; get;}
    
    [Header("UI Referances")] [SerializeField]
    private Image uiFillImage;

    [Header("Player and EndLine referances")] [SerializeField]
    private Transform playerTransform;

    [SerializeField] private Transform endLineTransform;

    private Vector3 endLiePosition;
    private float fullDistance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        endLiePosition = endLineTransform.position;
        fullDistance = GetDistance();
    }
    private float GetDistance()
    {
        return Vector3.Distance(playerTransform.position, endLiePosition);
    }

    private void UptadeProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
    }

    public void ProgressBar()
    {
        float newDİstance = GetDistance();
        float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDİstance);

        UptadeProgressFill(progressValue);
    }
}