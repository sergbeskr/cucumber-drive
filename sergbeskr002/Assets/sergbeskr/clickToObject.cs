using UnityEngine;
using System.Collections.Generic;

public class clickToObject : MonoBehaviour {

	public List<KeyCode> upButton;
	public List<KeyCode> downButton;
	public List<KeyCode> leftButton;
	public List<KeyCode> rightButton;
	public List<KeyCode> backButton;
	public List<KeyCode> forwardButton;

	public float playerSpeed = 2.0f;
	private float currentSpeed = 0.0f;
	private Vector3 lastMovement = new Vector3();

	void Update () {
		//Debug.Log("___000___");
		Movement();
	}

	// Движение героя к мышке
	void Movement() {
		// Необходимое движение
		Vector3 movement = new Vector3();
		// Проверка нажатых клавиш
		movement += MoveIfPressed(upButton, Vector3.up);
		movement += MoveIfPressed(downButton, Vector3.down);
		movement += MoveIfPressed(leftButton, Vector3.left);
		movement += MoveIfPressed(rightButton, Vector3.right);
		movement += MoveIfPressed(backButton, Vector3.back);
		movement += MoveIfPressed(forwardButton, Vector3.forward);
		// Если нажато несколько кнопок, обрабатываем это
		movement.Normalize();
		// Проверка нажатия кнопки
		if(movement.magnitude > 0)
		{
			// После нажатия двигаемся в этом направлении
			currentSpeed = playerSpeed;
			this.transform.Translate(movement * Time.deltaTime * playerSpeed, Space.World);
			lastMovement = movement;
		}
		else
		{
			// Если ничего не нажато
//			this.transform.Translate(lastMovement * Time.deltaTime * currentSpeed, Space.World);
			// Замедление со временем
			currentSpeed *= 0.19f;
		}
	}

	// Возвращает движение, если нажата кнопка
	Vector3 MoveIfPressed(List<KeyCode> keyList, Vector3 Movement) {
		// Проверяем кнопки из списка
		foreach (KeyCode element in keyList)
		{
			if(Input.GetKey (element))
			{
				// Если нажато, покидаем функцию
				return Movement;
			}
		}
		// Если кнопки не нажаты, то не двигаемся
		return Vector3.zero;
	} 














	/*public Ray ray;
	public RaycastHit hit;

	void Update () {
		Debug.Log("___000___");
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit, 100f)) {
			if(hit.collider.gameObject.tag == "Test") {
				gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
				Debug.Log("___001___");
			}
		}
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Ground" || gameObject.transform.rotation != Quaternion.Euler(270, -50, 0)) {
			StartCoroutine(Wait(5.0f));
			Debug.Log("___002___");
		}
	}
	private IEnumerator Wait(float seconds) {
		yield return new WaitForSeconds(Random.Range(4.0f, 6.0f));
		gameObject.transform.rotation = Quaternion.Euler(270, -50, 0);
		Debug.Log("___003___");
	}*/
}
