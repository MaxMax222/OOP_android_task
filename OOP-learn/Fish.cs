using System;
namespace OOP_learn
{
	public class Fish : Animal
	{
        public double Depth { get; }
		public Fish(string name, Genders gender, double energy, double depth) : base(name, gender, energy) { Depth = depth; }
        public override string Move() => "I move by swimming";
        public override string Talk() => "Blu Blu Blu";
    }
}

