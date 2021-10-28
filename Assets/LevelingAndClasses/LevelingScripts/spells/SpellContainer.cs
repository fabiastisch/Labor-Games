using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
// [XmlRoot("SpellCollection")]
public class SpellContainer
{
  // [XmlArray("Spells")]
  // [XmlArrayItem("Spell")]
  // public List<Spell> spells = new List<Spell>();
  //
  // public static SpellContainer Load(string path)
  // {
  //   TextAsset _xml = Resources.Load<TextAsset>(path);
  //   
  //   XmlSerializer serializer = new XmlSerializer(typeof(SpellContainer));
  //   
  //   StringReader reader = new StringReader(_xml.text);
  //   
  //   SpellContainer spells = serializer.Deserialize(reader) as SpellContainer;
  //   
  //   reader.Close();
  //   
  //   return spells;
  //}
}
