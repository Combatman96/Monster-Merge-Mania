using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceConfig", menuName = "Resource/ResourceConfig", order = 1)]
public class ResourceConfig : ScriptableObject
{
    public List<Sprite> monsterIcons = new List<Sprite>();
    public List<Majong> majongs = new List<Majong>();
    public List<GameObject> monsters = new List<GameObject>();

    private Dictionary<Sprite, GameObject> dict = new Dictionary<Sprite, GameObject>();

    public GameObject GetMonster(Sprite icon)
    {
        if (dict.Count == 0)
        {
            int n = monsterIcons.Count;
            for (int i = 0; i < n; i++)
            {
                dict.Add(monsterIcons[i], monsters[i]);
            }
        }
        return dict[icon];
    }
}
