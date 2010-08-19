require 'albacore'

options = {
  :configuration => "Debug",
  :name          => "PublicSuffix"
}

task :default => [:build, :test]

desc "Build the solution"
msbuild :build do |msb|
  msb.targets [:Clean, :Build]
  msb.solution = "src/#{options[:name]}.sln"
  msb.properties :configuration => options[:configuration]
end

desc "Run the specs"
mspec :test do |mspec|

  # HACK: for some reason, mspec is looking for this in the current working directory
  cp_r "specs/#{options[:name]}.Specs/bin/#{options[:configuration]}/data", "data"

  mspec.path_to_command = "tools/Machine.Specifications/mspec.exe"
  mspec.assemblies "specs/#{options[:name]}.Specs/bin/#{options[:configuration]}/#{options[:name]}.Specs.dll"
end

desc "Generate the documentation"
docu :docs do |docu|
  docu.path_to_command = "tools/docu/docu.exe"
  docu.assemblies "src/#{options[:name]}/bin/#{options[:configuration]}/#{options[:name]}.dll"
end

desc "Build for Release"
task :release do
  options[:configuration] = "Release"
  Rake::Task["build"].invoke
  Rake::Task["doc"].invoke
end