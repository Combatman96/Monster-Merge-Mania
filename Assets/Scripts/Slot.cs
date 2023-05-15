using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slot : MonoBehaviour
{
    private Sprite monsterIcon;
    public List<Transform> slots = new List<Transform>();
    public Queue<Transform> posQueue = new Queue<Transform>();
    private Gameplay gameplay => FindObjectOfType<Gameplay>();
    [Range(0, 2)] public float collectTime = 0.8f;
    [Range(0, 2)] public float effectTime = 0.5f;
    public Transform slotGroup;

    public ResourceConfig resourceConfig;

    private void Start()
    {
        foreach (var s in slots)
        {
            posQueue.Enqueue(s);
        }
    }

    public void CollectMajong(Majong majong)
    {
        //if (majong.isCollected) return;
        if (IsFull()) return;

        majong.isCollected = true;
        Vector3 posStart = majong.transform.position;
        Transform slot = posQueue.Dequeue();
        Vector3 posEnd = slot.position;
        Vector3 posMid = ((posEnd + posStart) * 0.5f) + (Vector3.up * 2f);
        Vector3[] path = { posStart, posMid, posEnd };
        majong.transform.SetParent(slot);
        majong.transform.DOPath(path, collectTime, PathType.CatmullRom, PathMode.Full3D, gizmoColor: Color.red).OnComplete(() =>
        {
            OnMajongCollected(majong);
            majong.hitBox.enabled = false;
            gameplay.canClick = true;
        });
    }

    public bool IsFull()
    {
        return posQueue.Count == 0;
    }

    public void OnMajongCollected(Majong majong)
    {
        if (!IsFull()) return;
        var monsterResource = resourceConfig.GetMonster(majong.GetMonsterIcon());
        var monster = Instantiate(monsterResource, transform.position, Quaternion.identity, transform);
        monster.transform.localScale = Vector3.zero;
        slotGroup.transform.localScale = Vector3.one;
        var seq = DOTween.Sequence();
        seq
            .Append(slotGroup.DOScale(0f, effectTime / 2f))
            .Append(monster.transform.DOScale(1f, effectTime / 2f));
    }
}
