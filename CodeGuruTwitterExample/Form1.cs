using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LinqToTwitter;

namespace CodeGuruTwitterExample
{
  public partial class Form1 : Form
  {
    private const string MY_TWITTER_NAME = "shawty_ds";

    private readonly SingleUserAuthorizer _authorizer = new SingleUserAuthorizer
    {
      CredentialStore = new SingleUserInMemoryCredentialStore
      {
        ConsumerKey = "<replace this with your consumer key>",
        ConsumerSecret = "<replace this with your consumer secret>",
        AccessToken = "<replace this with your access token>",
        AccessTokenSecret = "<replace this with your access token secret>"
      }
    };

    private List<Status> _currentTweets;

    public Form1()
    {
      InitializeComponent();

      GetMostRecent200HomeTimeLine();
      lstTweetList.Items.Clear();
      _currentTweets.ForEach(tweet => lstTweetList.Items.Add(tweet.User.Name + ":" + tweet.Text));

      GetSideBarList(GetFollowers()).ForEach(name => lstFollowNames.Items.Add(name));
    }

    private void GetMostRecent200HomeTimeLine()
    {
      var twitterContext = new TwitterContext(_authorizer);

      var tweets = from tweet in twitterContext.Status
                   where tweet.Type == StatusType.Home &&
                   tweet.Count == 200
                   select tweet;

      // NOTE: there is no error handling here, if you get an exception check the inner exception details, if your keys or auth fail this is where you'll see the fail first.
      _currentTweets = tweets.ToList();
    }

    private List<string> GetFollowers()
    {
      List<string> results = new List<string>();

      var twitterContext = new TwitterContext(_authorizer);

      var temp = Enumerable.FirstOrDefault(from friend in twitterContext.Friendship
                                           where friend.Type == FriendshipType.FollowersList &&
                                                 friend.ScreenName == MY_TWITTER_NAME &&
                                                 friend.Count == 200
                                           select friend);

      if (temp != null)
      {
        temp.Users.ToList().ForEach(user => results.Add(user.Name));

        while (temp != null && temp.CursorMovement.Next != 0)
        {
          temp = Enumerable.FirstOrDefault(from friend in twitterContext.Friendship
                                           where friend.Type == FriendshipType.FollowersList &&
                                                 friend.ScreenName == MY_TWITTER_NAME &&
                                                 friend.Count == 200 &&
                                                 friend.Cursor == temp.CursorMovement.Next
                                           select friend);

          if (temp != null) temp.Users.ToList().ForEach(user => results.Add(user.Name));
        }
      }

      return results;
    }

    private List<string> GetSideBarList(List<string> inputNames)
    {
      List<string> results = new List<string>();

      foreach (string name in inputNames)
      {
        int tweetCount = _currentTweets.Count(tweet => tweet.User.Name == name);
        results.Add(tweetCount > 0 ? string.Format("{0} ({1})", name, tweetCount) : string.Format("{0}", name));
      }

      return results;
    }

    private void LstFollowNamesSelectedIndexChanged(object sender, EventArgs e)
    {
      lstTweetList.Items.Clear();
      var listBox = sender as ListBox;
      if (listBox != null)
      {
        var selectedName = listBox.SelectedItem.ToString();
        const string pattern = @"^(.*)\s\(\d{0,4}\)$";

        Match match = Regex.Match(selectedName, pattern);

        if (match.Success)
        {
          // We have a name with a count appended
          selectedName = match.Groups[1].Value.Trim();
        }

        foreach (var tweet in _currentTweets.Where(tweet => tweet.User.Name == selectedName))
        {
          lstTweetList.Items.Add(tweet.User.Name + ":" + tweet.Text);
        }
      }
    }

    private void BtnShowAllClick(object sender, EventArgs e)
    {
      lstTweetList.Items.Clear();
      _currentTweets.ForEach(tweet => lstTweetList.Items.Add(tweet.User.Name + ":" + tweet.Text));
    }

    private List<Status> SearchTwitter(string searchTerm)
    {
      var twitterContext = new TwitterContext(_authorizer);

      var srch =
        Enumerable.SingleOrDefault((from search in twitterContext.Search
                                    where search.Type == SearchType.Search &&
                                          search.Query == searchTerm &&
                                          search.Count == 200
                                    select search));
      if(srch != null && srch.Statuses.Count > 0)
      {
        return srch.Statuses.ToList();
      }

      return new List<Status>();
    }

    private void BtnSearchClick(object sender, EventArgs e)
    {
      if(string.IsNullOrEmpty(txtSearchTerm.Text))
      {
        MessageBox.Show("Please enter a term to search for");
        return;
      }

      var results = SearchTwitter(txtSearchTerm.Text);
      lstTweetList.Items.Clear();
      results.ForEach(tweet => lstTweetList.Items.Add(tweet.User.Name + ":" + tweet.Text));

    }

  }
}
