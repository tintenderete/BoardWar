using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Item
{
	[XmlAttribute("name")]
	public string name;

	[XmlElement("Power")]
	public float power;

	[XmlElement("Range")]
	public int range;

	[XmlElement("Cost")]
	public int cost;

}
