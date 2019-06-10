FROM microsoft/dotnet:2.2-sdk AS publish
ARG env
ARG redis
ARG config="Release"
RUN echo "${config}"
RUN if["$env"='Development'];then echo "yes it is";else echo "not development";fi
RUN echo "${config}"
ENV env=$env
ENV redis=$redis

WORKDIR /src
COPY src/Services/UserService .
RUN dotnet restore "UserService.csproj"
RUN dotnet build "UserService.csproj" -c ${config} --no-restore -o /build
RUN dotnet publish "UserService.csproj" -c ${config} --no-restore -o /publish

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /publish .

ENTRYPOINT dotnet UserService.dll "$env" "$redis"