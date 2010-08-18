
using System;
using System.Linq;
using System.Reflection;

using PublicSuffix.Rules;

namespace PublicSuffix {

    public class RuleFactory {

        private Type[] Types;

        public RuleFactory() {
            this.Types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(Rule).IsAssignableFrom(t) && !t.IsAbstract)
                .ToArray();
        }

        public Rule FromLine(string line) {
            var indicator = line[0].ToString();

            var type =  this.Types.FirstOrDefault(t => this.StaticProperty(t, "Indicator") == indicator)
                        ??
                        typeof(NormalRule);

            var rule = Activator.CreateInstance(type, line) as Rule;

            return rule;
        }

        private string StaticProperty(Type type, string name) {
            var value = type
                .GetProperty(name, BindingFlags.Public | BindingFlags.Static)
                .GetValue(null, null);

            return value as string;
        }
    }
}
