using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSlotManager : MonoBehaviour
{
    public Transform slotParent;
    public GameObject slotPrefab;
    public List<ScoreData> datas;
    public List<ScoreSlot> slots;

    [ContextMenu("Create Slots")]
    public void Context_CreateSlots()
    {
        CreateSlots(datas.ToArray());
    }

    void OnEnable()
    {
        datas = new List<ScoreData>(ScoreData.LoadAll());
        CreateSlots(datas.ToArray());
    }

    public void ClearSlots()
    {
        ScoreSlot[] currentSlots = slotParent.GetComponentsInChildren<ScoreSlot>();
        foreach (ScoreSlot slot in currentSlots) RemoveSlot(slot);
        slots.Clear();
    }

    public ScoreSlot[] CreateSlots(ScoreData[] _datas)
    {
        ClearSlots();

        _datas.Sort();

        foreach (ScoreData data in this.datas) CreateSlot(data);

        return slots.ToArray();
    }

    public ScoreSlot CreateSlot(ScoreData _data = null)
    {
        GameObject slotObject = Instantiate(slotPrefab, slotParent);

        ScoreSlot slot = slotObject.GetComponent<ScoreSlot>();

        slots.Add(slot);

        if (_data != null) slot.SetData(_data);

        return slot;
    }

    public void RemoveSlot(ScoreSlot slot)
    {
        slots.Remove(slot);
        DestroyImmediate(slot.gameObject);
    }
}
