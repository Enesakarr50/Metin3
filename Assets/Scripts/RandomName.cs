using System.Collections.Generic;
using UnityEngine;

public class UniqueRandomizer : MonoBehaviour
{
    // Bu liste, unique deðerleri saklamak için kullanýlýr.
    private List<int> uniqueValues;

    void Start()
    {
        // Listeyi baþlat ve deðerleri ekle.
        InitializeUniqueValues(1); // 10 adet unique deðer oluþturur.

        // Unique deðerleri karýþtýr ve yeni bir diziye ata.
        List<int> randomizedValues = GetUniqueRandomizedValues();

        // Randomize edilmiþ deðerleri konsola yazdýr.
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

        // Deðerleri karýþtýrmak için Fisher-Yates algoritmasýný kullan.
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