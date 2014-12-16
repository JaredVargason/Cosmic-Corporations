﻿using UnityEngine;
using System.Collections;

public class SceneFade : MonoBehaviour
{
	public float fadeSpeed = 3f;
	public int levelToLoad;
	private bool sceneStarting = true;
	
	
	void Awake ()
	{
		guiTexture.color = Color.black;
		// Set the texture so that it is the the size of the screen and covers it.
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}
	
	
	void Update ()
	{
		if(sceneStarting)
			StartScene();
	}
	
	
	void FadeToClear ()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		FadeToClear();

		if(guiTexture.color.a <= 0.001f)
		{
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;

			sceneStarting = false;
		}
	}
	
	
	public void EndScene ()
	{
		guiTexture.enabled = true;

		FadeToBlack();

		if(guiTexture.color.a >= 0.70f)

			Application.LoadLevel(levelToLoad);
	}
}