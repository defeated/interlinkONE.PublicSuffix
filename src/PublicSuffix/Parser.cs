
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using PublicSuffix.Rules;

namespace PublicSuffix {

    public class Parser {
        public Rule[] Rules { get; private set; }

        public Parser(Rule[] rules) {
            this.Rules = rules;
        }

        public Domain Parse(string url) {
            var uri = new Uri(url);
            var matches = new List<Domain>();

            foreach(Rule rule in this.Rules) {
                var pattern = string.Format(rule.Pattern, rule.Name.Replace(".", @"\."));
                var rx = new Regex(pattern, RegexOptions.IgnoreCase);

                if(!rx.IsMatch(uri.DnsSafeHost)) continue;

                var groups = rx.Match(uri.DnsSafeHost).Groups;
                var stack = new Stack<string>(groups[1].Value.Split('.'));

                matches.Add(new Domain() {
                    IsValid = true,
                    Rule = rule,
                    TLD = groups[2].Value,
                    MainDomain = stack.Pop(),
                    SubDomain = string.Join(".", stack.Reverse().ToArray())
                });
            }

            var result = matches.Where(d => d.Rule.GetType() == typeof(ExceptionRule)).FirstOrDefault()
                        ??
                        matches.OrderByDescending(d => d.Rule.Length).FirstOrDefault()
                        ??
                        new Domain();

            return result;
        }
    }

}
