using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatDistance : SingletonBase<CalculatDistance>
{
    [SerializeField] private int distance;
    public int Distance => distance;
    [SerializeField] private Ball ball;
    [SerializeField] private Text txtDistance;
    public void FixedUpdate()
    {
        TraveledDistance();
    }
    public void TraveledDistance()
    {
        distance = (int)(ball.transform.position.z/2);
        PlayerPrefs.SetInt("Distance", distance);
        txtDistance.text = $"Distance: {distance}m";
    }
}
