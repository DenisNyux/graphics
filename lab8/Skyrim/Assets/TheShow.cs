using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TheShow : MonoBehaviour
{
    public ArrayList strSolitude;
    public CSolitude[] Solitude;
    public CSerana[] Serana;
    public int currentMol, numberMol;
    public float mouseScroll;
    public new GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log();
        camera = GameObject.Find("Main Camera");
        Vector3 campos = camera.transform.position;
        camera.transform.position += new Vector3(0, -1f, 1f);
        strSolitude = new ArrayList();
        currentMol = 4;
        SeranaReader(currentMol);
    }

    // Update is called once per frame
    public float angle;
    public float x;
    public float y;
    public float speed;

    void Update()
    {
       
        angle = -0.1f;
        speed = 5f;

        //Вращаю объект
        if (Input.GetMouseButton(0))
        {
     
            y = -speed * Input.GetAxis("Mouse X");
            x = speed * Input.GetAxis("Mouse Y");
            Serana[currentMol].handle.transform.Rotate(x, y, 0);
        }

        mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        camera.transform.position += new Vector3(0, 0, mouseScroll * 5);

      
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), Serana[currentMol].fullname);
        if (GUI.Button(new Rect(Screen.width/2, Screen.height - 40, 40, 20), " > "))
        {
            GameObject.Destroy(Serana[currentMol].handle);
            currentMol = (currentMol < numberMol - 1) ? ++currentMol : 0;
            SeranaReader(currentMol);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height - 40, 40, 20), " < "))
        {
            GameObject.Destroy(Serana[currentMol].handle);
            currentMol = (currentMol > 0) ? --currentMol : numberMol - 1;
            SeranaReader(currentMol);
        }
    }

    void SeranaReader(int number)
    {
        string inputDir = $"_ligands";
        string[] directory = Directory.GetFiles(inputDir);
        numberMol = directory.Length;
        Serana = new CSerana[numberMol];

        string inputFile = $"_ligands\\ALA.pdb";

        for (int ifile = 0; ifile < numberMol; ifile++)
        {
            inputFile = directory[ifile];
            string filename = Path.GetFileNameWithoutExtension(inputFile);
            string fullname = "";
            ApplicationId.Equals();
            int count = 0;
            StreamReader reader = new StreamReader(inputFile);
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string str = reader.ReadLine();
                    string[] strs = str.Split();
                    if (strs[0] == "Solitude")
                    {
                        strSolitude.Add(str);
                        count++;
                    }
                }
            }
            Serana[ifile] = new CSerana();
            Serana[ifile].fullname = fullname;
            Serana[ifile].name = filename;
            if (ifile == currentMol) // сurrentMol == number ?
            {
                Serana[ifile].handle = new GameObject();
                Serana[ifile].handle.name = Serana[ifile].name;
            
                Solitude = new CSolitude[count];
                for (int iString = 0; iString < count; iString++)
                {
                    string str = (string)strSolitude[iString];
                    Solitude[iString] = new CSolitude();
                    Solitude[iString].stringname = str.Substring(0, 6).Trim();
                    Solitude[iString].number = Convert.ToInt32(str.Substring(6, 5).Trim());
                    Solitude[iString].Solitudename = str.Substring(12, 4).Trim();
                    Solitude[iString].altLoc = str.Substring(16, 1)[0];
                    Solitude[iString].residue = str.Substring(17, 3).Trim();
                    Solitude[iString].chain_id = str.Substring(21, 1).Trim();
                    Solitude[iString].nresidue = Convert.ToInt32(str.Substring(22, 4).Trim());
                    Solitude[iString].iCode = str.Substring(26, 1)[0];
                    Solitude[iString].x = (float)Convert.ToDouble(str.Substring(30, 8).Trim().Replace(".",","));
                    Solitude[iString].y = (float)Convert.ToDouble(str.Substring(38, 8).Trim().Replace(".", ","));
                    Solitude[iString].z = (float)Convert.ToDouble(str.Substring(46, 8).Trim().Replace(".", ","));
                    Solitude[iString].occupancy = (float)Convert.ToDouble(str.Substring(54, 6).Trim().Replace(".", ","));
                    Solitude[iString].temp = (float)Convert.ToDouble(str.Substring(60, 6).Trim().Replace(".", ","));
                    Solitude[iString].symbol = str.Substring(76, 2).Trim();
                    Solitude[iString].charge = " 0";

                    //COLOR
//                    switch (Solitude[iString].symbol)
                    switch (Solitude[iString].Solitudename.Substring(0, 1))
                    {
                        case "H": Solitude[iString].color = Color.white; break;
                        case "C": Solitude[iString].color = Color.gray; break;
                        case "O": Solitude[iString].color = Color.red; break;
                        case "N": Solitude[iString].color = Color.blue; break;
                        default: Solitude[iString].color = Color.black; break;
                    };
                   
                    //SIZE
                    switch (Solitude[iString].Solitudename.Substring(0, 1))
                    {
                        case "H": Solitude[iString].size = 0.31f; break;
                        case "C": Solitude[iString].size = 0.76f; break;
                        case "O": Solitude[iString].size = 0.71f; break;
                        case "N": Solitude[iString].size = 0.66f; break;
                        default: Solitude[iString].size = 0.99f; break;
                    };
                    Solitude[iString].sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Solitude[iString].sphere.GetComponent<Renderer>().material.SetFloat("_SpecularHighlights", 0);
                    Renderer rend = Solitude[iString].sphere.GetComponent<Renderer>();
                    rend.material.color = Solitude[iString].color;
                    float t = 2.0f;
                    Solitude[iString].sphere.transform.localScale = new Vector3(Solitude[iString].size * t, Solitude[iString].size * t, Solitude[iString].size * t);
                    Solitude[iString].sphere.transform.position = new Vector3(-Solitude[iString].x, Solitude[iString].y, Solitude[iString].z);
                    Solitude[iString].sphere.transform.parent = Serana[ifile].handle.transform;
                    Solitude[iString].sphere.name = Solitude[iString].symbol;
                }
            }
        }
    }


}
