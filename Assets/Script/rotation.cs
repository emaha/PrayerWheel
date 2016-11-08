using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {
	
	private float startPosition;
	private float nowPosition;
	private float len, lastlen;
	public float counter;
	public float speed;


	void Start () 
	{
	}

	void OnGUI()
	{

		GUI.Box(new Rect(Screen.width/2-60, 10,120,25), "Counter: " + counter.ToString("f1"));

	}

	void Update () 
	{
		counter += Mathf.Abs (speed) * Time.deltaTime * 0.0026f;

		if (len - lastlen < 0) 
		{
			if(GameObject.Find("MainCamera").transform.position.z>-12)
				GameObject.Find("MainCamera").transform.Translate(new Vector3(0f,0f,-0.01f));
		}
		
		if (len - lastlen > 0) 
		{
			if(GameObject.Find("MainCamera").transform.position.z<-10)
				GameObject.Find("MainCamera").transform.Translate(new Vector3(0f,0f,0.01f));
		}
			
			lastlen = len;
		
		
		switch (Input.touchCount)
		{
		case 1:
			//Действия, если нажат один палец.
			//К одному пальцу обращаться через Input.GetTouch(0);
			break;
		case 2:
			//Действия, если нажато два пальца.
			//К первому пальцу обращаться через Input.GetTouch(0);
			//К второму пальцу обращаться через Input.GetTouch(1);
			//Например:
			len = (Input.GetTouch(0).position - Input.GetTouch(1).position).magnitude;
			//Возвращает расстояние между двумя пальцами
			break;
		}



		gameObject.transform.Rotate (Vector3.up, speed * Time.deltaTime);

		speed *= 0.999f;
		if (Input.GetKey(KeyCode.Escape)) { Application.Quit(); } 
	}

	void OnMouseUp () 
	{      
		nowPosition= Input.mousePosition.x;
		speed = startPosition - nowPosition;
	} 

	void OnMouseDown()
	{
		startPosition= Input.mousePosition.x;
	}
}