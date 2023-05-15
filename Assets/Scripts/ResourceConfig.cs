using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceConfig", menuName = "Resource/ResourceConfig", order = 1)]
public class ResourceConfig : ScriptableObject
{
    public List<Sprite> monsterIcons = new List<Sprite>();
    public List<Majong> majongs = new List<Majong>();
}
