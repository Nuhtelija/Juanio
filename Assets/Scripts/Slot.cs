using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler {
	
	public GameObject Door;
	public Transform firePoint;
	public GameObject vodkaitem;


	private Stack<Item> items;

	public Text stackTxt;

	public Sprite slotEmpty;
	public Sprite slotHighlight;
	/// <summary>
	///check if the slot is empty, if count is 0 slot is empty and item can be added
	/// </summary>
	public bool IsEmpty{
		get { return items.Count == 0; }
	}

	public bool IsAvailable{
		get{ return CurrentItem.maxSize > items.Count;}
	}

	public Item CurrentItem{
		get{ return items.Peek ();}
	}
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
		items = new Stack<Item> ();
		RectTransform slotRect = GetComponent<RectTransform> ();
		RectTransform txtRect = stackTxt.GetComponent<RectTransform> ();
		/// <summary>
		///Scaling txt so it has 60% of the size
		/// </summary>
		int txtScleFactor = (int)(slotRect.sizeDelta.x * 0.60);
		/// <summary>
		//setting txt min/max size
		/// </summary>
		stackTxt.resizeTextMaxSize = txtScleFactor;
		stackTxt.resizeTextMinSize = txtScleFactor;

		txtRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);
		txtRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
	
		firePoint = GameObject.Find ("FirePoint").transform;

	}
	
	/// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	///Adding item to slot and writing the number of stacks to stacktext
	///</summary>
	public void AddItem(Item item){
		items.Push (item);

		if (items.Count > 1) {
			stackTxt.text = items.Count.ToString ();
		}
		/// <summary>
		///change the sprite to itemsprite what was just added
		///</summary>
		ChangeSprite (item.spriteNeutral, item.spriteHighlighted);
	}
	///<summary>
	///change slot sprites
	///</summary>
	private void ChangeSprite(Sprite neutral, Sprite highlight){
		GetComponent<Image> ().sprite = neutral;

		SpriteState st = new SpriteState ();

		st.highlightedSprite = highlight;
		st.pressedSprite = neutral;

		GetComponent<Button> ().spriteState = st;
	}
	private void UseItem(){
		if (!IsEmpty) {
			/// <summary>
			///Uses the top item of stack and remov's it
			/// </summary>
			items.Pop ().Use ();
			///<summary>
			///Update txt
			/// </summary>
			stackTxt.text = items.Count > 1 ? items.Count.ToString() : string.Empty;
			/// <summary>
			///Update sprite
			/// </summary>
			if (IsEmpty) {
				ChangeSprite (slotEmpty, slotHighlight);
				/// <summary>
				///Adds empty slot to emptyslots
				/// </summary>
				Inventory.EmptySlots++;
			}
		}
	}

	#region IPointerClickHandler implementation
/// <summary>
/// When inventory slot button is pressed item is used/deleted and used count increases. When it counts to 5 vodka is made and when you use vodka door opens/destroyed
/// </summary>
/// <param name="eventData">Event data.</param>
	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right) {
			UseItem ();
			Debug.Log (Item.used);
			if (Item.used == 5) {
				Debug.Log ("Vodka done.");
				Instantiate (vodkaitem, firePoint.position, firePoint.rotation);
			}
		}
	#endregion
}
}
