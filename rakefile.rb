require 'albacore'

options = {
  :configuration => "Debug",
  :name          => "PublicSuffix",
  :output        => "build"
}

task :default => [:build, :test]

desc "Clean the build directory"
task :clean do
  rm_rf options[:output]
  mkdir_p options[:output]
end

desc "Compile the solution"
msbuild :compile => :clean do |msb|
  msb.targets [:Clean, :Build]
  msb.solution = "src/#{options[:name]}.sln"
  msb.properties :configuration => options[:configuration]
end

desc "Build the solution"
task :build => :compile do |msb|
	cp_r "src/#{options[:name]}/bin/#{options[:configuration]}", "#{options[:output]}/#{options[:configuration]}"
end

desc "Run the specs"
mspec :test do |mspec|

  # HACK: for some reason, mspec is looking for this in the current working directory
  cp_r "specs/#{options[:name]}.Specs/bin/#{options[:configuration]}/data", "data"

  mspec.path_to_command = "tools/Machine.Specifications/mspec.exe"
  mspec.html_output = "#{options[:output]}/specs.html"
  mspec.options "--timeinfo", "--silent"
  mspec.assemblies "specs/#{options[:name]}.Specs/bin/#{options[:configuration]}/#{options[:name]}.Specs.dll"
end

desc "Generate the documentation"
docu :docs do |docu|
  docu.path_to_command = "tools/docu/docu.exe"
  docu.output_location = "#{options[:output]}/#{options[:configuration]}/docs"
  docu.assemblies "src/#{options[:name]}/bin/#{options[:configuration]}/#{options[:name]}.dll"
end

desc "Build for Release"
task :release do
  options[:configuration] = "Release"
  
  Rake::Task[:build].invoke
  Rake::Task[:docs].invoke
end

desc "Build zip file for Release"
zip :dist => :release do |zip|
  zip.directories_to_zip "#{options[:output]}/#{options[:configuration]}"
  zip.output_file = "#{options[:name]}-0.0.0.0-#{options[:configuration]}.zip"
  zip.output_path = "#{options[:output]}"
end