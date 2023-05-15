using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Majong : MonoBehaviour
{
    public SpriteRenderer spriteIcon;
    public LayerMask majongLayerMask;
    public Transform topChecker;
    public bool isOnTop = true;

    public Collider hitBox;

    public Color topColor;
    public Color belowColor;

    public MeshRenderer mesh;

    public bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        isOnTop = true;
        isCollected = false;
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
