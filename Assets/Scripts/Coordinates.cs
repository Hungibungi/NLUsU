using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Coordinates
{
    public class Coordinate
    {
        public string name;
        public Sprite image;
        public string text;

        public Coordinate(string name, Sprite image, string text){
            this.name = name;
            this.image = image;
            this.text = text;
        }
    }

    public static string szeged_text = 
        "The first city built underground to protect against the weather.\n"+
        "\n"+
        "This coordinate offers a medium size, close resources and no obstacles to block buildings.";
    public static string prague_text= 
        "The first city built undeasdaskdléasd.\n"+
        "\n"+
        "This coordinate offers a medium size, close resources and no obstacles to block buildings.";
    public static Coordinate[] coordinates = GetCoordinates();    

    public static Coordinate[] GetCoordinates(){
        Coordinate[] tempArray = new Coordinate[2];
        tempArray[0] = new Coordinate("Szeged", Sprites.szeged_image, szeged_text);
        tempArray[1] = new Coordinate("Prague", Sprites.prague_image, prague_text);
        return tempArray;
    }
}