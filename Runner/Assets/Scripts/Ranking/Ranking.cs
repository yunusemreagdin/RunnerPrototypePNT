using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    #region Variables

    public static Ranking Instance { set; get; }
    [SerializeField] public List<GameObject> _rankList;
    private List<GameObject> _rank;
    [SerializeField] private Transform endPosition;
    [SerializeField] private List<TextMeshProUGUI> textList;
    [SerializeField] public GameObject rankPanel;
    private int index = 0;

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    public void Rank()
    {
        _rank = _rankList.OrderBy(
            x => Vector3.Distance(endPosition.position, x.transform.position)
        ).ToList();

        foreach (var item in textList)
        {
            item.text = _rank[index].name;
            index++;
            if (index == textList.Count)
            {
                index = 0;
            }
        }
    }
}