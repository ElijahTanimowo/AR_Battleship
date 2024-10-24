using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class GridCreator : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab
    public int gridSize = 10; // 10x10 grid
    public float spacing = 2.0f; // space between cubes
    public bool regenerateGrid = false; // Set this to true in Inspector to regenerate grid

    private Transform gridParent; // Reference to the parent object

    private void OnValidate()
    {
        // Ensure the grid is only created if we're in Edit Mode
        if (!Application.isPlaying && regenerateGrid)
        {
            CreateOrFindGridParent(); // Create or find the parent object
            ClearGrid(); // Clear the existing grid
            CreateGrid(); // Generate the new grid
            regenerateGrid = false; // Reset the regenerate flag
        }
    }

    private void Start()
    {

    }

    // Create or find the parent object named "Grid"
    void CreateOrFindGridParent()
    {
        gridParent = transform.Find("Grid");

        // If "Grid" doesn't exist, create a new one
        if (gridParent == null)
        {
            GameObject gridObject = new GameObject("Grid");
            gridParent = gridObject.transform;

            // Parent the "Grid" to the GameObject holding this script for organization
            gridParent.parent = this.transform;
        }
    }

    void CreateGrid()
    {
        if (cubePrefab == null)
        {
            Debug.LogError("Cube prefab is not assigned!");
            return;
        }

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                // Instantiate
                Vector3 position = new Vector3(x * spacing, 0, z * spacing);

#if UNITY_EDITOR
                //Instantiate for edit mode
                GameObject cube = (GameObject)PrefabUtility.InstantiatePrefab(cubePrefab, gridParent);
#else
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);

#endif

                if (cube != null)
                {
                    cube.transform.position = position;

                    char rowLetter = (char)(65 + x); // 65 = 'A'
                    int columnNumber = z + 1;
                    cube.name = rowLetter.ToString() + columnNumber.ToString();

                    // Parent the cubes
                    cube.transform.parent = gridParent;
                }
            }
        }
    }

    void ClearGrid()
    {
        // Destroy all children under the "Grid" parent object
        if (gridParent != null)
        {
            for (int i = gridParent.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(gridParent.GetChild(i).gameObject);
            }
        }
    }
}
