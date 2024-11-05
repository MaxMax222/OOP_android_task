using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using Android.Content;
using System.Collections.Generic;

namespace OOP_learn
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button fish, dog, bird, Dfish, Ddog, Dbird, create;
        List<Animal> animals;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Init();
            AddClicks();
        }

        private void AddClicks()
        {
            fish.Click += Fish_Click;
            dog.Click += Dog_Click;
            bird.Click += Bird_Click;

            create.Click += Create_Click;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CreateAnimals));
            StartActivityForResult(intent, 1);
        }

        private void Bird_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BirdActivity));
            StartActivity(intent);
        }

        private void Dog_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(DogActivity));
            StartActivity(intent);
        }

        private void Fish_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(FishActivity));
            StartActivity(intent);
        }

        private void Init()
        {
            fish = FindViewById<Button>(Resource.Id.toFishes);
            bird = FindViewById<Button>(Resource.Id.toBirds);
            dog = FindViewById<Button>(Resource.Id.toDogs);
            Dfish = FindViewById<Button>(Resource.Id.DisplayFishes);
            Dbird = FindViewById<Button>(Resource.Id.DisplayBirds);
            Ddog = FindViewById<Button>(Resource.Id.DisplayDogs);
            create = FindViewById<Button>(Resource.Id.Create);

            animals = new List<Animal>();
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == 1 && resultCode == Result.Ok)
            {
                int type = data.GetIntExtra("type",0);
                string name = data.GetStringExtra("name");
                var gender = data.GetStringExtra("Gender") == "1" ? Animal.Genders.Male : Animal.Genders.Female;
                switch (type)
                {
                    case 1:
                        animals.Add(new Bird(name, gender, double.Parse(data.GetStringExtra("Energy")), double.Parse(data.GetStringExtra("Special"))));
                        break;
                    case 2:
                        animals.Add(new Fish(name, gender, double.Parse(data.GetStringExtra("Energy")), double.Parse(data.GetStringExtra("Special"))));
                        break;
                    case 3:
                        animals.Add(new Dog(name, gender, double.Parse(data.GetStringExtra("Milk"))));
                        break;
                    default:
                        break;
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
