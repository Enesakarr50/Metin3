using System.Collections.Generic;
using UnityEngine;

public class UniqueRandomizer : MonoBehaviour
{
    // Bu liste, unique de�erleri saklamak i�in kullan�l�r.
    private List<int> uniqueValues;

    void Start()
    {
        // Listeyi ba�lat ve de�erleri ekle.
        InitializeUniqueValues(1); // 10 adet unique de�er olu�turur.

        // Unique de�erleri kar��t�r ve yeni bir diziye ata.
        List<int> randomizedValues = GetUniqueRandomizedValues();

        // Randomize edilmi� de�erleri konsola yazd�r.
        foreach (int value in randomizedValues)
        {
            Debug.Log(value);
        }
    }

    void InitializeUniqueValues(int count)
    {
        uniqueValues = new List<int>();

        for (int i = 0; i < count; i++)
        {
            uniqueValues.Add(i);
        }
    }

    List<int> GetUniqueRandomizedValues()
    {
        List<int> randomizedValues = new List<int>(uniqueValues);

        // De�erleri kar��t�rmak i�in Fisher-Yates algoritmas�n� kullan.
        int n = randomizedValues.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = randomizedValues[i];
            randomizedValues[i] = randomizedValues[j];
            randomizedValues[j] = temp;
        }

        return randomizedValues;
    }
}