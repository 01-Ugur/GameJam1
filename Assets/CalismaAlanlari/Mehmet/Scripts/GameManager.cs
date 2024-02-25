using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ public int[] intensity;
public GameObject[] colorBars;
public GameObject[] colorTexts;
public GameObject panel;
float maxIntensity=100.0f;

private void Start() {
    
}
public void OpenPanel(){
    panel.SetActive(true);
}

public void setInstantity(int index, int count)
{
    intensity[index]+=count;
    ;
    UIMAnager(index);
}
public void UIMAnager(int index)
{
    int i=index-1;
    if(intensity[index]<=100 && intensity[index]>=0)
    colorBars[i].transform.localScale=new Vector2((intensity[index]/maxIntensity),1);
    colorTexts[i].GetComponent<TextMeshProUGUI>().text=intensity[index].ToString();

}
   
}
