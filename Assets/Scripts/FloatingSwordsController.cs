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
    [SerializeField, Range(0, 360)]
    private float Circumference;
    [SerializeField, Range(0, 360)]
    private float StartingAngle;
    
    

    // Start is called before the first frame update
    void Start()
    {
        float currentAngle = StartingAngle;
        float radians;
        Vector3 position;
        Vector3 rotation;
        GameObject go;
        for (int i = 0; i < SwordsQuantity; i++)
        {
            currentAngle += Circumference / SwordsQuantity;
            radians = currentAngle * Mathf.Deg2Rad;

            position = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians)) * Radius;
            go = Instantiate(SwordPrefab);
            go.transform.SetParent(Container);
            go.transform.position = Container.position + position;
            go.transform.localScale = Vector3.one * 3;

            //go.transform.rotation = Quaternion.Euler()
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
