namespace DIKUArena;
using System;

public class Gladiator {
    //I keep every field private, such that they can only be changed through the setters.
    //I keep every setter except for Name public, since they are used throughout the codebase, particularly at the different subclasses GetExperience() method.

    //I have made everything as secure as possible, if I change the accessibility of any of the remaining properties, I get errors.

    private string name;
    public string Name {
        get { return name; }
        private set { name = value; }
    }
    private int level;
    protected int Level {
        get { return level; }
        set { level = value; }
    }
    private int maxHealth;
    protected int MaxHealth {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    private int health;
    public int Health { 
        get { return health; }
        set { health = (value > maxHealth) ? maxHealth : value; } //Use of the ternary operators. I could not find a use for it anywhere else without sacrificing clarity.
    }
    private int strength;
    protected int Strength {
        get { return strength; }
        set { strength = value; }
    }
    private int dodge;
    protected int Dodge {
        get { return dodge; }
        set { dodge = value; }
    }
    private int doubleStrike;
    protected int DoubleStrike {
        get { return doubleStrike; }
        set { doubleStrike = value; }
    }

    private Random rand = new Random();

    public Gladiator(string Name) {
        name = Name;
        level = 1;
        maxHealth = 20;
        health = 20;
        strength = 4;
        dodge = 10;
        doubleStrike = 10;
    }
    public override string ToString() {
        return $"name: {name}\nlevel: {level}\nhealth: {health}";
    }
    public bool HasLost() {
        return health <= 0;
    }

    public bool LoseHealth(int amount) {
        if (dodge > rand.Next(101)) { //10% chance
            Console.WriteLine("You managed to dodge!");
            return false;
        } else {
            health -= amount;
            return true;
        }
    }

    public void Attack(Gladiator opponent) {
        if (doubleStrike > rand.Next(101)) { //10% chance
            opponent.LoseHealth(2 * strength);
            Console.WriteLine($"{name} double strikes an attack at {opponent.name} for {strength * 2} points of draining.");
        } else {
            opponent.LoseHealth(strength);
            Console.WriteLine($"{name} strikes an attack at {opponent.name} for {strength} points of draining.");
        }
    }
    public virtual void GetExperience() {
        level++;
    }

}