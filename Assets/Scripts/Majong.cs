using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Majong : MonoBehaviour
{
    public SpriteRenderer spriteIcon;
    public LayerMask majongLayerMask;
    public Transform topChecker;
    public bool isOnTop = true;

    public Color topColor;
    public Color belowColor;

    public MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        isOnTop = true;
    }

    private void Update()
    {
        if (isOnTop)
        {
            Material topMat = mesh.materials[1];
            topMat.color = topColor;
        }
        else
        {
            Material topMat = mesh.materials[1];
            topMat.color = belowColor;
        }
    }

    public Sprite GetMonsterIcon()
    {
        return spriteIcon.sprite;
    }
}
