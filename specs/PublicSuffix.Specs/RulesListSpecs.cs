
using Machine.Specifications;

namespace PublicSuffix.Specs {

    public class when_given_a_text_file {

        static string file;
        static string[] rules;

        Establish context = () => {
            file = @"data\effective_tld_names.dat";
        };

        Because of = () => {
            var list = new RulesList();
            rules = list.FromFile(file);
        };

        It removes_invalid_lines = () => {
            rules.ShouldNotContain("");
            rules.ShouldEachConformTo((line) => !line.StartsWith("//"));
        };

        It returns_an_array_of_rules = () => {
            rules.Length.ShouldBeGreaterThan(0);
        };

        It is_in_the_correct_order = () => {
            rules[0].ShouldEqual("ac");
            rules[rules.Length - 1].ShouldEqual("*.zw");
        };
    }

}
