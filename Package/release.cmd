del "*.nupkg"
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack Oqtane.Theme.Corporate.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Packages\" /Y
