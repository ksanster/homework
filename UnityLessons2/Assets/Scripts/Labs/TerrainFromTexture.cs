using UnityEngine;

namespace Labs
{
public class TerrainFromTexture : MonoBehaviour
{
    [SerializeField] private Texture2D[] terrainTextures;
    [SerializeField] private Texture2D[] terrainNormalMaps;
	[SerializeField] private int depth = 30;
	[SerializeField] private Vector3 position = new Vector3(-500f, -50f, -250f);
	[SerializeField] private int width = 1024;
	[SerializeField] private int height = 1024;
	[SerializeField] private Texture2D raw;

	private void Start()
	{
		var terrain = Terrain.CreateTerrainGameObject(GenerationTerrain()).GetComponent<Terrain>();
		GenerationAlphamaps(terrain);
		
		terrain.transform.position = position;
	}

	private TerrainData GenerationTerrain()
	{
		var result = new TerrainData
		{
			heightmapResolution = width + 1,
			size = new Vector3(width, depth, height),
		};

		result.SetHeights(0,0, GenerationHeights());
		result.terrainLayers = GenerateLayers();
		
		return result;
	}


	private float[,] GenerationHeights()
	{
		float[,] heights = new float[width,height];

		for (var i = 0; i < width; i++)
		{
			for (var j = 0; j < height; j++)
			{
				heights[i, j] = CalculateHeight(i, j);
			}
		}

		return heights;
	}

	private float CalculateHeight(int i, int j)
	{
		float xCoord = (float)i / width * raw.width;
		float yCoord = (float)j / height * raw.height;
		var color = raw.GetPixel(Mathf.RoundToInt(xCoord), Mathf.RoundToInt(yCoord));

		return color.r;
	}

	private TerrainLayer[] GenerateLayers()
	{
		if (terrainTextures == null) return null;
		
		var result = new TerrainLayer[terrainTextures.Length];
		for (var i = 0; i < terrainTextures.Length; i++)
		{
			var layer = new TerrainLayer
			{
				diffuseTexture = terrainTextures[i], 
				normalMapTexture = terrainNormalMaps[i],
				tileSize = new Vector2(500, 500)
			};
			result[i] = layer;
		}
		return result;
	}

	private void GenerationAlphamaps(Terrain t)
	{
		var map = new float[t.terrainData.alphamapWidth, t.terrainData.alphamapHeight, 2];
		
		for (var y = 0; y < t.terrainData.alphamapHeight; y++)
		{
			for (var x = 0; x < t.terrainData.alphamapWidth; x++)
			{
				var normX = x * 1.0 / (t.terrainData.alphamapWidth - 1);
				var normY = y * 1.0 / (t.terrainData.alphamapHeight - 1);
				
				var angle = t.terrainData.GetSteepness((float)normX, (float)normY);
				
				var frac = angle / 90.0;
				map[x, y, 0] = (float)frac;
				map[x, y, 1] = 1 - (float)frac;
			}
		}

		t.terrainData.SetAlphamaps(0, 0, map);
	}
}
	

}
