using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SelectedNodesClass  {

	private static List<Node> selectedNodes;
	public static List<Node> SelectedNodes {
		get {
			return selectedNodes;
		}
		set {
			selectedNodes=value;
		}
	}
}
