using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Sprites
{
    public static Sprite szeged_image = LoadSprite("szeged");
    public static Sprite prague_image= LoadSprite("prague");
    public static Sprite temperature_image = LoadSprite("Menus/temperature");
    public static Sprite sick_image = LoadSprite("Menus/sick");
    public static Sprite child_image = LoadSprite("Menus/children");
    public static Sprite worker_image = LoadSprite("Menus/workers");
    public static Sprite resident_image = LoadSprite("Menus/residents");
    public static Sprite happy_image = LoadSprite("Menus/happy");
    public static Sprite food_image = LoadSprite("Menus/food");
    public static Sprite power_image = LoadSprite("Menus/power");
    public static Sprite building_material_image = LoadSprite("Menus/building_material");
    public static Sprite iron_image = LoadSprite("Menus/iron");
    public static Sprite pub_logo = LoadSprite("Buildings/Logos/pub");
    public static Sprite house_of_pleasure_logo = LoadSprite("Buildings/Logos/house_of_pleasure");
    public static Sprite tent_logo = LoadSprite("Buildings/Logos/tent");
    public static Sprite family_house_logo = LoadSprite("Buildings/Logos/family_house");
    public static Sprite apartment_logo = LoadSprite("Buildings/Logos/apartment");
    public static Sprite medical_tent_logo = LoadSprite("Buildings/Logos/medical_tent");
    public static Sprite hospital_logo = LoadSprite("Buildings/Logos/hospital");
    public static Sprite iron_mine_logo = LoadSprite("Buildings/Logos/iron_mine");
    public static Sprite solar_panel_logo = LoadSprite("Buildings/Logos/solar_panel");
    public static Sprite coal_mine_logo = LoadSprite("Buildings/Logos/coal_mine");
    public static Sprite fishermans_hut_logo = LoadSprite("Buildings/Logos/fishermans_hut");
    public static Sprite apple_orchard_logo = LoadSprite("Buildings/Logos/apple_orchard");
    public static Sprite child_cookery_logo = LoadSprite("Buildings/Logos/child_cookery");
    public static Sprite science_lab_logo = LoadSprite("Buildings/Logos/science_lab");
    public static Sprite scout_station_logo = LoadSprite("Buildings/Logos/scout_station");
    public static Sprite warehouse_logo = LoadSprite("Buildings/Logos/warehouse");

    public static Sprite LoadSprite(string spriteName)
    {
        Sprite loadedSprite = Resources.Load<Sprite>(spriteName);
        if (loadedSprite == null)
        {
            Debug.LogError($"Sprite '{spriteName}' not found!");
        }
        return loadedSprite;
    }
}