﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreOcean : MonoBehaviour
{
	public Text Score;

	public float score;

	public DataSaving Saving;

	public SaveHighScore save;

    bool start;

    void Start()
	{
		Saving = new DataSaving();
		save = Saving.Load();
		score = 0;

        StartCoroutine(pauseStart());
	}

    IEnumerator pauseStart()
    {
        while (!(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)))
        {
            yield return null;
        }
        start = true;
    }

    void Update()
	{
        if (start)
        {
            score += Time.deltaTime;
            Score.text = string.Format("Score: {0}", Mathf.Round(score));
        }
        else
            Score.text = "Score: 0";
	}

	void OnDestroy()
	{
		if (score > save.OceanScore)
		{
			save.OceanScore = score;
		}
		Saving.Save(save);
		//Debug.Log("Saved score ocean: " + save.OceanScore);
		//Debug.Log("Saved score sky: " + save.SkyScore);
		//Debug.Log("Saved score space: " + save.SpaceScore);
	}
}