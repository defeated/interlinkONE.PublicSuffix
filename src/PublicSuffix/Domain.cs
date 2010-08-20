
using System.Linq;

using PublicSuffix.Rules;

namespace PublicSuffix {

    /// <summary>
    /// Contains the normalized data of a domain name.
    /// </summary>
    public class Domain {

        /// <summary>
        /// The Top Level Domain, example: com, co.uk
        /// </summary>
        public string TLD { get; set; }
        
        /// <summary>
        /// The Second Level Domain, example: google
        /// </summary>
        public string MainDomain { get; set; }
        
        /// <summary>
        /// The Third Level Domain, example: www
        /// </summary>
        public string SubDomain { get; set; }
        
        /// <summary>
        /// Is the current <see cref="Domain"/> a known public suffix.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// A new, empty <see cref="Domain" /> instance.
        /// </summary>
        public Domain() : this("") {}
        
        /// <summary>
        /// A new <see cref="Domain" /> instance.
        /// </summary>
        /// <param name="tld">The Top Level Domain. Has empty Second Level Domain and empty Third Level Domain.</param>
        public Domain(string tld) : this(tld, "") {}

        /// <summary>
        /// A new <see cref="Domain" /> instance, without a Third Level Domain.
        /// </summary>
        /// <param name="tld">The Top Level Domain</param>
        /// <param name="mainDomain">The Second Level Domain</param>
        public Domain(string tld, string mainDomain) : this(tld, mainDomain, "") {}

        /// <summary>
        /// A new, full <see cref="Domain" /> instance.
        /// </summary>
        /// <param name="tld">The Top Level Domain</param>
        /// <param name="mainDomain">The Second Level Domain</param>
        /// <param name="subDomain">The Third Level Domain</param>
        public Domain(string tld, string mainDomain, string subDomain) : this(tld, mainDomain, subDomain, "") { }

        /// <summary>
        /// A new <see cref="Domain" /> instance.
        /// The optional Top Level Domain is expected first.
        /// The optional Second Level Domain is expected second.
        /// The optional Third Level Domain is expected last.
        /// </summary>
        /// <param name="parts">A string array of the domain parts.</param>
        public Domain(params string[] parts) {
            this.TLD        = parts[0];
            this.MainDomain = parts[1];
            this.SubDomain  = parts[2];
            this.IsValid    = true;
        }

        /// <summary>
        /// Converts the current <see cref="Domain" /> instance to a string.
        /// </summary>
        /// <returns>A string in the format of [subdomain.]maindomain.tld</returns>
        public override string ToString() {
            return string.Join(".", this.ToArray());
        }

        /// <summary>
        /// Converts the current <see cref="Domain" /> instance to a string array.
        /// </summary>
        /// <returns>An array in the format of [[subdomain], maindomain, tld]</returns>
        public string[] ToArray() {
            var array = new[] { this.SubDomain, this.MainDomain, this.TLD };
            array = array.SkipWhile(string.IsNullOrEmpty).ToArray();
            
            return array;
        }

    }
}
