# Public Suffix Parser

Checks a url against the Public Suffix List at <http://publicsuffix.org/> to see if it contains a valid or invalid domain name.

## Build

To manually build the assembly, load `src\PublicSuffix.sln` in Visual Studio 2010.

Or you can run the automated build.

### Automated Build Prerequisites

1. install `ruby`
2. install the Albacore gem `gem install albacore`

Run `rake release` to produce a `build\Release\` folder.

### Other Rake Tasks

There are some other helpful `rake` tasks included. Run `rake -T` from the root directory for a list.

    rake build    # Build the solution
    rake clean    # Clean the build directory
    rake compile  # Compile the solution
    rake dist     # Build zip file for Release
    rake docs     # Generate the documentation
    rake release  # Build for Release
    rake test     # Run the specs

## Usage

    using PublicSuffix;

    var list = new RulesList();                                    // get a new rules list
    var rules = list.FromFile(@"data\effective_tld_names.dat");    // parse a local copy of the publicsuffix.org file
    var parser = new Parser(rules);                                // create an instance of the parser

    // parse urls into Domain objects
    var domain1 = parser.Parse("http://google.com");       // => new Domain("com", "google")
    var domain2 = parser.Parse("http://www.bbc.co.uk");    // => new Domain("co.uk", "bbc", "www")
    var domain3 = parser.Parse("http://fake.zzz");         // => new Domain("zzz", "fake")
    domain3.IsValid;                                       // => false


## License

Copyright (c) 2011 interlinkONE, Inc.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

## Thanks!

Sponsored by interlinkONE, Inc. <http://interlinkONE.com>