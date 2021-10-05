using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Spell
{
   [XmlAttribute("spellId")]
   public int id;
   
   [XmlElement("SpellName")]
   public string name;
   
   [XmlElement("SpellIcon")]
   public Texture icon;
   
   [XmlElement("SpellDiscription")]
   public string description;
   
   [XmlElement("SpellRequirements")]
   public Requirements requirement;

}
