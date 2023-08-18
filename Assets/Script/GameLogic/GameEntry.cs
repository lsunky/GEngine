using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEngine;

public class GameEntry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Load()
    {
        // 一行代码可以加载所有配置。 cfg.Tables 包含所有表的一个实例字段。
        var tables = new cfg.Tables(LoadJson);
        // 访问普通的 key-value 表
        Debug.Log(tables.TbItem.Get(10002).Name);
    }

    private static JSONNode LoadJson(string file)
    {
        return JSON.Parse(File.ReadAllText($"{Application.dataPath}/../Configs/Content/{file}.json", System.Text.Encoding.UTF8));
    }
}
