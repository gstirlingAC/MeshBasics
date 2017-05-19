using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))] // we need to give it a mesh filter and mesh renderer
public class Grid : MonoBehaviour {

    // The grid will consist of square tiles - quads - of unit length.
    // We need to give this grid a horizontal and vertical size.
    [SerializeField] private int xSize, ySize; // we serialize these fields to make them visible in the Unity inspector.
    private Vector3[] vertices; // we will use an array to store the vertices.

    private void Awake () {
        // initialise the variables
        xSize = 10;
        ySize = 5;

        // Call a function to generate the grid
        Generate();
	}

    private void Generate()
    {
        // The amount of vertices depends on the size of the grid.
        // We need a vertex at the corners of every quad, but
        // adjacent quads share the same vertex. So we need one more
        // vertex than we have tiles in each dimension.
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];

        // We use a double loop to position the vertices
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
            }
        }

    }

    private void OnDrawGizmos()
    {
        // In the absence of any graphics we will visualize these vertices, 
        // so we can check that we position them correctly, using the
        // OnDrawGizmos method. 
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            // check whether the array exists and 
            // jump out of the method if it isn't.
            if (vertices == null)
            {
                return;
            }

            Gizmos.DrawSphere(vertices[i], 0.1f); // This will draw a small black sphere in the scene view for every vertex.
        }
    }

}
