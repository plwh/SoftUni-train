using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;

    public Car(string model, Engine engine, Cargo cargo)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = new List<Tire>();
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }

    public List<Tire> Tires { get; set; }
}
