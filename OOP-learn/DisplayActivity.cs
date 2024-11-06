
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Provider.MediaStore;

namespace OOP_learn
{
	[Activity (Label = "DisplayActivity")]			
	public class DisplayActivity : Activity
	{
		Button next, prev, ret;
        TextView txt;
        int current = 0;
        string[] info;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.DisplayAnimals);
			Init();
			AddClicks();
		}

        private void Init()
        {
			next = FindViewById<Button>(Resource.Id.Next);
            prev = FindViewById<Button>(Resource.Id.Prev);
            ret = FindViewById<Button>(Resource.Id.Ret);
            txt = FindViewById<TextView>(Resource.Id.info);
            info = Intent.GetStringArrayExtra("info");

            if (info != null && info.Length > 0)
            {
                txt.Text = info[current];
            }
            else
            {
                if (info.Length < 2)
                {
                    next.Enabled = false;
                }
            }
            prev.Enabled = false;
        }
        private void AddClicks()
        {
            prev.Click += Prev_Click;
            next.Click += Next_Click;
            ret.Click += Ret_Click;
        }

        private void Ret_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (info.Length > 0 && current == info.Length - 1)
            {
                next.Enabled = false;
            }
            else
            {
                current++;
                next.Enabled = true;
                prev.Enabled = true;
                txt.Text = info[current];
            }
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            if (current == 0)
            {
                prev.Enabled = false;
            }
            else
            {
                current--;
                prev.Enabled = true;
                next.Enabled = true;
                txt.Text = info[current];
            }
        }

    }
}

