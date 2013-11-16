using UnityEngine;
using System.Collections;

public class StrangeLoop : MonoBehaviour 
{
	private static Color COLOR_ONE = Color.blue;
	private static Color COLOR_TWO = Color.green;

	public Transform anchor;
	public float radius = .1f;
	public float speed = .5f;
	public float switchDist = 1f;
	public bool isFirst = false;
	public int particleCount = 500;
	public float startSecondsRange = 3f;
	public float speedRange = .05f;
	public float radiusRange = .05f;
	
	
	private float theta = 0f;
	private Vector3 initPos;
	private float mult  = 1f;
	private bool switchBlocked = false;
	private bool isAnimating = false;
	private float anchorDist;
	private Color color = new Color (1f, 1f, 1f);

	
	// Use this for initialization
	void Start () 
	{
		initPos = transform.localPosition;
		if (isFirst)
		{
			generate();
			isAnimating = true;
		}
		else
		{
			float seconds = Random.Range(0f, startSecondsRange);
			StartCoroutine(startMeUp(seconds));
		}
	}
	
	void generate()
	{
		for (int a = 0; a < particleCount; a++)
		{
			GameObject go = GameObject.Instantiate(gameObject) as GameObject;
			StrangeLoop loop = go.GetComponent<StrangeLoop>();
			loop.isFirst = false;
			loop.radius += Random.Range(-radiusRange, radiusRange);
			loop.speed += Random.Range(-speedRange, speedRange);
			go.transform.parent = transform.parent;
			go.renderer.material = renderer.sharedMaterial;
		}
	}
	
	IEnumerator startMeUp(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		isAnimating = true;
	}
	
	// Update is called once per frame
		void FixedUpdate () 
	{
		if (!isAnimating)
			return;
		
		theta += speed;
		
		Vector3 pos = transform.localPosition;
		pos.x += Mathf.Cos (theta) * radius;
		pos.y += Mathf.Sin (theta) * radius * mult;
		pos.z += Mathf.Sin (theta) * radius * mult;
		
		transform.localPosition = initPos + pos;
		
		anchorDist = Vector3.Distance(transform.localPosition, anchor.localPosition);

		color.g = Mathf.Lerp (COLOR_ONE.g, COLOR_TWO.g, anchorDist * .01f);
		color.b = Mathf.Lerp (COLOR_ONE.b, COLOR_TWO.b, anchorDist * .01f);
		this.renderer.material.color = color;
		
		if (anchorDist < switchDist && ! switchBlocked)
		{
			mult *= -1f;
			switchBlocked = true;
		} else if (switchBlocked && anchorDist > switchDist)
		{
			switchBlocked = false;
		}
	}
}
