using UnityEngine;

public class Spawn : MonoBehaviour
{
    private int _decriseValue = 2;
    
    public void Create(Cube prefab)
    {
        int minValueCreateRandom = 2;
        int maxValueCreateRandom = 7;
        int countCreating;

        System.Random random = new System.Random();
        countCreating = random.Next(minValueCreateRandom, maxValueCreateRandom);

        for (int i = 0; i < countCreating; i++)
        {
            Vector3 position = transform.position;
            Cube newCube = Instantiate(prefab, position, Quaternion.identity);

            var color = Random.ColorHSV();
            var chanceDivide = newCube.ChanceDivision / _decriseValue;
            var scale = transform.localScale / _decriseValue;

            newCube.Initialisation(color, chanceDivide, scale);
        }
    }
}
