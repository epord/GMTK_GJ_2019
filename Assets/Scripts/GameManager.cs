using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CharacterEvolution player;
    public float unbornTime = 2.0f;
    public float babyTime = 10.0f;
    public float adultTime = 10.0f;
    public float oldTime = 10.0f;
    public LevelEnd flag;
    public string nextScene;
    public GameObject rKey;

    private float[] lifeTimes = new float[3];
    private float elapsedTime = 0;
    private int currentLifeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (rKey)
            rKey.SetActive(false);
        lifeTimes = new float[] {
            unbornTime,
            unbornTime+ babyTime,
            unbornTime + babyTime + adultTime,
            unbornTime + babyTime + adultTime + oldTime
        };
    }

	// Update is called once per frame
	void Update()
    {
		elapsedTime += Time.deltaTime;
        
        if (currentLifeIndex < lifeTimes.Length && elapsedTime > lifeTimes[currentLifeIndex])
        {
            currentLifeIndex++;
            player.Evolve();
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void changeTime(float amount)
    {
        elapsedTime = Math.Max(elapsedTime + amount, 0);

        // evolve or devolve
        if (currentLifeIndex < lifeTimes.Length && elapsedTime > lifeTimes[currentLifeIndex])
        {
            currentLifeIndex++;
            player.Evolve();
        } else if (currentLifeIndex > 0 && elapsedTime < lifeTimes[currentLifeIndex])
        {
            currentLifeIndex--;
            player.Devolve();
        }
    }

    public void  Dead()
    {
        if (rKey)
            rKey.SetActive(true);
    }

    public void OnLevelFinished()
    {
        SceneManager.LoadScene(nextScene);
        Debug.Log("Level Finished");
    }
}
