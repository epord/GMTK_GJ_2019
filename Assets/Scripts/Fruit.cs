using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public LevelEnd levelEnd;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider is BoxCollider2D)
        {
            levelEnd.itemGrabed();
            Destroy(this.gameObject);
        }
	}
}
