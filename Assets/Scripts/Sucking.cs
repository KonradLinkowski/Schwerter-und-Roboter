using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucking : MonoBehaviour {

	public string lootTag;
	void OnTriggerStay(Collider col) {
		if (col.CompareTag(lootTag)) {
			col.transform.position = Vector3.Lerp(col.transform.position, transform.position, Time.deltaTime * 5);
			if (Vector3.Distance(transform.position, col.transform.position) < 1) {
				Destroy(col.gameObject);
			}
		}
	}
}
