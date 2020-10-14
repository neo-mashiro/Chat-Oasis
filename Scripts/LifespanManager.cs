using UnityEngine;
using System.Collections;

// manage the lifespan of a game object
public class LifespanManager : MonoBehaviour {

	public float lifespan = 5.0f;
	public bool detachChildren = false;

	private void Awake() {
		Invoke(nameof(Suicide), lifespan);
	}

	private void Suicide() {
		if (detachChildren) {
			transform.DetachChildren();
		}

		Destroy(gameObject);
	}
}
