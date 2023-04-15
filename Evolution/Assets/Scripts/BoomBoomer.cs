using System.Collections.Generic;
using UnityEngine;
using static MyToolbox;

public class BoomBoomer : MonoBehaviour
{
    public int numberOfFiringPoints = 3;
    public float radius = 2;

    private List<CirclePoint> firingPointList;
    private List<BoomBoomer> boomers;

    // Start is called before the first frame update
    void Start()
    {
        boomers= new List<BoomBoomer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        firingPointList = MyToolbox.GenerateCirclePoints(numberOfFiringPoints, radius, transform.position);

        if (boomers.Count > 0)
        {
            foreach (BoomBoomer boomer in boomers)
            {
                boomer.doDestroy();
            }
            boomers.Clear();
        }

        foreach (var point in firingPointList)
        {
            boomers.Add((BoomBoomer)Instantiate(this, point.position, Quaternion.identity));
        }
    }

    public void doDestroy()
    {
        Destroy(gameObject);
    }

}
