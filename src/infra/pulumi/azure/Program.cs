using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Web.Inputs;
using System.Collections.Generic;

return await Pulumi.Deployment.RunAsync(() =>
{
    var config = new Config("azure-native");
    var rgName = "rg-menumaker-dev2";
    var region = config.Require("location");

    var commonTags = new Dictionary<string, string>()
    {
        { "app", "menumaker" }
    };

    // Create an Azure Resource Group
    var resourceGroup = new ResourceGroup(rgName, new()
    {
        Location = region,
        Tags = commonTags,
        ResourceGroupName = rgName
    });

    var appServicePlan = 
        new AppServicePlan(
            "appServicePlan", 
            new()
            {
                Kind = "app",
                Location = region,
                Name = $"ASP-{rgName}-mmwebapp",
                ResourceGroupName = resourceGroup.GetResourceName(),
                Sku = new SkuDescriptionArgs()
                {
                    Name = "F1",
                    Tier = "Free",
                },
                Tags = commonTags,
                TargetWorkerSizeId = 0,
                TargetWorkerCount = 1,
                ZoneRedundant = false
            }, 
            new CustomResourceOptions() 
            { 
                DependsOn = 
                { 
                    resourceGroup 
                } 
            }
        );




    // Create a WebApp
    var webApp = new WebApp("webApp", new()
    {
        Kind = "app",
        Location = region,
        Name = "wa-menumakerapi",
        ResourceGroupName = resourceGroup.GetResourceName(),
        ServerFarmId = appServicePlan.Id,
        ClientAffinityEnabled = true,
        HttpsOnly = true,
        PublicNetworkAccess = "Enabled",
        Tags = commonTags,
        SiteConfig = new SiteConfigArgs()
        {
            NetFrameworkVersion = "v8.0",
            AlwaysOn = false,
            FtpsState = FtpsState.FtpsOnly
        }
        //"/subscriptions/34adfa4f-cedf-4dc0-ba29-b6d1a69ab345/resourceGroups/testrg123/providers/Microsoft.Web/serverfarms/DefaultAsp"
    },
    new CustomResourceOptions()
    {
        DependsOn =
        {
            resourceGroup
        }
    });

    var webAppApplicationSettings = new WebAppApplicationSettings("webAppApplicationSettings", new()
    {
        Name = webApp.Name,
        Properties =
        {
            { "mm-db-connection-string", new Config("mm-azure").RequireSecret("dbConnectionString") }
        },
        ResourceGroupName = resourceGroup.GetResourceName()
    },
    new CustomResourceOptions()
    {
        Parent = webApp
    });
});