# libraries
bootstrap : https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.3/css/bootstrap.min.css
signalR-client : npm install @aspnet/signalr-client 
<PackageReference Include="Microsoft.AspNetCore.SignalR" Version="1.0.0-alpha2-final" />

<add key="owin:AppStartup" value="AspNet_Backend.Startup"/>
[assembly: OwinStartup(typeof(AspNet_Backend.Startup))]