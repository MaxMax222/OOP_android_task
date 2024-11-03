using System;
namespace OOP_learn
{
	public class Dog : Mammal
	{
		public Dog(string name, Genders gender, double milk) : base(name, gender, milk) { }
        public override string Move() => "I move by walking";
        public override string Talk() => "Bark";
    }
}

