using UnityEngine;
using System.Collections;
public class SpawnObjects : MonoBehaviour
{
    public Terrain terrain; // add current terrain
    public GameObject objectToPlace; // this object will be placed on terrain
    public int numberOfObjects; // number of how many objects will be created
    public int posMin; // minimum y position
    public int posMax; // maximum x position
    public bool posMaxIsTerrainHeight; // the maximum height is the terrain height
    private int numberOfPlacedObjects; // number of the plaed objects
    private int terrainWidth; // terrain size x axis
    private int terrainLength; // terrain size z axis
    private int terrainPosX; // terrain position x axis
    private int terrainPosY; // terrain position z axis
                             // Use this for initialization
    void Start()
    {
        terrainWidth = (int)terrain.terrainData.size.x; // get terrain size x
        terrainLength = (int)terrain.terrainData.size.z; // get terrain size z
        terrainPosX = (int)terrain.transform.position.x; // get terrain position x
        terrainPosY = (int)terrain.transform.position.z; // get terrain position z
        if (posMaxIsTerrainHeight == true)
        {
            posMax = (int)terrain.terrainData.size.y;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // numberOfPlacedObjects is smaller than numberOfObjects
        if (numberOfPlacedObjects < numberOfObjects)
        {
            PlaceObject(); // call function placeObject
        }
        if (numberOfObjects == numberOfObjects)
        {
            print("Creating objects complete!");
        }
    }
    // Create objects on the terrain with random positions
    void PlaceObject()
    {
        int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth); // generate random x position
        int posz = Random.Range(terrainPosY, terrainPosY + terrainLength); // generate random z position
        float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz)); // get the terrain height at the random position
        if (posy < posMax && posy > posMin)
        {
            GameObject newObject = (GameObject)Instantiate(objectToPlace, new Vector3(posx, posy, posz), Quaternion.identity); // create object
            numberOfPlacedObjects++;
        }
        else
        {
            PlaceObject();
        }
    }
}