FROM mcr.microsoft.com/dotnet/core/sdk:2.1
WORKDIR /hrs/

COPY *.csproj ./
RUN dotnet restore

COPY . ./hrs
RUN dotnet build -c Release
ENTRYPOINT ["dotnet", "run", "-c", "Release", "--no-build"]