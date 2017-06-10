﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHandler  {

	//server part 
	public static string serverIP = "127.0.0.1";
	private static string token;

	public static string Token {
		get {
			return token;
		}
		set {
			token = value;
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

}
