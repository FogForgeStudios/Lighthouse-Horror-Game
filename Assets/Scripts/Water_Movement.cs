using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float height = 0.1f;

    private Vector3[] originalVertices;
    private Mesh mesh;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        originalVertices = mesh.vertices;
    }

    void Update()
    {
        Vector3[] vertices = new Vector3[originalVertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = originalVertices[i];
            vertex.y += Mathf.Sin(Time.time * speed + vertex.x + vertex.z) * height;
            vertices[i] = vertex;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
