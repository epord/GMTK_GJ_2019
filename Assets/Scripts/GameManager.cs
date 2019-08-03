using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterEvolution character;
    public float babyTime = 10.0f;
    public float adultTime = 10.0f;
    public float oldTime = 10.0f;

    private float[] lifeTimes = new float[3];
    private float elapsedTime = 0;
    private int currentLifeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimes = new float[] {babyTime, babyTime + adultTime, babyTime + adultTime + oldTime};
        Debug.Log(lifeTimes[0]);
        Debug.Log(lifeTimes[1]);
        Debug.Log(lifeTimes[2]);
    }

	// Update is called once per frame
	void Update()
    {
        elapsedTime += Time.deltaTime;
        if (currentLifeIndex < lifeTimes.Length && elapsedTime > lifeTimes[currentLifeIndex])
        {
            Debug.Log("Evolving " + elapsedTime + " " + currentLifeIndex);
            currentLifeIndex++;
            character.Evolve();
        }

    }
}
