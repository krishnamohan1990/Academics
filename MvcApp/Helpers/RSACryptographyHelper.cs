using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using Microsoft.Ajax.Utilities;

namespace MvcApp.Helpers
{
	public static class RSACryptographyHelper
	{
		private static string privateKey =
			@"<RSAKeyValue><Modulus>uoAeAD2YL2CWaOzMvn/94VO+ZPWS6uOmI3B4KTjbQ1pN706fq+/IVhGesL+/GQ6VhCuy0my8ks2tBnanZRYTYWmiYfPTVFdlHbJjhXLbgiAnmB0jgQIN3ggnBObf8lzlY2kJjhgNBrkvgZwXlUA96nu+7fBxppBi3OFgHoW5vJsZ6iCsN8265KUkPV01ScMUlaX/KCCV6j4dX6cJk6XluM8ut7m9NnL1b4q05kuxCSnxfvQ3Nwo4J4QzMqtnXhOzkYOZ8+dwFh+aKebBv+fZAIVdgmTrMO5eaHjIh5sUZrXwwXL966jt85bY9kdxYmz//Hoqpf4n/kBrIlGdKugpFw==</Modulus><Exponent>AQAB</Exponent><P>5IW2+HHOSEvifXJpxg6xVXZU9L1gU5pLeqn2lxHF3kapwFwpGDFJtjhR76L65TjD043R1bdjLoCWzEY8nGBteRloi9kOW4TsLO3tWWPRlbDCLpBLP6HczT9n8m9A0eHvtHf3jK6hO0Icb0TBWCmY9vk6M/rA45ro44AB9D/pE5c=</P><Q>0Ozm2NgTUzmL4eF7+w/X3/TECB3VrhecpigBfMryuKQeDRIMtx31E4B98xoTjXeCzUYhE8wAS2YDW9g/b7RvEZiWUZh7cc05uWveCxUQs/GmPx1V9NsAlJdyAWe33k/ApFQYTCQqUJc8apAtjt50fUUIeto+v3VR5p2oydj2RoE=</Q><DP>IypkdqTkroFm8BD8L+sw5MrZ1fOScCsNNGoVNTgZ79OF6cEE3eEvy6etDChTXZS3pcVsJewbihtlmTexugqorfr3+JVFPVYeFefjH19Z8CQMLagsvDUHSlpYf5kZK3MONQJFCNQSoZDR2VmGOy/jhxXhHACZUC0Va3TWWCTBlC8=</DP><DQ>S50h42M4g0t1g/ferjvKroRgmmtp1Ys4J66c8zRkak0Dj0l0DqYp97fuXZiXcQDK904lVIvlo2Q1XP1D
4ELWW/D0nm1oaASVmrUedLZYCDgyKe+NF4RXjm/NVBLcqfoFR7Qj4xLHuckylYK+6lE6qcfdTNFGGnb0gFmZKAx8/YE=</DQ><InverseQ>37Mjo4ICi8jy8vCER2Cj0XsRPDfd0LXpfRbGP7ST2WH/NBh/d/gv1wVGuvqiuEC02HKVn4QS1z6WYUMLHPt33T6AI2PK0RD9kCoaaIsZU3qSieTG4DOM0/QojJnxLdxQidxc0HcgoLti2ixE4wSnCedi2wXw1e3wx/44U8BQsRc=</InverseQ><D>CzKsGnmYTKfxAAXP2VRYCxJ7KRaxppban+Ad5uO6DpY6fbbr0WgJUFmofJZWxAtjINd62jWbMPlWfT/cly43Ja8xB86bDsJcmObgIOAfm/WQSwrc2d8ktAMrTJkMM0Iup8RjxXteNNwjpRWZOOXtkcmyUhkQyd57gSWrHsoKt+9B4AckXArEa3QfaKE6gWntI2HqFHI1ShinnF439K7U/3vj9IUOYMZ6JXOcMMuzlaS4cDwYzUOiwsUKu0CIq6G7O4h9xRoYLsosaL9r31rPG+iC4fSKYM9wStINlTl66NAYKqy0SoToYgj866SkUf7QpjAwqADQPHZsD5pxZGTRAQ==</D></RSAKeyValue>";

		private static string publicKey =
			@"<RSAKeyValue><Modulus>uoAeAD2YL2CWaOzMvn/94VO+ZPWS6uOmI3B4KTjbQ1pN706fq+/IVhGesL+/GQ6VhCuy0my8ks2tBnanZRYTYWmiYfPTVFdlHbJjhXLbgiAnmB0jgQIN3ggnBObf8lzlY2kJjhgNBrkvgZwXlUA96nu+7fBxppBi3OFgHoW5vJsZ6iCsN8265KUkPV01ScMUlaX/KCCV6j4dX6cJk6XluM8ut7m9NnL1b4q05kuxCSnxfvQ3Nwo4J4QzMqtnXhOzkYOZ8+dwFh+aKebBv+fZAIVdgmTrMO5eaHjIh5sUZrXwwXL966jt85bY9kdxYmz//Hoqpf4n/kBrIlGdKugpFw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

		public static string EncryptString(string inputString)
		{
			if (!string.IsNullOrEmpty(inputString))
			{
				RSACryptoServiceProvider crypt = new RSACryptoServiceProvider();
				byte[] byt = System.Text.Encoding.UTF8.GetBytes(inputString);
				crypt.FromXmlString(publicKey);
				var data = crypt.Encrypt(byt, false);
				var datastring = Convert.ToBase64String(data);
				return datastring;
			}
			else return string.Empty;
		}

		public static string DecryptString(string EncryptedString)
		{
			if (!string.IsNullOrEmpty(EncryptedString))
			{
				var data = Convert.FromBase64String(EncryptedString);
				RSACryptoServiceProvider crypt = new RSACryptoServiceProvider();
				crypt.FromXmlString(privateKey);
				var byt = crypt.Decrypt(data, false);
				var inputstring = System.Text.Encoding.UTF8.GetString(byt);
				return inputstring;
			}
			else return string.Empty;
		}
	}
}