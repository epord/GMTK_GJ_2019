using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public bool isPlayerInArea = false;

    void OnTriggerStay2D(Collider2D collider)
    {
        isPlayerInArea = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isPlayerInArea = false;
    }

}
