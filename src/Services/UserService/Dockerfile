
FROM microsoft/dotnet:2.2-sdk AS publish
WORKDIR /src
COPY src/Services/UserService .
RUN dotnet restore "UserService.csproj"
RUN dotnet build "UserService.csproj" -c Release --no-restore -o /build
RUN dotnet publish "UserService.csproj" -c Release --no-restore -o /publish

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /publish .
ARG env
ENV env=$env
ENTRYPOINT dotnet UserService.dll "$env"