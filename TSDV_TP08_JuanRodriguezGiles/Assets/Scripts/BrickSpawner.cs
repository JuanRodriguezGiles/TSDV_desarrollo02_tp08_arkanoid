using UnityEngine;
public class BrickSpawner : MonoBehaviour
{
    public GameObject BrickGameObject;
    void Start()
    {
        const int rows = 5;
        const int columns = 10;
        float offsetX = 2.5f;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 positionVector3 = new Vector3(j * offsetX, i, 0);
                Instantiate(BrickGameObject, positionVector3, Quaternion.identity);
            }
        }
    }
}
