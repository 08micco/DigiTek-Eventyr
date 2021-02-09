using UnityEngine;
using System.Collections;

public class FogScript : MonoBehaviour {

	// Use this for initialization
	
	public float scale = 0.6f;
	public float intensity = 0.8f;
	public float alpha = 0.45f;
	public float alphasub = 0.05f;
	public float pow = 1.2f;
	public Color color = new Color(1f, 0.95f, 0.9f, 1.0f);
	public Material fogMaterial;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 playerpos = new Vector3(GameObject.Find("Player").transform.position.x - 4f, GameObject.Find("Player").transform.position.y,GameObject.Find("Player").transform.position.z );
		gameObject.transform.position = playerpos;
	}		
}
