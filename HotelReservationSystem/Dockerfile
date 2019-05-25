FROM microsoft/dotnet:2.0-sdk
WORKDIR /hrs-backend/

COPY *.csproj ./
RUN dotnet restore

COPY . ./hrs-backend
RUN dotnet build -c Release
ENTRYPOINT ["dotnet", "run", "-c", "Release", "--no-build"]