FROM microsoft/dotnet:2.2-sdk AS publish
WORKDIR /src
COPY . .
RUN dotnet restore "UserService.csproj"
RUN dotnet build "UserService.csproj" -c Release -o /build
RUN dotnet publish "UserService.csproj" -c Release -o /publish

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /publish .
ENTRYPOINT ["dotnet","UserService.dll"]