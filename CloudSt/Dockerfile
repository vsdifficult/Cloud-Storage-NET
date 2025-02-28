FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env 

WORKDIR /src 

COPY ["./CloudSt.csproj", "./"] 
RUN dotnet restore "CloudSt.csproj" 

COPY . ./  

RUN dotnet build "./CloudSt.csproj" -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:9.0 

WORKDIR /app 

COPY --from=build-env /src/out . 

EXPOSE 80 

ENTRYPOINT ["dotnet", "CloudSt.dll"]
