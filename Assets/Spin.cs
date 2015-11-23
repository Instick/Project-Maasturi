using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	public float speed = 25f;
	
	
	void Update ()
	{

		transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);
	}
}