using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem.DinamicGrid
{
	public class GridEditor : MonoBehaviour {

		private int counter = 0;
		public GameObject gridThatStoresTheItems;
		public Text itemPrefab;

		// Use this for initialization
		void Start () {
	
		}
	
		// Update is called once per frame
		void Update () {
	    
		}

		public void AddItemToGrid()
		{
			counter++;
			var newText = Instantiate(itemPrefab) as Text;
			//newText.text = string.Format("Item {0}", counter.ToString());
			newText.transform.parent = gridThatStoresTheItems.transform;
		}
	}
}
