using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public LayerMask majongMask;
    private Dictionary<Sprite, Slot> slotByIcon = new Dictionary<Sprite, Slot>();

    public bool canClick = true;

    private void Start()
    {
        canClick = true;
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit, 3000f, majongMask);
        if (Input.GetMouseButtonUp(0) && canClick)
        {
            if (isHit)
            {
                var majong = hit.transform.GetComponent<Majong>();
                CollectMajong(majong);
                canClick = false;
            }
        }
    }

    private void CollectMajong(Majong majong)
    {
        if (!majong.isOnTop) return;

        Sprite icon = majong.GetMonsterIcon();
        if (slotByIcon.ContainsKey(icon))
        {
            var slot = slotByIcon[icon];
            slot.CollectMajong(majong);
        }
        else
        {
            if (slotByIcon.Count >= slots.Count)
            {
                return;
            }
            var slot = slots[slotByIcon.Count];
            slotByIcon.Add(icon, slot);
            slot.CollectMajong(majong);
        }
    }
}
