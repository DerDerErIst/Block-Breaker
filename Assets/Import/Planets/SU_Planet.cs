using UnityEngine;

public class SU_Planet : MonoBehaviour {
	// Planet rotation vector specifying axis and rotational speed
	public Vector3 planetRotation;
	// Private variables
	private Transform _cacheTransform;
	
	void Start () {
		// Cache reference to transform to improve performance
		_cacheTransform = transform;	
	}
	
	void Update () {
		// Rotate the planet based on the rotational vector
		if (_cacheTransform != null) {			
			_cacheTransform.Rotate(planetRotation * Time.deltaTime);
		}
	}

}
