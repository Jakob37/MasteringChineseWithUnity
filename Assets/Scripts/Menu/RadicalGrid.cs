﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadicalGrid : MonoBehaviour
{
    private GridLayout grid;
    public GameObject test_object;
    private MenuController menu_controller;

    void Awake() {

        // TestObject[] objs = GetComponentsInChildren<TestObject>();
        // foreach (TestObject obj in objs) {
        //     Destroy(obj.gameObject);
        // }

        menu_controller = FindObjectOfType<MenuController>();
        // for (int i = 0; i < 50; i++) {
        //     print("Creating instance");
        // }
    }

    void Start() {
        var radical_dict = menu_controller.RadicalDict;

        int largest_count = 0;
        foreach (string key in radical_dict.Keys) {
            if (radical_dict[key] > largest_count) {
                largest_count = radical_dict[key];
            }
        }

        foreach (string key in radical_dict.Keys) {
            GameObject instance = Instantiate(test_object);
            instance.transform.SetParent(gameObject.transform);
            MenuCharacter menu_char = instance.GetComponent<MenuCharacter>();
            menu_char.SetRadical(key);
            menu_char.SetCount(radical_dict[key], largest_count);
            // menu_char.SetMostAbundantCount(largest_count);
        }
    }
}
