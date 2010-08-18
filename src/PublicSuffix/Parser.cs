
using System;
using System.Collections.Generic;
using System.Linq;

using PublicSuffix.Rules;

namespace PublicSuffix {

    /// <summary>
    /// Parser attempts to return a <see cref="Domain" /> instead from a string url by
    /// inspecting a ist of <see cref="Rule"/>s from a <see cref="RulesList"/>.
    /// </summary>
    public class Parser {
        private Rule[] Rules { get; set; }

        /// <summary>
        /// Parser requires an array of <see cref="Rule" />s to do its work.
        /// </summary>
        /// <param name="rules">An array of <see cref="Rule" />s from a <see cref="RulesList" /></param>
        public Parser(Rule[] rules) {
            this.Rules = rules;
        }

        /// <summary>
        /// Uses the following algorithm from http://publicsuffix.org/format/
        /// <list type="bullet">
        /// <item><description>Match domain against all rules and take note of the matching ones.</description></item>
        /// <item><description>If no rules match, the prevailing rule is "*".</description></item>
        /// <item><description>If more than one rule matches, the prevailing rule is the one which is an exception rule.</description></item>
        /// <item><description>If there is no matching exception rule, the prevailing rule is the one with the most labels.</description></item>
        /// <item><description>If the prevailing rule is a exception rule, modify it by removing the leftmost label.</description></item>
        /// <item><description>The public suffix is the set of labels from the domain which directly match the labels of the prevailing rule (joined by dots).</description></item>
        /// <item><description>The registered domain is the public suffix plus one additional label.</description></item>
        /// </list>
        /// </summary>
        /// <param name="url">A valid url. example: http://www.google.com</param>
        /// <returns>A normalized <see cref="Domain" /> instance.</returns>
        public Domain Parse(string url) {
            var matches = this.Rules
                .Where(r => r.IsMatch(url))
                .ToList();

            var rule =  matches.Where(r => r is ExceptionRule).FirstOrDefault()
                        ??
                        matches.OrderByDescending(r => r.Length).FirstOrDefault();

            var domain = new Domain();
            if (rule != null) {
                domain = rule.Parse(url);
                domain.IsValid = true;
            }

            return domain;
        }
    }

}
