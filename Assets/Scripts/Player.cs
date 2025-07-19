using UnityEngine;

public class Player : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			Debug.Log("Pressing key: W");
		}
		else
		{
			Debug.Log("Pressing nothing.");
		}
	}
}