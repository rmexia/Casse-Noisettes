using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSModifier : MonoBehaviour 
{
	private bool enable = false;
	public float FPS = 1.0f;

	private Camera cameraToAffect;

	private bool drawCurrentFrame = false;
	private float timeElapsedFromLastFreeze = 0.0f;

	/////// unity methods /////////
	public void Start()
	{
		cameraToAffect = this.GetComponent<Camera>();

		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 80;

		if (enable)
		{
			drawCurrentFrame = On();
		}
	}

	public void FixedUpdate()
	{
		if (enable)
		{
			timeElapsedFromLastFreeze += Time.deltaTime;
			if (timeElapsedFromLastFreeze >= 1.0f/FPS)
			{
				timeElapsedFromLastFreeze = 0.0f;
				drawCurrentFrame = On();
			}
		}
		else {
			On();
			drawCurrentFrame = false;
		}
	}

	public void OnPostRender()
	{
		if (drawCurrentFrame) 
		{
			drawCurrentFrame = Off();
		}
	}

	/////////// Activate an desactivate freeze //////////////////

	private bool Off()
	{
		cameraToAffect.clearFlags = CameraClearFlags.Nothing;
     	cameraToAffect.cullingMask = (1 << LayerMask.NameToLayer("Nothing"));
		return false;
	}

	private bool On()
	{
		cameraToAffect.clearFlags = CameraClearFlags.SolidColor;
		cameraToAffect.cullingMask = -1;
		return true;
	}


	////////////////// activate ///////////////////////////

	public void Activate(int fps)
	{
		enable = true;
		FPS = fps;
	}

	public void Desactivate()
	{
		enable = false;
		On();
	}
}
