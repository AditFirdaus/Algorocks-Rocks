using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSlot : MonoBehaviour
{
    public TMP_Text number;
    public TMP_Text date;
    public TMP_Text score;

    public int slotIndex => (transform.GetSiblingIndex() + 1);

    public void SetData(ScoreData data)
    {
        number.text = slotIndex.ToString();
        date.text = data.date.ToString("yyyy-MM-dd");
        score.text = data.score.ToString();
    }
}
