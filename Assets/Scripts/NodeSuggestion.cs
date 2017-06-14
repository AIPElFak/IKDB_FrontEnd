using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NodeSuggestion  {

	public string _id;
	public string suggestion_type;
	public string name;
	public List<string> votes_for;
	public List<string> votes_against;
	public DateTime date_created;
	public String description;
	public String definition;
	public List<string> types;
}
