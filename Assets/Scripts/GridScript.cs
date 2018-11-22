﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GridLanguage {
    character,
    pinying,
    english
}

public class GridScript : MonoBehaviour {

    public GameObject mCellPrefab;
    public int cells;

    public GridLanguage cell_type;

    private Cell[] mCells = new Cell[1000];
    private AnkiParser anki_parser;

    void Awake() {
        anki_parser = GameObject.FindObjectOfType<AnkiParser>();
    }

    void Start() {
        Build();
    }

    public void Build() {
        for (int i = 0; i <= cells; i++) {
            GameObject newCell = Instantiate(mCellPrefab, transform);
            mCells[i] = newCell.GetComponent<Cell>();

            string new_word = anki_parser.GetWord(i);

            mCells[i].Setup(new_word);
        }
    }
}