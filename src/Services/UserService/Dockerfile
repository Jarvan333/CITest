FROM microsoft/dotnet:2.2-sdk as publish
WORKDIR /src
COPY . .
RUN dotnet restore "UserService.csproj"
RUN dotnet build "UserService.csproj" -c Release
RUN dotnet publish "UserService.csproj" -c Release -o /publish

FROM microsoft/dotnet:2.2-aspnetcore-runtime as final
WORKDIR /app
EXPOSE 5000
COPY --from=publish /publish .
ENTRYPOINT ["dotnet","UserService.dll"]