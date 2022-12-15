using System;
using Scorm;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;
using Version = Scorm.Version;

public class ScormSettings : MonoBehaviour
{
    public IScormService scormService { get; private set; }

    public static ScormSettings Instance { get; private set; }

    private ObjectiveData objectiveData;

    private float startTime;

    
    private void Awake()
    {
        #region Persistent

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        #endregion

#if UNITY_EDITOR
        scormService = new ScormPlayerPrefsService();
#else
            scormService = new ScormService();
#endif

        bool result = scormService.Initialize(Version.Scorm_1_2);
        if (result)
        {
            scormService.SetMaxScore(1000f);
            scormService.SetMinScore(0f);
            scormService.SetRawScore(0f); // hata
            ObjectiveMaker(0, LessonStatus.NotAttempted, LessonStatus.Incomplete, 0f);
            scormService.Commit();

            Debug.Log("scorm initialized");
        }
    }

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        SessionTime();
    }

    private void SessionTime()
    {
        var sessionTime = (int)((Time.time - startTime) * 1000);
        scormService.SetSessionTime(sessionTime);
        scormService.Commit();
    }

    public void ObjectiveMaker(float rawScore, LessonStatus successStatus, LessonStatus completionStatus,
        float progressMeasure)
    {
        string id = "0";
        float minScore = 0f;
        float maxScore = 1000f;
        float scaledScore = 0;
        // LessonStatus successStatus = LessonStatus.NotAttempted;
        // LessonStatus completionStatus = LessonStatus.Incomplete;
        // float progressMeasure = 0;
        string description = "earn 500 euros";

        objectiveData = new ObjectiveData(id, minScore, maxScore, rawScore, scaledScore, successStatus,
            completionStatus, progressMeasure, description);

        scormService.SetObjective(objectiveData);
        scormService.Commit();
    }

    public void AddScore()
    {
        var score = scormService.GetRawScore() + TextResultScript.TotalGainedMoney;
        scormService.SetRawScore(score);
        scormService.Commit();
        Debug.Log(score + " scormScore");
    }
}