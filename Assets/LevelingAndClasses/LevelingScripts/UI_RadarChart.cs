using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class UI_RadarChart : MonoBehaviour
{
  [SerializeField] private Material radarMaterial;
  [SerializeField] private Texture2D radarTexture2D;
  public Statistics statistics;
  private CanvasRenderer radarMeshCanvasRenderer;

  private void Awake()
  {
    radarMeshCanvasRenderer = transform.Find("radarMesh").GetComponent<CanvasRenderer>();
  }

  public void SetStatistic(Statistics statistics)
  {
    this.statistics = statistics;
    statistics.OnStatisticChange += Statistics_OnStatisticChange;
    UpdateStatsVisual();
    UpdateStatsText();
  }
  private void Statistics_OnStatisticChange(object sender, System.EventArgs e)
  {
    UpdateStatsVisual();
    UpdateStatsText();
  }

  private void UpdateStatsVisual()
  {
    Mesh mesh = new Mesh();

    Vector3[] vertices = new Vector3[6];
    Vector2[] uv = new Vector2[6];
    int[] triangles = new int[3 * 5];

    float angleIncrement = 360f / 5;
    float RadarChartSize = 90f;
    Vector3 vitallityVertex = Quaternion.Euler(0, 0, -angleIncrement * 0) * Vector3.up * RadarChartSize * statistics.GetPersentageAmount(Statistics.Type.Vitallity);
    int vitallityVertexIndex = 1;
    Vector3 abillityVertex = Quaternion.Euler(0, 0, -angleIncrement * 1) * Vector3.up * RadarChartSize * statistics.GetPersentageAmount(Statistics.Type.Abillity);
    int abillityVertexIndex = 2;
    Vector3 charismaVertex = Quaternion.Euler(0, 0, -angleIncrement * 2) * Vector3.up * RadarChartSize * statistics.GetPersentageAmount(Statistics.Type.Charisma);
    int charismaVertexIndex = 3;
    Vector3 agillityVertex = Quaternion.Euler(0, 0, -angleIncrement * 3) * Vector3.up * RadarChartSize * statistics.GetPersentageAmount(Statistics.Type.Agillity);
    int agillityVertexIndex = 4;
    Vector3 strengthVertex = Quaternion.Euler(0, 0, -angleIncrement * 4) * Vector3.up * RadarChartSize * statistics.GetPersentageAmount(Statistics.Type.Strength);
    int strengthVertexIndex = 5;
    
    vertices[0] = Vector3.zero;
    vertices[vitallityVertexIndex] = vitallityVertex;
    vertices[abillityVertexIndex] = abillityVertex;
    vertices[charismaVertexIndex] = charismaVertex;
    vertices[agillityVertexIndex] = agillityVertex;
    vertices[strengthVertexIndex] = strengthVertex;
    
    uv[0] = Vector2.zero;
    uv[vitallityVertexIndex] = Vector2.one;
    uv[abillityVertexIndex] = Vector2.one;
    uv[charismaVertexIndex] = Vector2.one;
    uv[agillityVertexIndex] = Vector2.one;
    uv[strengthVertexIndex] = Vector2.one;

    triangles[0] = 0;
    triangles[1] = vitallityVertexIndex;
    triangles[2] = abillityVertexIndex;
    
    triangles[3] = 0;
    triangles[4] = abillityVertexIndex;
    triangles[5] = charismaVertexIndex;
    
    triangles[6] = 0;
    triangles[7] = charismaVertexIndex;
    triangles[8] = agillityVertexIndex;
    
    triangles[9] = 0;
    triangles[10] = agillityVertexIndex;
    triangles[11] = strengthVertexIndex;
    
    triangles[12] = 0;
    triangles[13] = strengthVertexIndex;
    triangles[14] = vitallityVertexIndex;

    mesh.vertices = vertices;
    mesh.uv = uv;
    mesh.triangles = triangles;
    radarMeshCanvasRenderer.SetMesh(mesh);
    radarMeshCanvasRenderer.SetMaterial(radarMaterial, radarTexture2D);
  }

  private void UpdateStatsText()
  {
    var parent = transform.parent;
    
    parent.Find("LevelVit").Find("Value").GetComponent<Text>().text =
      "" + statistics.GetValue(Statistics.Type.Vitallity);
    
    parent.Find("LevelAbi").Find("Value").GetComponent<Text>().text =
      "" + statistics.GetValue(Statistics.Type.Abillity);
    
    parent.Find("LevelAgi").Find("Value").GetComponent<Text>().text =
      "" + statistics.GetValue(Statistics.Type.Agillity);
    
    parent.Find("LevelCha").Find("Value").GetComponent<Text>().text =
      "" + statistics.GetValue(Statistics.Type.Charisma);
    
    parent.Find("LevelStr").Find("Value").GetComponent<Text>().text =
      "" + statistics.GetValue(Statistics.Type.Strength);
  }
}
