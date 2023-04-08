using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public float speed = 10.0f;

	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		transform.Translate(horizontal, 0, vertical);
	}
}
