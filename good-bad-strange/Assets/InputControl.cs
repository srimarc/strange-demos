using UnityEngine;
using System.Collections;

public class InputControl : MonoBehaviour 
{

	public int index = 0;
	private float currentPos = 0f;
	private float destination = 0f;
	private bool changeQueued = false;
	private Vector3 startPos;
	private float startRot;
	private float finalYPos;
	private float finalRot;

	public GameObject edx_Slide;
	public float magnitude = 1f;
	public float speed = .01f;
	public float dismissDistance = 20f;
	public float secondsUntilFirstSlide = 2f;

	public Texture2D[] slides;

	// Use this for initialization
	void Start () 
	{
		setupFirstSlide ();
		StartCoroutine (firstSlide());
	}

	IEnumerator firstSlide()
	{
		yield return new WaitForSeconds (secondsUntilFirstSlide);
		summon ();
	}

	void setupFirstSlide ()
	{
		Debug.Log ("setting up first");

		updateSlide ();

		Vector3 pos = edx_Slide.transform.localPosition;
		pos.x = -1 * magnitude;
		pos.y = -dismissDistance;
		edx_Slide.transform.localPosition = pos;

		Quaternion q = edx_Slide.transform.localRotation;
		Vector3 rot = q.eulerAngles;
		rot.z = -90f * -1;
		q.eulerAngles = rot;
		edx_Slide.transform.localRotation = q;

		currentPos = 1;
		destination = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool advance = Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.DownArrow);
		bool backup = Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.UpArrow);

		bool toggle = Input.GetKeyDown (KeyCode.Q);

		//bool advance = Input.GetAxis ("horizontal") > 0;
		//bool backup = Input.GetAxis ("horizontal") > 0;

		int newIndex = index;

		if (advance)
			newIndex++;
		else if (backup)
			newIndex--;

		newIndex = Mathf.Clamp (newIndex, 0, slides.Length - 1);

		if (newIndex < index)
			dismiss (1);
		else if (newIndex > index)
			dismiss (-1);

		index = newIndex;

		if (toggle)
			edx_Slide.SetActive (!edx_Slide.activeSelf);
	}

	void FixedUpdate()
	{
		animate ();
	}

	void dismiss(float value)
	{
		changeQueued = true;
		destination = value;
		currentPos = 0;
		startPos = edx_Slide.transform.localPosition;
		finalYPos = -dismissDistance;
		startRot = 0f;
		finalRot = value * -90f;
	}

	void summon()
	{
		destination = 0;
		currentPos = 0;
		startPos = edx_Slide.transform.localPosition;
		finalYPos = 0f;
		startRot = -90f;
		finalRot = 0f;
	}

	void animate()
	{
		currentPos += (1 - currentPos) * speed;

		Vector3 pos = edx_Slide.transform.localPosition;
		pos.x = Mathf.Lerp (startPos.x, destination * magnitude, currentPos);
		pos.y = Mathf.Lerp (startPos.y, finalYPos, currentPos);
		edx_Slide.transform.localPosition = pos;

		Quaternion q = edx_Slide.transform.localRotation;
		Vector3 rot = q.eulerAngles;
		rot.z = Mathf.Lerp (startRot, finalRot, currentPos);
		q.eulerAngles = rot;
		edx_Slide.transform.localRotation = q;


		if (Mathf.Abs(currentPos - 1) < .1f && changeQueued)
		{
			updateSlide ();
			summon ();
		}
	}

	void updateSlide()
	{
		changeQueued = false;
		edx_Slide.renderer.material.mainTexture = slides [index];
		swapSides ();
	}

	void swapSides()
	{
		Vector3 pos = edx_Slide.transform.localPosition;
		pos.x *= -1;
		edx_Slide.transform.localPosition = pos;

		Quaternion q = edx_Slide.transform.localRotation;
		Vector3 rot = q.eulerAngles;
		rot.z *= -1;
		q.eulerAngles = rot;
		edx_Slide.transform.localRotation = q;
	}
}
