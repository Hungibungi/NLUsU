using System.Net.NetworkInformation;
using UnityEngine;

public static class Sprites
{
    public static Sprite szeged_image = LoadSprite("Game/UI/map");
    public static Sprite prague_image= LoadSprite("Game/UI/map2");
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
    public static Sprite abandoned_town = LoadSprite("Menus/abandoned_town");
    public static Sprite burning_town = LoadSprite("Menus/burning_town");
    public static Sprite graveyard = LoadSprite("Menus/graveyard");
    public static Sprite lighthouse = LoadSprite("Menus/lighthouse");
    public static Sprite truck_bones = LoadSprite("Menus/truck_bones");
    public static Sprite smoke = LoadSprite("Menus/smoke");
    public static Sprite old_church = LoadSprite("Menus/old_church");
    public static Sprite help_city = LoadSprite("Menus/help_city");
    public static Sprite sad_city = LoadSprite("Menus/sad_city");
    public static Sprite happy_city = LoadSprite("Menus/happy_city");
    public static Sprite day = LoadSprite("Menus/day");
    public static Sprite extended_day = LoadSprite("Menus/extended_day");
    public static Sprite night = LoadSprite("Menus/night");
    public static Sprite build = LoadSprite("Menus/buildings");


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