using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BrickManager : MonoBehaviour {

    public Vector3 target;
    public int wait;

	// Use this for initialization
	void Start () {
        target = Vector3.zero;
        StartCoroutine("MoveTarget");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // make funtion to lay out bricks

    // make coroutine to randomly trigger rotation

    // make coroutine to randomly trigger shooting

    // moves bricks in a zig-zag like fashion
    IEnumerator MoveTarget()
    {
        while (true)
        {
            target = target + 3 * Vector3.right;
            yield return new WaitForSeconds(wait);
            target = target + -3 * Vector3.up;
            yield return new WaitForSeconds(wait);
            target = target + -3 * Vector3.right;
            yield return new WaitForSeconds(wait);
            target = target + -3 * Vector3.up;
            yield return new WaitForSeconds(wait);
        }
    }     
}
