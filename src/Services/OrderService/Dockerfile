FROM microsoft/dotnet:2.2-sdk as publish
WORKDIR /src
COPY . .
RUN dotnet restore "OrderService.csproj"
RUN dotnet build "OrderService.csproj" -c Release
RUN dotnet publish "OrderService.csproj" -c Release -o /publish

FROM microsoft/dotnet:2.2-aspnetcore-runtime as final
WORKDIR /app
EXPOSE 5000
COPY --from=publish /publish .
ENTRYPOINT ["dotnet","OrderService.dll"]
