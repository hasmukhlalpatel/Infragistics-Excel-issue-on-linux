# Infragistics-Excel-issue-on-linux

$ docker buildx build -t my-img:1 -f ./ConsoleApp1/Dockerfile .

## solution
* https://www.nuget.org/packages?q=HarfBuzzSharp
* https://www.gemboxsoftware.com/spreadsheet/examples/create-excel-pdf-on-docker-net-core/5902
* https://stackoverflow.com/questions/73607587/unable-to-load-shared-library-libharfbuzzsharp-or-one-of-its-dependencies-erro?newreg=e5467495385d42f58ee9f13cdcfa2d2b

### following pacakges will require
* `<PackageReference Include="SkiaSharp" Version="2.88.8" />`
* `<PackageReference Include="SkiaSharp.NativeAssets.Linux.NoDependencies" Version="2.88.8" />`
* `<PackageReference Include="HarfBuzzSharp.NativeAssets.Linux" Version="7.3.0.2" />`

### working docker file sample
https://github.com/GemBoxLtd/GemBox.Spreadsheet.Examples/blob/master/C%23/Platforms/Docker/Dockerfile
https://www.gemboxsoftware.com/spreadsheet/examples/create-excel-pdf-on-docker-net-core/5902
https://github.com/GemBoxLtd/GemBox.Spreadsheet.Examples/tree/master/C%23/Platforms/Docker


### Docker run commnad

docker run --name my-fms-test -it -v C:\Temp\repos\Infragistics-Excel-issue-on-linux\ConsoleApp1:/src mcr.microsoft.com/dotnet/sdk:8.0 /bin/bash

### try on radhat
https://developers.redhat.com/articles/2023/10/31/containerize-dotnet-applications-dotnet8#customizing_the_application_image

### actual erorr

![image](https://github.com/user-attachments/assets/0f1d413d-64e6-4e41-9659-2ee00f696a86)

### Error text
`Unhandled exception. System.InvalidOperationException: Exception in BuildFontRuns() with original length of 2 now 2, style run count 1, font run count 0, direction overrides: False
 ---> System.DllNotFoundException: Unable to load shared library 'libHarfBuzzSharp' or one of its dependencies. In order to help diagnose loading problems, consider using a tool like strace. If you're using glibc, consider setting the LD_DEBUG environment variable: 
/home/hasmukh/Desktop/tmp/issue1/ConsoleApp1/bin/Debug/net8.0/runtimes/linux-x64/native/libHarfBuzzSharp.so: cannot open shared object file: No such file or directory
/usr/lib/dotnet/shared/Microsoft.NETCore.App/8.0.5/libHarfBuzzSharp.so: cannot open shared object file: No such file or directory
/home/hasmukh/Desktop/tmp/issue1/ConsoleApp1/bin/Debug/net8.0/libHarfBuzzSharp.so: cannot open shared object file: No such file or directory
/home/hasmukh/Desktop/tmp/issue1/ConsoleApp1/bin/Debug/net8.0/runtimes/linux-x64/native/liblibHarfBuzzSharp.so: cannot open shared object file: No such file or directory
/usr/lib/dotnet/shared/Microsoft.NETCore.App/8.0.5/liblibHarfBuzzSharp.so: cannot open shared object file: No such file or directory
/home/hasmukh/Desktop/tmp/issue1/ConsoleApp1/bin/Debug/net8.0/liblibHarfBuzzSharp.so: cannot open shared object file: No such file or directory
/home/hasmukh/Desktop/tmp/issue1/ConsoleApp1/bin/Debug/net8.0/runtimes/linux-x64/native/libHarfBuzzSharp: cannot open shared object file: No such file or directory
/usr/lib/dotnet/shared/Microsoft.NETCore.App/8.0.5/libHarfBuzzSharp: cannot open shared object file: No such file or directory
/home/hasmukh/Desktop/tmp/issue1/ConsoleApp1/bin/Debug/net8.0/libHarfBuzzSharp: cannot open shared object file: No such file or directory
/home/hasmukh/Desktop/tmp/issue1/ConsoleApp1/bin/Debug/net8.0/runtimes/linux-x64/native/liblibHarfBuzzSharp: cannot open shared object file: No such file or directory
/usr/lib/dotnet/shared/Microsoft.NETCore.App/8.0.5/liblibHarfBuzzSharp: cannot open shared object file: No such file or directory
/home/hasmukh/Desktop/tmp/issue1/ConsoleApp1/bin/Debug/net8.0/liblibHarfBuzzSharp: cannot open shared object file: No such file or directory

   at HarfBuzzSharp.HarfBuzzApi.hb_blob_create(Void* data, UInt32 length, MemoryMode mode, Void* user_data, DestroyProxyDelegate destroy)
   at HarfBuzzSharp.Blob.Create(IntPtr data, Int32 length, MemoryMode mode, ReleaseDelegate releaseProc)
   at HarfBuzzSharp.Blob..ctor(IntPtr data, Int32 length, MemoryMode mode, ReleaseDelegate releaseDelegate)
   at Topten.RichTextKit.TextShaper.GetHarfBuzzBlob(SKStreamAsset asset)
   at Topten.RichTextKit.TextShaper..ctor(SKTypeface typeface)
   at Topten.RichTextKit.TextShaper.ForTypeface(SKTypeface typeface)
   at Topten.RichTextKit.TextBlock.CreateFontRun(StyleRun styleRun, Slice`1 codePoints, TextDirection direction, IStyle style, SKTypeface typeface, SKTypeface asFallbackFor)
   at Topten.RichTextKit.TextBlock.FlushUnshapedRuns()
   at Topten.RichTextKit.TextBlock.BuildFontRuns()
   --- End of inner exception stack trace ---
   at Topten.RichTextKit.TextBlock.BuildFontRuns()
   at Topten.RichTextKit.TextBlock.Layout()
   at Topten.RichTextKit.TextBlock.get_MeasuredHeight()
   at Topten.RichTextKit.RichString.ParagraphInfo.Layout(LayoutContext& ctx)
   at Topten.RichTextKit.RichString.Layout()
   at Topten.RichTextKit.RichString.get_MeasuredWidth()
   at Infragistics.Documents.Excel.RichTextKitTextMetricsProvider.MeasureText(WorksheetCellFormatData format, String text, Nullable`1 proposedSize, Boolean scaleForDpi, Boolean forceSingleLine)
   at Infragistics.Documents.Excel.CellSizeMeasurementContext.GetAutoFitWidth(WorksheetCellFormatData format, String cellText, Int32 rowHeightInTwips, Int32 columnWidthInPixels)
   at Infragistics.Documents.Excel.WorksheetColumn.CalculateAutoFitWidth(Int32 startRowIndex, Int32 endRowIndex, CellSizeMeasurementContext measureContext)
   at Infragistics.Documents.Excel.WorksheetColumn.CalculateAutoFitWidth(Int32 startRowIndex, Int32 endRowIndex)
   at Infragistics.Documents.Excel.WorksheetColumn.CalculateAutoFitWidth()
   at Infragistics.Documents.Excel.WorksheetColumn.AutoFitWidth()
   at Program.<Main>$(String[] args) in /home/hasmukh/Desktop/tmp/issue1/ConsoleApp1/Program.cs:line 8
`

### Dockerfile (sample)[[bb](https://www.gemboxsoftware.com/spreadsheet/examples/create-excel-pdf-on-docker-net-core/5902)]
``` yaml
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SpreadsheetDocker.csproj", ""]
RUN dotnet restore "./SpreadsheetDocker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SpreadsheetDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpreadsheetDocker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final

# Update package sources to include supplemental packages (contrib archive area).
RUN sed -i 's/main/main contrib/g' /etc/apt/sources.list.d/debian.sources

# Downloads the package lists from the repositories.
RUN apt-get update

# Install font configuration.
RUN apt-get install -y fontconfig

# Install Microsoft TrueType core fonts.
RUN apt-get install -y ttf-mscorefonts-installer

# Or install Liberation TrueType fonts.
# RUN apt-get install -y fonts-liberation

# Or some other font package...

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpreadsheetDocker.dll"]
```
