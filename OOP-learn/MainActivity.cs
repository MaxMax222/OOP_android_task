using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using Android.Content;

namespace OOP_learn
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button fish, dog, bird;
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
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
