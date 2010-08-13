
using System.IO;
using System.Linq;
using System.Text;

using PublicSuffix.Rules;

namespace PublicSuffix {

    public class RulesList {

        /// <summary>
        /// From: http://publicsuffix.org/format/
        /// <list type="bullet">
        /// <item><description>The Public Suffix List consists of a series of lines, separated by \n.</description></item>
        /// <item><description>Each line is only read up to the first whitespace; entire lines can also be commented using //.</description></item>
        /// <item><description>Each line which is not entirely whitespace or begins with a comment contains a rule.</description></item>
        /// </list>
        /// </summary>
        /// <remarks>See http://mxr.mozilla.org/mozilla-central/source/netwerk/dns/effective_tld_names.dat?raw=1 for the latest file.</remarks>
        /// <param name="file">The file containing a list of rules.</param>
        /// <returns>A string array of rules.</returns>
        public Rule[] FromFile(string file) {
            var lines = (from line in File.ReadAllLines(file, Encoding.UTF8)
                         where this.IsValidRule(line)
                         select RuleFactory.Get(line)).ToArray();

            return lines;
        }

        private bool IsValidRule(string rule) {
            return !string.IsNullOrEmpty(rule) && !rule.StartsWith("//");
        }
    }
}
