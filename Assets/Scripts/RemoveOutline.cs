using UnityEngine;

[RequireComponent(typeof(Outline))]
public class RemoveOutline : MonoBehaviour
{
	private Outline outline;
	void Start()
	{
		outline = gameObject.GetComponent<Outline>();
	}
    // Update is called once per frame
    void Update()
    {
		if (outline.enabled == true)
		{
			outline.enabled = false;
		}
    }
}
