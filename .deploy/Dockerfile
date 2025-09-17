FROM mcr.microsoft.com/dotnet/sdk:9.0 AS compilador

WORKDIR /src
COPY .. .
RUN dotnet restore "Maquiagem.Api/Maquiagem.Api.csproj" \
 && dotnet build "Maquiagem.Api/Maquiagem.Api.csproj" -c Release -o /app/build\
 && dotnet publish "Maquiagem.Api/Maquiagem.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0

LABEL empresa="flaviabanchieri.com"
LABEL projeto="maquiagem.flaviabanchieri.com"
LABEL imagem="api"

WORKDIR /app

COPY --from=compilador /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Maquiagem.Api.dll"]