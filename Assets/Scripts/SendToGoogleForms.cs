using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Networking;

public class SendToGoogleForms : MonoBehaviour
{
    public string LOGS_BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeQtk2XauJQNdks5XLXn6NfEFGfx4wTNCKF3Yc-dJhsBVAZ0Q/formResponse";
    //"https://docs.google.com/forms/u/0/d/1nZ_7AuqUWoZZJtxWeWpxlKk7IgrK_uuvSjWf_XaBLWs/prefill";
    //   https://docs.google.com/forms/d/1nZ_7AuqUWoZZJtxWeWpxlKk7IgrK_uuvSjWf_XaBLWs/prefill


    public string SURVEY_BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSeQtk2XauJQNdks5XLXn6NfEFGfx4wTNCKF3Yc-dJhsBVAZ0Q/viewform";


    Dictionary<string,string> FormFields = new Dictionary<string,string> (){
        { "participant_id", "entry.461554145" },
        { "condition", "entry.594648843" },
        { "score", "entry.1737089575" },
    };

    public string QueryString(Dictionary<string,string>data)
	{
        NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
        foreach(var key in data.Keys) {
            queryString.Add(FormFields[key],data[key]);
        }

        return queryString.ToString();
    }
    


    IEnumerator Post(Dictionary<string,string> data) {
        //      WWWForm form = new WWWForm();
        //      foreach(var key in data.Keys) {
        //          print($"{key}, {data[key]}");
        //          form.AddField(key,data[key]);
        //          if(data[key].GetType()==typeof(string)) {
        //              form.AddField(key,(string)data[key]);
        //	} else {
        //              form.AddField(key,(int)data[key]);
        //          }
        //}
        //WWW www = new WWW(BASE_URL,form.data);



        string query = QueryString(data);
        print(query);
        WWW www = new WWW($"{LOGS_BASE_URL}?{query}");

        
        print(www.url);
        yield return www;
        print("request finished");

        //print(form.ToString());



        //      using(UnityWebRequest www = UnityWebRequest.Post(BASE_URL, query)) {

        //          print(www.url);
        //          print(www.uri);
        //          yield return www.SendWebRequest();

        //	if(www.result != UnityWebRequest.Result.Success) {
        //		Debug.Log(www.error);
        //	} else {
        //		Debug.Log("Form upload complete!");
        //	}
        //}
    }


    public void SendLog(Dictionary<string,string> data)
	{
        StartCoroutine(Post(data));
	}


    public void OpenSurvey(Dictionary<string,string> data)
	{

        string query = QueryString(data);
        print(query);
        string url = $"{SURVEY_BASE_URL}?{query}";


        Application.OpenURL(url);
    }
    
}
