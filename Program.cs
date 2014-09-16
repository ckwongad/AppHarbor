class Program
{
static void Main()
{
	string str = @"node:home/shop_iphone/family/iphone6
	step:select
	option.dimensionScreensize:4_7inch
	option.dimensionColor:silver
	option.dimensionCapacity:16gb
	option.carrierModel:UNLOCKED%2FWW
	carrierPolicyType:UNLOCKED";
	
	string[] queryArray = str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
	
	
	WebClient wc = new WebClient();
	wc.Proxy = null;
	
	foreach (string q in queryArray)
	{
		string[] e = q.Split(':');
		wc.QueryString.Add (e[0], e[1]);
	}
	
	wc.DownloadFile ("http://store.apple.com/hk/buyFlowSelectionSummary/IPHONE6", "code.htm");
	string s = File.ReadAllText ("code.htm");
	Console.WriteLine(s);
	throw new Exception("Manual");
	
}

}
