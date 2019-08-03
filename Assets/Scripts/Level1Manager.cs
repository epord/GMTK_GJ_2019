using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public CharacterEvolution player;
    public GameObject rKey;
    public GameObject spaceKey;
    public Area initialArea;
    public Area secondArea;

    private float cumulatedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rKey.SetActive(false);
        spaceKey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cumulatedTime += Time.deltaTime;

        if (player.currentState == CharacterState.ADULT && initialArea.isPlayerInArea)
        {
            rKey.SetActive(true);
        } else {
            rKey.SetActive(false);
        }

        if (player.currentState == CharacterState.ADULT && secondArea.isPlayerInArea)
        {
            spaceKey.SetActive(true);
        } else {
            spaceKey.SetActive(false);
        }

    }
}
