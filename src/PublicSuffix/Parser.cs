
using System;
using System.Collections.Generic;
using System.Linq;

using PublicSuffix.Rules;

namespace PublicSuffix {

    public class Parser {
        public Rule[] Rules { get; private set; }

        public Parser(Rule[] rules) {
            this.Rules = rules;
        }

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
