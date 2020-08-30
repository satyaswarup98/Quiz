package com.example.satya.quiz;

public class User {

    String name;
    String rank;
    int id;


    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getRank() {
        return rank;
    }

    public void setRank(String rank) {
        this.rank = rank;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }


    public User(String name,String rank, int id) {
        this.name = name;
        this.rank = rank;
        this.id = id;
    }
}
