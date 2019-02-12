using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public int mapWidth;
    public int mapHight;
    public float noiseScale;

    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    // generate map
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }

    // clamp all the values
    public void OnValidate()
    {
        if (mapWidth < 1)
            mapWidth = 1;

        if (mapHight < 1)
            mapHight = 1;

        if (lacunarity < 1)
            lacunarity = 1;

        if (octaves < 0)
            octaves = 0;
    }
}
