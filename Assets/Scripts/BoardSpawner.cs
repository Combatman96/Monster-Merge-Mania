using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class BoardSpawner : MonoBehaviour
{
    public ResourceConfig resourceConfig;
    public Transform boardNew;

    [Button]
    public void SetUpBoardRandom()
    {
        var listMajong = resourceConfig.majongs;
        var listPos = new List<Vector3>();
        foreach (Transform child in transform)
        {
            listPos.Add(child.position);
        }
        foreach (var pos in listPos)
        {
            int index = Random.Range(0, listMajong.Count);
            var majong = listMajong[index];
            Instantiate(majong, pos, Quaternion.identity, boardNew);
        }
    }
}
