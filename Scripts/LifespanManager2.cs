using UnityEngine;
using System.Collections;

// manage the lifespan of a game object
public class LifespanManager : MonoBehaviour {

	[SerializeField] private float lifespan = 5.0f;
	[SerializeField] private bool destroy;
	[SerializeField] private bool detachChildren = false;

	private bool _enabled;

	private void Update() {
		if (!_enabled && gameObject.activeInHierarchy) {
			_enabled = true;
			Invoke(nameof(Suicide), lifespan);
		}
	}

	private void Suicide() {
		if (detachChildren) {
			transform.DetachChildren();
		}

		if (destroy) {
			Destroy(gameObject);
		}
		else {
			gameObject.SetActive(false);
			_enabled = false;
		}
	}
}
