using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _decriseValue = 2;

    public void Create(Cube prefab)
    {
        int minValueCreateRandom = 2;
        int maxValueCreateRandom = 6;
        int countCreating;

        System.Random random = new System.Random();
        countCreating = random.Next(minValueCreateRandom, maxValueCreateRandom + 1);

        for (int i = 0; i < countCreating; i++)
        {
            Vector3 position = transform.position;
            Cube newCube = Instantiate(prefab, position, Quaternion.identity);

            var color = Random.ColorHSV();
            var chanceDivide = newCube.ChanceDivision / _decriseValue;
            var scale = transform.localScale / _decriseValue;

            newCube.Init(color, chanceDivide, scale);
        }
    }
}
