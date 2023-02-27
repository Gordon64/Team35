using UnityEngine;
using System.Collections;

public class KillDamageText : MonoBehaviour
{

	[SerializeField]
	private float destroyTime;

	//Destroys damage text, starts next turn (could be moved somewhere else)
	void Start()
	{
		Destroy(this.gameObject, this.destroyTime);
	}

	void OnDestroy()
	{

	}
}