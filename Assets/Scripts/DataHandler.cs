using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHandler  {

	//server part 
	public static string serverIP = "127.0.0.1";
	private static string token;
	private static string userId;

	public static string Token {
		get {
			return token;
		}
		set {
			token = value;
		}
	}


	public static string UserId {
		get {
			return userId;
		}
		set {
			userId = value;
		}
	}

	private static string[] subjects;

	public static string[] Subjects
	{
		get {
			return subjects;
		}
		set {
			subjects = value;
		}
	
	}

	private static Node selectedNode;
	public static Node SelctedNode {
		get {
			return selectedNode;
		}
		set {
			selectedNode = value;
		}
	}
	private static NodeRelationshipDataSet selectedNrds;
	public static NodeRelationshipDataSet SelectedNrds {
		get {
			return selectedNrds;
		}
		set {
			selectedNrds = value;
		}
	}

	private static Relationship selectedRelationship;
	public static Relationship SelectedRelationship {
		get {
			return selectedRelationship;
		}
		set {
			selectedRelationship = value;
		}
	}

	private static List<Node> allNodes;
	public static List<Node> AllNodes {
		get { 
			return allNodes;
		}
		set {
			allNodes = value;
		}
	}

	private static List<LinkSuggestion> allLinkSuggestions;
	public static List<LinkSuggestion> AllLinkSuggestions {
		get { 
			return allLinkSuggestions;
		}
		set {
			allLinkSuggestions = value;
		}
	}
	private static LinkSuggestion selectedLinkSuggestion;
	public static LinkSuggestion SelectedLinkSuggestion {
		get { 
			return selectedLinkSuggestion;
		}
		set {
			selectedLinkSuggestion = value;
		}
	}
	private static List<NodeSuggestion> allNodeSuggestions;
	public static List<NodeSuggestion> AllNodeSuggestions {
		get { 
			return allNodeSuggestions;
		}
		set {
			allNodeSuggestions = value;
		}
	}
	private static NodeSuggestion selectedNodeSuggestion;
	public static NodeSuggestion SelectedNodeSuggestion {
		get { 
			return selectedNodeSuggestion;
		}
		set {
			selectedNodeSuggestion = value;
		}
	}

	public static List<string> selectedSubjects = new List<string> ();
	public static List<string> SelectedSubjects {
		get { 
			return selectedSubjects;
		}
		set { 
			selectedSubjects = value;
		}
	}

}
