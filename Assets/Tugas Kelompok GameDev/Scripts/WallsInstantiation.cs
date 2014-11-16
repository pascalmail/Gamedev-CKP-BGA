using UnityEngine;
using System.Collections;

public class WallsInstantiation : MonoBehaviour {

	public GameObject wallPrefab;
	public float gridX;
	public float gridY;
	public float initX;
	public float initY;
	public float spacingX;
	public float spacingY;

	// Use this for initialization
	void Start () {
		for (int y = (int) initY; y < gridY + initY; y++) {
			for (int x = (int) initX; x < gridX; x++) {
				Vector3 pos = new Vector3(x * spacingX, 0, y * spacingY);
				Instantiate(wallPrefab, pos, Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
