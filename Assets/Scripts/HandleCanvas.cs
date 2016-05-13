using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandleCanvas : MonoBehaviour {

	private CanvasScaler scaler;
	///<summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
		scaler = GetComponent<CanvasScaler> ();

		scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
	}
}
