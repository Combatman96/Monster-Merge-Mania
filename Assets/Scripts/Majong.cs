using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Majong : MonoBehaviour
{
    public SpriteRenderer spriteIcon;
    public LayerMask majongLayerMask;
    public BoxCollider topChecker;
    public bool isOnTop = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    RaycastHit hit;
    float m_MaxDistance = 0.1f;
    // Update is called once per frame
    void FixedUpdate()
    {
        isOnTop = Physics.BoxCast(topChecker.center, topChecker.size, Vector3.up, out hit, topChecker.transform.rotation, 0, majongLayerMask);
        if (isOnTop)
        {
            Debug.Log(this.gameObject.name + " hit " + hit.transform.gameObject.name);
        }
    }
    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;

    //     //Check if there has been a hit yet
    //     if (isOnTop)
    //     {
    //         //Draw a Ray forward from GameObject toward the hit
    //         Gizmos.DrawRay(topChecker.position, topChecker.up * hit.distance);
    //         //Draw a cube that extends to where the hit exists
    //         Gizmos.DrawWireCube(topChecker.position + topChecker.up * hit.distance, topChecker.localScale);
    //     }
    //     //If there hasn't been a hit yet, draw the ray at the maximum distance
    //     else
    //     {
    //         //Draw a Ray forward from GameObject toward the maximum distance
    //         Gizmos.DrawRay(topChecker.position, topChecker.up * m_MaxDistance);
    //         //Draw a cube at the maximum distance
    //         Gizmos.DrawWireCube(topChecker.position + topChecker.up * m_MaxDistance, topChecker.localScale);
    //     }
    // }

    public Sprite GetMonsterIcon()
    {
        return spriteIcon.sprite;
    }
}
