using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Provider;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Ligue1.Models;
using System.Collections;
using Ligue1;

/// <summary>
/// Custom adapter to show score
/// </summary>
public class ScoreAdapter : BaseAdapter
{
    List<Fixture> _matchs;
    Activity _activity;

    public ScoreAdapter(Activity activity, List<Fixture> matchs)
    {
        _activity = activity;
        _matchs = matchs;
    }

    public override int Count
    {
        get { return _matchs.Count; }
    }

    public override Java.Lang.Object GetItem(int position)
    {
        return null;
    }

    public override long GetItemId(int position)
    {
        return _matchs[position].Id;
    }

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        ScoreViewHolder holder = null;
        var view = convertView;

        if (view == null)
        {
            view = _activity.LayoutInflater.Inflate(Resource.Layout.score_item, null);

            holder = new ScoreViewHolder();
            holder.HomeTeamName = (TextView) view.FindViewById(Resource.Id.homeTeamNameTxt);
            holder.GoalsHomeTeam = (TextView) view.FindViewById(Resource.Id.goalsHomeTeamTxt);

            view.Tag = holder;
        }
        else
        {
            holder = view.Tag as ScoreViewHolder;
        }

        //Now the holder holds reference to our view objects, whether they are 
        //recycled or created new. 
        //Next we need to populate the views

        //var tempServiceItem = ServiceItems[position];
        //holder.Name.Text = tempServiceItem.Name;
        //holder.Category.Text = tempServiceItem.Category;

        return view;
    }

    private class ScoreViewHolder : Java.Lang.Object
    {
        public TextView HomeTeamName { get; set; }
        public TextView GoalsHomeTeam { get; set; }
    }
}