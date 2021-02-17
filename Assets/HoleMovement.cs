using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [Header("Hole mesh")]
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshCollider meshCollider;

    [Header("Hole vertices radius")]
    [SerializeField] Vector2 moveLimits;
    [SerializeField] float radius;
    [SerializeField] Transform holeCenter;
    [Space]
    [SerializeField] float moveSpeed;

    Mesh mesh;
    List<int> holeVectices;
    List<Vector3> offsets;
    int holeVerticesCount;

    float x, y;
    Vector3 touch, targetPos;
    void Start()
    { 
        Game.isMoving = false;
        Game.isGameOver = false;

        holeVectices = new List<int>();
        offsets = new List<Vector3>();
        mesh = meshFilter.mesh;

        FindHoleVerticies();
    }

    // Update is called once per frame
    void Update()
    {
        Game.isMoving = Input.GetMouseButton(0);

        if (!Game.isGameOver && Game.isMoving)
        {
            //move hole center
            MoveHole();
            //Update hole vertices
            UpdateHoleVerticesPosition();

        }
    }
    void MoveHole()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        touch = Vector3.Lerp(holeCenter.position,
                            holeCenter.position + new Vector3(x,0f,y),
                            moveSpeed * Time.deltaTime);
        
        targetPos = new Vector3(Mathf.Clamp(touch.x, -moveLimits.x, moveLimits.x), touch.y, Mathf.Clamp(touch.z, -moveLimits.y, moveLimits.y));


        holeCenter.position = targetPos;
    }
    void UpdateHoleVerticesPosition()
    {
        Vector3[] verticies = mesh.vertices;

        for (int i = 0; i < holeVerticesCount; i++)
        {
            verticies[holeVectices[i]] = holeCenter.position + offsets[i];
        }

        // update mesh
        mesh.vertices = verticies;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }

    void FindHoleVerticies() 
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            float distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);

            if (distance < radius)
            {
                holeVectices.Add(i);
                offsets.Add(mesh.vertices[i] - holeCenter.position);
            }
        }

        holeVerticesCount = holeVectices.Count;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(holeCenter.position, radius);
    }
}
