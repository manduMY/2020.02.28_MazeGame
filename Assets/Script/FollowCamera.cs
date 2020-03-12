using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	// The target we are following
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 7.0f;
	// the height we want the camera to be above the target
	public float height = 7.0f;
	// How much we 
	public float heightDamping = 2.0f;
	//시간 체크값
	int a = 0, b = 0;
	//시간체크무한반복 방지
	public bool check = true;
	//수평이동하기 위해서는 0을 유지
	public float rotationDamping = 0;
	// Place the script in the Camera-Control group in the component menu
	[AddComponentMenu("Camera-Control/Smooth Follow")]
	void LateUpdate()
	{
		// Early out if we don't have a target
		if (!target) return;
		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		// Damp the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Convert the angle into a rotation
		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		// Set the height of the camera
		transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

		// Always look at the target
		transform.LookAt(target);

		if (Input.GetKeyDown(KeyCode.A) && check)
		{
			check = false;
			for (; ; )
			{
				if (a == 1 && b == 1)
				{
					break;
				}
				if (distance > 1)
				{
					distance = distance - 0.1f;
				}
				else
				{
					a = 1;
				}
				if (height < 25)
				{
					height = height + 0.1f;
				}
				else
				{
					b = 1;
				}
			}
			a = 0;
			b = 0;

		}
		StartCoroutine(WaitForIt()); //Coroutine 함수 실행
	}

	IEnumerator WaitForIt()
	{
		yield return new WaitForSeconds(5f); //3초 기다린다.
		for (; ; )
		{
			if (a == 1 && b == 1)
			{
				break;
			}
			if (distance < 10)
			{
				distance = distance + 0.1f;
			}
			else
			{
				a = 1;
			}
			if (height > 5)
			{
				height = height - 0.1f;
			}
			else
			{
				b = 1;
			}
		}
		check = true;
	}

}
