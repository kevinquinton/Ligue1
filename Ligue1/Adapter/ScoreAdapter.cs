using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Ligue1.Models;
using Ligue1;

/// <summary>
/// Custom adapter to show score
/// </summary>
public class ScoreAdapter : BaseAdapter
{
    /// <summary>
    /// Liste de <seealso cref="Fixture"/>
    /// </summary>
    private List<Fixture> _fixtures;

    /// <summary>
    /// <seealso cref="Activity"/> courante
    /// </summary>
    private Activity _activity;

    /// <summary>
    /// Adapter custom permettant l'affichage d'une liste <seealso cref="Fixture"/>
    /// </summary>
    /// <param name="activity"><seealso cref="Activity"/></param>
    /// <param name="fixtures"><seealso cref="Fixture"/></param>
    public ScoreAdapter(Activity activity, List<Fixture> fixtures)
    {
        _activity = activity;
        _fixtures = fixtures;
    }

    public override int Count
    {
        get { return _fixtures.Count; }
    }

    public override Java.Lang.Object GetItem(int position)
    {
        return null;
    }

    public override long GetItemId(int position)
    {
        return _fixtures[position].Id;
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

        Fixture tempScoreItem = _fixtures[position];
        holder.HomeTeamName.Text = tempScoreItem.HomeTeamName;
        holder.GoalsHomeTeam.Text = tempScoreItem.Score.GoalsHomeTeam.ToString();

        return view;
    }

    private class ScoreViewHolder : Java.Lang.Object
    {
        public TextView HomeTeamName { get; set; }
        public TextView GoalsHomeTeam { get; set; }
    }
}