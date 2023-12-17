# ProfOrient
## _Сервис профессионального ориентирования на основе информации о пользователе в социальных сетях_
### Хакатон ЛЦТ-Якутия 2023

[![ProfOrient](https://i.ibb.co/CmVXPqt/Prof-Orient-Page-Sample2.png)](https://hub.docker.com/repository/docker/doctorikari/proforient)

Данный сервис разработан на NET 8 (Blazor) и предназначен для анализа социальных сетей пользователя и рекомендации выбора будущей профессии на основе его предпочтений (профессиональное ориентирование).

Варианты авторизации:
- Официальный виджет + VK ID
- VK API (VkNet)


## Установка


Установка образа Docker

```sh
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProfOrient/ProfOrient.csproj", "ProfOrient/"]
COPY ["ProfOrient.Client/ProfOrient.Client.csproj", "ProfOrient.Client/"]
RUN dotnet restore "./ProfOrient/./ProfOrient.csproj"
COPY . .
WORKDIR "/src/ProfOrient"
RUN dotnet build "./ProfOrient.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProfOrient.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProfOrient.dll"]


ENV YANDEX_TOKEN=your_yandex_token
```
