using UnityEngine;
using System.Collections.Generic;

public class clickToObject : MonoBehaviour {

	public List<KeyCode> upButton = new List<KeyCode> { KeyCode.UpArrow };
	public List<KeyCode> downButton = new List<KeyCode> { KeyCode.DownArrow };

	public List<KeyCode> leftButton = new List<KeyCode> { KeyCode.W };
	public List<KeyCode> rightButton = new List<KeyCode> { KeyCode.S };
	public List<KeyCode> backButton = new List<KeyCode> { KeyCode.A };
	public List<KeyCode> forwardButton = new List<KeyCode> { KeyCode.D };

	public List<KeyCode> restartButton = new List<KeyCode> { KeyCode.Space };

	public List<KeyCode> rotate1Button = new List<KeyCode> { KeyCode.Y };
	public List<KeyCode> rotate2Button = new List<KeyCode> { KeyCode.U };
	public List<KeyCode> rotate3Button = new List<KeyCode> { KeyCode.I };

	public float playerSpeed = 5.0f;
	private float currentSpeed = 0.0f;
	private Vector3 lastMovement = new Vector3();

	void Update () {
		//Debug.Log("___000___");
		Movement();
		RotateYouOnMyDick(rotate1Button);
		//RotateYouOnMyDick(rotate2Button);
		//RotateYouOnMyDick(rotate3Button);
	}

	void RotateYouOnMyDick(List<KeyCode> keyList){
		foreach (KeyCode element in keyList){
			if(Input.GetKey (element)){
				Debug.Log(element);
				var rotationVector = transform.rotation.eulerAngles;
				rotationVector.z = 0;
				transform.rotation = Quaternion.Euler(rotationVector);
			}
		}
	}

	// Движение героя к мышке
	void Movement() {
		// Необходимое движение
		Vector3 movement = new Vector3();
		// Проверка нажатых клавиш
		movement = movement + MoveIfPressed(upButton, Vector3.up);
		movement = movement + MoveIfPressed(downButton, Vector3.down);
		movement = movement + MoveIfPressed(leftButton, Vector3.left);
		movement = movement + MoveIfPressed(rightButton, Vector3.right);
		movement = movement + MoveIfPressed(backButton, Vector3.back);
		movement = movement + MoveIfPressed(forwardButton, Vector3.forward);
		// Если нажато несколько кнопок, обрабатываем это
		movement.Normalize();
		// Проверка нажатия кнопки
		if(movement.magnitude > 0){
			// После нажатия двигаемся в этом направлении
			currentSpeed = playerSpeed;
			this.transform.Translate(movement * Time.deltaTime * playerSpeed, Space.World);
			lastMovement = movement;
		} else{
			// Если ничего не нажато
			this.transform.Translate(lastMovement * Time.deltaTime * currentSpeed, Space.World);
			// Замедление со временем
			currentSpeed *= 0.19f;
		}
	}

	// Возвращает движение, если нажата кнопка
	Vector3 MoveIfPressed(List<KeyCode> keyList, Vector3 Movement) {
		// Проверяем кнопки из списка
		foreach (KeyCode element in keyList){
			if(Input.GetKey (element)){
				// Если нажато, покидаем функцию
				Debug.Log(element);
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
