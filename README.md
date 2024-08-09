# Infragistics-Excel-issue-on-linux

$ docker buildx build -t my-img:1 -f ./ConsoleApp1/Dockerfile .

## solution
* https://www.nuget.org/packages?q=HarfBuzzSharp
* https://www.gemboxsoftware.com/spreadsheet/examples/create-excel-pdf-on-docker-net-core/5902
* https://stackoverflow.com/questions/73607587/unable-to-load-shared-library-libharfbuzzsharp-or-one-of-its-dependencies-erro?newreg=e5467495385d42f58ee9f13cdcfa2d2b

### following pacakges will require
* <PackageReference Include="SkiaSharp" Version="2.88.8" />
* <PackageReference Include="SkiaSharp.NativeAssets.Linux.NoDependencies" Version="2.88.8" />
* <PackageReference Include="HarfBuzzSharp.NativeAssets.Linux" Version="7.3.0.2" />
