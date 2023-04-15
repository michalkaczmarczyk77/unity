using System.Collections.Generic;
using UnityEngine;

public static class MyToolbox
{
    public struct CirclePoint
    {
        public Vector2 position { set; get; }
        public float angle { set; get; }
    }

    /*
        * @Parameters:
        *  points - ilość punktów, które mają być wygenerowane na okręgu
        *  radius - promień okręgu na którym mają być wygenerowane punkty
        *  center - wszpółrzędne środka okręgu
        */
    public static List<CirclePoint> GenerateCirclePoints(int points, float radius, Vector3 center)
    {
        // Lista wygenerowanych punktów
        List<CirclePoint> pointsList = new List<CirclePoint>();
        // Wyliczanie przesunięcia kątowego względem poszczególnych punktów
        float anglePivot = 360 / points;
        // Losowanie kąta pierwszego/bazowego punktu. Dzielenie przez 10, żeby zmniejszyć granulację - np. zamiast 90 losowanych elementów mamy 9
        float initialAngle = UnityEngine.Random.Range(0, Mathf.Round(anglePivot / 10)) * 10;

        CirclePoint _point = new CirclePoint();
        float _angle;
        Vector2 _position;

        /* 
            * Generowanie listy punktów przesuniętych względem siebie o anglePivot 
            * Funkcje Mathf.Sin & Mathf.Cos jako parametr przyjmują wartości wyrażone w Radianach. Dlatego należy użyć konwersji (współczynnika) Mathf.Deg2Rad
            * Zgodnie z definicją współczynnik jest stała i wynosi: (PI*2)/360
        */
        for (int i = 0; i <= points - 1; i++)
        {
            _angle = (initialAngle + i * anglePivot);

            _position = new Vector2();
            _position.x = Mathf.Cos(_angle * Mathf.Deg2Rad) * radius + center.x;
            _position.y = Mathf.Sin(_angle * Mathf.Deg2Rad) * radius + center.y;

            _point = new CirclePoint { position = _position, angle = _angle };

            pointsList.Add(_point);
        }

        return pointsList;
    }

    /*
        * @Parameters:
        *  points - ilość punktów, które mają być wygenerowane na okręgu
        *  radius - promień okręgu na którym mają być wygenerowane punkty
        *  center - wszpółrzędne środka okręgu
        */
    public static List<Vector2> GeneratePoints(int points, float radius, Vector3 center)
    {
        Vector2 point;
        List<Vector2> pointsList = new List<Vector2>();

        // Wyliczanie przesunięcia kątowego względem poszczególnych punktów
        float anglePivot = 360 / points;
        // Losowanie kąta pierwszego/bazowego punktu
        float angle = UnityEngine.Random.Range(0, anglePivot);
        // Lista wygenerowanych punktów

        /* 
            * Generowanie listy punktów przesuniętych względem siebie o anglePivot 
            * Funkcje Mathf.Sin & Mathf.Cos jako parametr przyjmują wartości wyrażone w Radianach. Dlatego należy użyć konwersji (współczynnika) Mathf.Deg2Rad
            * Zgodnie z definicją współczynnik jest stała i wynosi: (PI*2)/360
        */
        for (int i = 0; i <= points - 1; i++)
        {
            point = new Vector2(0, 0);
            point.Set(
                        Mathf.Cos((angle + i * anglePivot) * Mathf.Deg2Rad) * radius + center.x
                    , Mathf.Sin((angle + i * anglePivot) * Mathf.Deg2Rad) * radius + center.y
            );
            pointsList.Add(point);
        }

        return pointsList;
    }

}
