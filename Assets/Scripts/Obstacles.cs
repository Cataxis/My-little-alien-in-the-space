using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public List<GameObject> obstacles;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] float levelIncreaseInterval;
    [SerializeField] float levelIncreaseAmount;
    [SerializeField] AnimationCurve spawnProbabilityCurve; // Nueva propiedad

    float spawnTime;
    float levelIncreaseTime;

    private void Start()
    {
        spawnTime = Time.time + timeBetweenSpawn;
        levelIncreaseTime = Time.time + levelIncreaseInterval;
    }

    private void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }

        if (Time.time > levelIncreaseTime)
        {
            IncreaseLevel();
            levelIncreaseTime = Time.time + levelIncreaseInterval;
        }
    }

    void Spawn()
    {
        if (obstacles.Count == 0)
        {
            Debug.LogWarning("No hay objetos de obstáculos configurados.");
            return;
        }

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, 0);
        Quaternion spawnRotation = transform.rotation;
        GameObject obstacleToSpawn = GetRandomObstacle();
        Instantiate(obstacleToSpawn, spawnPosition, spawnRotation);
    }

    GameObject GetRandomObstacle()
    {
        float[] probabilities = new float[obstacles.Count];

        // Calcula las probabilidades basadas en la curva
        for (int i = 0; i < obstacles.Count; i++)
        {
            float t = (float)i / (float)(obstacles.Count - 1); // Normaliza el índice
            probabilities[i] = spawnProbabilityCurve.Evaluate(t);
        }

        // Elige un obstáculo aleatorio basado en las probabilidades
        int index = GetRandomWeightedIndex(probabilities);
        return obstacles[index];
    }

    int GetRandomWeightedIndex(float[] probabilities)
    {
        // Suma todas las probabilidades
        float sum = 0f;
        for (int i = 0; i < probabilities.Length; i++)
        {
            sum += probabilities[i];
        }

        // Genera un número aleatorio en el rango de la suma total
        float randomValue = Random.value * sum;

        // Elige el índice correspondiente al número aleatorio generado
        float tempSum = 0f;
        for (int i = 0; i < probabilities.Length; i++)
        {
            tempSum += probabilities[i];
            if (randomValue <= tempSum)
            {
                return i;
            }
        }

        // Esto nunca debería ocurrir, pero en caso de error, devuelve el último índice
        return probabilities.Length - 1;
    }

    void IncreaseLevel()
    {
        timeBetweenSpawn -= levelIncreaseAmount;

        if (timeBetweenSpawn <= 0)
        {
            timeBetweenSpawn = 0.1f; // Valor mínimo para evitar spawns excesivamente rápidos
        }
    }
}
