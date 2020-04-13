FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as publish
WORKDIR /publish
COPY ANPCommerce.Web.csproj .
RUN dotnet restore "ANPCommerce.Web.csproj"
COPY . .
RUN dotnet publish "ANPCommerce.Web.csproj" -c Release -o ./out

FROM mcr.microsoft.com/dotnet/core/sdk:2.2
WORKDIR /var/www/aspnetcoreapp
COPY --from=publish /publish/out .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "ANPCommerce.Web.dll"]
