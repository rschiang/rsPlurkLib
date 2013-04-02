using System;
using RenRen.Plurk;

namespace RenRen.Plurk.Test
{
    class ConsoleExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("rsPlurkLib Console Example");
            Console.WriteLine("1) Request temp token from Plurk");
            PlurkHelper helper = new PlurkHelper();
            helper.Client.GetRequestToken();
            Console.WriteLine("   {0} | {1}", 
                              helper.Client.Token.Content, helper.Client.Token.Secret);

            Console.WriteLine("2) Direct user to Plurk for authencation");
            string url = helper.Client.GetAuthorizationUrl();
            Console.WriteLine("   {0}", url);
            System.Diagnostics.Process.Start(url);

            Console.WriteLine("3) Exchange temp token and verifier for perm token");
            Console.Write("   Enter verifier: ");
            string verifier = Console.ReadLine();
            helper.Client.GetAccessToken(verifier);
            Console.WriteLine("   {0} | {1}",
                              helper.Client.Token.Content, helper.Client.Token.Secret);

            Console.WriteLine("A) Test: API Call");
            var entity = helper.GetUnreadPlurks();
            Console.WriteLine("Plurks retrieved: {0}", entity.plurks.Length);

            Console.ReadKey();
        }
    }
}
