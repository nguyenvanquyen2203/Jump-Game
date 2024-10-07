using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    private static PointManager instance;
    public static PointManager Instance { get { return instance; } }
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI plusPointText;
    public float time;

    private float delayTime;
    private int currentPoint;
    private int pointMap;
    private int pointPlus;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Point")) currentPoint = 0;
        else Load();
        pointMap = 0;
    }
    public void UpdatePoint()
    {
        currentPoint += pointMap;
        Save();
    }
    public void CollectPoint(int point)
    {
        pointPlus = point;
        plusPointText.text = "+" + pointPlus.ToString();
        delayTime = time / pointPlus;
        Invoke(nameof(ChangePoint), time);
    } 
    private void Save() => PlayerPrefs.SetInt("Point", currentPoint);
    private void Load() => currentPoint = PlayerPrefs.GetInt("Point");
    private void ChangePoint()
    {
        pointMap++;
        pointText.text = pointMap.ToString();
        pointPlus--;
        plusPointText.text = "+" + pointPlus.ToString();
        if (pointPlus > 0) Invoke(nameof(ChangePoint), delayTime);
        else plusPointText.text = "";
    }
}
