using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float timeDistortionAmount = 7;
    public GameManager gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            gm.changeTime(timeDistortionAmount);
            Destroy(this.gameObject);
        }
    }

}
