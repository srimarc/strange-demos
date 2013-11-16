using UnityEngine;
using System.Collections;

public class ParticleSystemRotation : MonoBehaviour 
{

	public float speed = .1f;
	
	void Update () 
	{
		Quaternion q = transform.localRotation;
		Vector3 rot = q.eulerAngles;
		rot.z += speed;
		q.eulerAngles = rot;
		transform.localRotation = q;
	}
}
