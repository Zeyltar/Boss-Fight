using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingSwordsController : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    private float Radius;
    [SerializeField]
    private Transform Container;
    [SerializeField]
    private GameObject SwordPrefab;
    [SerializeField]
    private int SwordsQuantity;
    [SerializeField, Range(0f, 360f)]
    private float Circumference;
    [SerializeField, Range(0f, 360f)]
    private float StartingAngle;
    [SerializeField]
    private float Scale;
    [SerializeField]
    private float RotationSpeed;

    private bool isRotating;
    private Vector3 idlePosition; 
    static private List<GameObject> list;

    // Start is called before the first frame update
    void Start()
    {
        isRotating = false;
        idlePosition = transform.position;
        list = new List<GameObject>();
        StartCoroutine(SpawnSwords());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnSwords()
    {
        float currentAngle = StartingAngle;
        float radians;
        Vector3 position;
        GameObject go;

        for (int i = 0; i < SwordsQuantity; i++)
        {
            currentAngle += Circumference / SwordsQuantity;
            radians = currentAngle * Mathf.Deg2Rad;
            position = new Vector3(Mathf.Sin(radians), 0, Mathf.Cos(radians)) * Radius;

            go = Instantiate(SwordPrefab);
            go.name = go.name + " " + i;
            go.transform.SetParent(Container);
            go.transform.position = Container.position + position;
            go.transform.localScale = Vector3.one * Scale;
            go.transform.rotation = Quaternion.Euler(0, radians * Mathf.Rad2Deg - 270, 30);

            list.Add(go);

            yield return null;
        }

        isRotating = true;
        StartCoroutine(RotateIdle());
    }

    IEnumerator RotateIdle()
    {
        while (isRotating)
        {
            Container.transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
            yield return null;
        }
    }
}
