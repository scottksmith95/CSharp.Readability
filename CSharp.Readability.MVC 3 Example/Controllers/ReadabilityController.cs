using System.Web.Mvc;
using CSharp.Readability.Api.Interfaces;
using CSharp.Readability.Connect;
using Spring.Social.OAuth1;

namespace CSharp.Readability.MVC_3_Example.Controllers
{
    public class ReadabilityController : Controller
    {
		// Register your own Readability app at https://www.readability.com/publishers/api
		// Configure the Callback URL with 'http://localhost/Readability/Callback'

		// Set your consumer key & secret here
		private const string ReadabilityApiKey = "ENTER YOUR KEY HERE";
		private const string ReadabilityApiSecret = "ENTER YOUR SECRET HERE";

		readonly IOAuth1ServiceProvider<IReadability> _readabilityProvider = new ReadabilityServiceProvider(ReadabilityApiKey, ReadabilityApiSecret);

		public ActionResult Index()
		{
			var token = Session["AccessToken"] as OAuthToken;
			if (token != null)
			{
				var readabilityClient = _readabilityProvider.GetApi(token.Value, token.Secret);
				var bookmarks = readabilityClient.BookmarkOperations.GetReadingListBookmarksAsync(1, 50).Result;

				return View(bookmarks.Bookmarks);
			}

			var requestToken = _readabilityProvider.OAuthOperations.FetchRequestTokenAsync("http://localhost:55474/Readability/Callback", null).Result;

			Session["RequestToken"] = requestToken;

			return Redirect(_readabilityProvider.OAuthOperations.BuildAuthenticateUrl(requestToken.Value, null));
		}

		[HttpPost]
		public ActionResult Index(string url)
		{
			var token = Session["AccessToken"] as OAuthToken;

			if (token != null)
			{
				var readabilityClient = _readabilityProvider.GetApi(token.Value, token.Secret);

				readabilityClient.BookmarkOperations.AddBookmarkAsync(url);
			}

			return RedirectToAction("Index");
		}

		public ActionResult Callback(string oauth_verifier)
		{
			var requestToken = Session["RequestToken"] as OAuthToken;
			var authorizedRequestToken = new AuthorizedRequestToken(requestToken, oauth_verifier);
			var token = _readabilityProvider.OAuthOperations.ExchangeForAccessTokenAsync(authorizedRequestToken, null).Result;

			Session["AccessToken"] = token;

			return RedirectToAction("Index");
		}

		public ActionResult Favorite(int id)
		{
			var token = Session["AccessToken"] as OAuthToken;

			if (token != null)
			{
				var readabilityClient = _readabilityProvider.GetApi(token.Value, token.Secret);

				readabilityClient.BookmarkOperations.UpdateBookmarkAsync(id, true);
			}

			return RedirectToAction("Index");
		}

		public ActionResult Archive(int id)
		{
			var token = Session["AccessToken"] as OAuthToken;

			if (token != null)
			{
				var readabilityClient = _readabilityProvider.GetApi(token.Value, token.Secret);

				readabilityClient.BookmarkOperations.UpdateBookmarkAsync(id, false, true);
			}

			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var token = Session["AccessToken"] as OAuthToken;

			if (token != null)
			{
				var readabilityClient = _readabilityProvider.GetApi(token.Value, token.Secret);

				readabilityClient.BookmarkOperations.DeleteBookmarkAsync(id);
			}

			return RedirectToAction("Index");
		}
    }
}
