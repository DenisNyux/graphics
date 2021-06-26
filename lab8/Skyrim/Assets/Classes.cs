using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes : MonoBehaviour
{

}
public class CAtom
{
    public string strigname;   
    public int number;          
    public string SolitudeName;     
    public char altLoc;         
    public string residue;      
    public string chain_id;     
    public int nresidue;        
    public char iCode;          
    public float x;             
    public float y;             
    public float z;             
    public float occupancy;     
    public float temp;          
    public string symbol;       
    public string charge;       

    public GameObject sphere;
    public float size;
    public Color color;
}
public class Serana
{
    public int noms;
    public CAtom[] atom;
    public string name, fullname;
    public GameObject handle;
}