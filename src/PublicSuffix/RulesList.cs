
using System.IO;
using System.Linq;
using System.Text;

using PublicSuffix.Rules;

namespace PublicSuffix {

    /// <summary>
    /// From: http://publicsuffix.org/format/
    /// - The Public Suffix List consists of a series of lines, separated by \n.
    /// - Each line is only read up to the first whitespace; entire lines can also be commented using //.
    /// - Each line which is not entirely whitespace or begins with a comment contains a rule.
    /// See http://mxr.mozilla.org/mozilla-central/source/netwerk/dns/effective_tld_names.dat?raw=1 for the latest file.
    /// </summary>
    public class RulesList {

        /// <summary>
        /// Reads a PublixSuffix formatted file.
        /// </summary>
        /// <param name="file">The a text file.</param>
        /// <returns>An array of <see cref="Rule" />s.</returns>
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
