
using System;
using System.Linq;

namespace PublicSuffix.Rules {

    public abstract class Rule {

        public string Name { get; set; }
        public string Value { get; set; }

        public Rule(string name) {
            this.Name   = name.ToLowerInvariant();
            this.Value  = this.Name;
        }

        public string[] Parts {
            get {
                return this.Name.Split('.').Reverse().ToArray();
            }
        }

        public int Length {
            get {
                return this.Parts.Length;
            }
        }

        public override string ToString() {
            return this.Name;
        }

        public virtual bool IsMatch(string url) {
            var host    = this.Canonicalize(url);
            var match   = true;

            for(var h = 0; h < host.Length; h++) {
                if(h < this.Length) {
                    var part = this.Parts[h];
                    if(part != host[h] && part != "*") match = false;
                }
            }

            return match;
        }

        public virtual Domain Parse(string url) {
            var host = this.Canonicalize(url);

            var domain = new Domain() {
                TLD         = string.Join(".", host.Take(this.Length).Reverse().ToArray()),
                MainDomain  = host.Skip(this.Length).First(),
                SubDomain   = string.Join(".", host.Skip(this.Length + 1).Reverse().ToArray())
            };

            return domain;
        }

        protected string[] Canonicalize(string url) {
            var uri = new Uri(url);
            return uri.DnsSafeHost.Split('.').Reverse().ToArray();
        }
    }
}
