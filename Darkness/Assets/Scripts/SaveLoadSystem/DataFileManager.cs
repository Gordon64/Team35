using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataFileManager
{
    private string directoryPath = Application.persistentDataPath;

    private string fileName = "";

    public DataFileManager(string file){
        this.fileName = file;
    }
    public SavedInfo Load(){
        string path = Path.Combine(directoryPath, fileName);
        SavedInfo currData = null;
        if (File.Exists(path)){
            try{
                string receivingData = "";
                using (FileStream stream = new FileStream(path, FileMode.Open)){
                    using (StreamReader reader = new StreamReader(stream)){
                        receivingData = reader.ReadToEnd();
                    }
                }
                currData = JsonUtility.FromJson<SavedInfo>(receivingData);
            }
            catch(Exception error){
                UnityEngine.Debug.Log("Error trying to retrieve file");
            }
        }
        return currData;
    }

    public void Save(SavedInfo info){
        string path = Path.Combine(directoryPath, fileName);
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        string temp = JsonUtility.ToJson(info, true);

        using(FileStream stream = new FileStream(path,FileMode.Create)){
            using (StreamWriter writer = new StreamWriter(stream)){
                writer.Write(temp);
            }
        }
    }
}
