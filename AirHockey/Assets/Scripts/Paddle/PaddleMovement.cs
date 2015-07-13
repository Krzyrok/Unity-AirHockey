using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {
	private static float _speed = 10.0F;
	private static float _paddleMaximumZPosition = -5.0f;

	public static void UpdatePosition(float verticalAxis, float horizontalAxis, GameObject paddle)
	{
		float oldPaddlePositionZ = paddle.transform.position.z;
		
		float translationVertical = verticalAxis * _speed * Time.deltaTime;
		float translationHorizontal = horizontalAxis * _speed * Time.deltaTime;
		paddle.transform.Translate(translationHorizontal, 0, translationVertical);
		
		float newPaddlePositionZ = paddle.transform.position.z;
		if (oldPaddlePositionZ > _paddleMaximumZPosition && newPaddlePositionZ > oldPaddlePositionZ) 
		{
			float newPaddlePositionX = paddle.transform.position.x;
			float newPaddlePositionY = paddle.transform.position.y;
			paddle.transform.position = new Vector3(newPaddlePositionX, newPaddlePositionY, oldPaddlePositionZ);
		}
	}

}
