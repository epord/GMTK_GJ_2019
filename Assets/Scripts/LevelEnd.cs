using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{

    public int itemsNeeded = 3;

    public bool canFinish()
    {
        return itemsNeeded == 0;
    }

    public void itemGrabed()
    {
        itemsNeeded--;
    }
}
