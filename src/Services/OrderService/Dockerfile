FROM microsoft/dotnet:2.2-sdk AS publish
WORKDIR /src
COPY src/Services/OrderService .
RUN dotnet restore "OrderService.csproj"
RUN dotnet build "OrderService.csproj" -c Release --no-restore -o /build
RUN dotnet publish "OrderService.csproj" -c Release --no-restore -o /publish

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /publish .
ENTRYPOINT ["dotnet","OrderService.dll"]
