
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
            var uri     = new Uri(url);
            var host    = uri.DnsSafeHost.Split('.').Reverse().ToArray();
            var matches = new List<Rule>();

            foreach(var rule in this.Rules) {
                var parts   = rule.Parts.ToArray();
                var max     = rule.Length;
                var hosts   = host.Count();

                var match = true;
                for(var h = 0; h < hosts; h++) {
                    if(h < max) {
                        var part = parts[h];
                        if(part != host[h] && part != "*") match = false;
                    }
                }
                if(match) matches.Add(rule);
            }

            var result =    matches.Where(rule => rule is ExceptionRule).FirstOrDefault()
                            ??
                            matches.OrderByDescending(rule => rule.Length).FirstOrDefault();

            var domain = new Domain();
            if(result != null) domain.IsValid = true;

            if(result is NormalRule) {
                domain.TLD          = string.Join(".", host.Take(result.Length).Reverse().ToArray());
                domain.MainDomain   = host.Skip(result.Length).First();
                domain.SubDomain    = string.Join(".", host.Skip(result.Length + 1).Reverse().ToArray());
            }
            if(result is WildcardRule) {
                domain.TLD          = string.Join(".", host.Take(result.Length).Reverse().ToArray());
                domain.MainDomain   = host.Skip(result.Length).First();
                domain.SubDomain    = string.Join(".", host.Skip(result.Length + 1).Reverse().ToArray());
            }
            if(result is ExceptionRule) {
                domain.TLD          = string.Join(".", result.Parts.Reverse().Skip(1).ToArray());
                domain.MainDomain   = result.Parts.Last();
                domain.SubDomain    = string.Join(".", host.Skip(result.Length).ToArray());
            }

            return domain;
        }
    }

}
