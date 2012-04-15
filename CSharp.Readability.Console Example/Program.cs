using System;
using System.Diagnostics;
using CSharp.Readability.Api;
using CSharp.Readability.Connect;
using Spring.Social.OAuth1;

namespace CSharp.Readability.Console_Example
{
	class Program
	{
		// Register your own Readability app at https://www.readability.com/publishers/api

		// Set your consumer key & secret here
		private const string ReadabilityApiKey = "ENTER YOUR KEY HERE";
		private const string ReadabilityApiSecret = "ENTER YOUR SECRET HERE";

		private static void Main(string[] args)
		{
			try
			{
				var readabilityServiceProvider = new ReadabilityServiceProvider(ReadabilityApiKey, ReadabilityApiSecret);

				/* OAuth 'dance' */

				// Authentication using Out-of-band/PIN Code Authentication
				Console.Write("Getting request token...");
				var oauthToken = readabilityServiceProvider.OAuthOperations.FetchRequestTokenAsync("oob", null).Result;
				Console.WriteLine("Done");

				var authenticateUrl = readabilityServiceProvider.OAuthOperations.BuildAuthorizeUrl(oauthToken.Value, null);
				Console.WriteLine("Redirect user for authentication: " + authenticateUrl);
				Process.Start(authenticateUrl);
				Console.WriteLine("Enter PIN Code from Readability authorization page:");
				var pinCode = Console.ReadLine();

				Console.Write("Getting access token...");
				var requestToken = new AuthorizedRequestToken(oauthToken, pinCode);
				var oauthAccessToken = readabilityServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
				Console.WriteLine("Done");

				/* API */

				var readability = readabilityServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

				readability.UserOperations.GetUserAsync()
					.ContinueWith(task => Console.WriteLine("Username: " + task.Result.Username));

				readability.BookmarkOperations.GetAllBookmarksAsync(1, 50)
					.ContinueWith(task => Console.WriteLine("All bookmarks: " + task.Result.Bookmarks.Count));

				readability.BookmarkOperations.GetReadingListBookmarksAsync(1, 50)
					.ContinueWith(task => Console.WriteLine("Reading list bookmarks: " + task.Result.Bookmarks.Count));

				readability.BookmarkOperations.GetFavoriteBookmarksAsync(1, 50)
					.ContinueWith(task => Console.WriteLine("Favorite bookmarks: " + task.Result.Bookmarks.Count));

				readability.BookmarkOperations.GetArchivedBookmarksAsync(1, 50)
					.ContinueWith(task => Console.WriteLine("Archived bookmarks: " + task.Result.Bookmarks.Count));
			}
			catch (AggregateException ae)
			{
				ae.Handle(ex =>
				{
				    if (ex is ReadabilityApiException)
				    {
				        Console.WriteLine(ex.Message);
				        return true;
				    }
				    return false;
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				Console.WriteLine("--- hit <return> to quit ---");
				Console.ReadLine();
			}
		}
	}
}