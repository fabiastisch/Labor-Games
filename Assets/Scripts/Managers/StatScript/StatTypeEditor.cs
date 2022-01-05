using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace Managers.StatScript
{
    #if UNITY_EDITOR
    [CustomEditor(typeof(StatTypeSO))]
    public class StatTypeEditor: Editor
    {
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            if(GUILayout.Button("Recreate Enum"))
            {
                Go();
            }
        }
        
        [MenuItem( "Tools/GenerateStatTypeEnum" )]
        public static void Go()
        {
            string enumName = "StatType";
            
            StatTypeListSO so = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);

            List<string> set = new List<string>();
            foreach (var statTypeSo in so.list)
            {
                set.Add(statTypeSo.nameString);
            }
            
            string filePathAndName = "Assets/Scripts/Managers/StatScript/" + enumName + ".cs"; //The folder Scripts/Enums/ is expected to exist
 
            using ( StreamWriter streamWriter = new StreamWriter( filePathAndName ) )
            {
                streamWriter.WriteLine( "public enum " + enumName );
                streamWriter.WriteLine( "{" );
                foreach (string s in set)
                {
                    streamWriter.WriteLine( "\t" + s + "," );
                }
                streamWriter.WriteLine( "}" );
            }
            AssetDatabase.Refresh();
        }

        
    }
    #endif
}