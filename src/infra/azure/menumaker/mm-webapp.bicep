param subscriptionId string = ''
param resourceGroupName string = ''
param name string = 'menumakerapi'
param location string = 'northeurope'
param hostingPlanName string = 'ASP-rgmenumakerdev-bf53'
param serverFarmResourceGroup string = resourceGroupName
param alwaysOn bool = false
param ftpsState string = 'FtpsOnly'
param sku string = 'Free'
param skuCode string = 'F1'
param workerSize string = '0'
param workerSizeId string = '0'
param numberOfWorkers string = '1'
param currentStack string = 'dotnet'
param phpVersion string = 'OFF'
param netFrameworkVersion string = 'v8.0'

@secure()
param asDbConnectionString string = ''

resource webApp 'Microsoft.Web/sites@2018-11-01' = {
  name: name
  location: location
  tags: {
    app: 'menumaker'
  }
  properties: {
    name: name
    siteConfig: {
      appSettings: []
      metadata: [
        {
          name: 'CURRENT_STACK'
          value: currentStack
        }
      ]
      phpVersion: phpVersion
      netFrameworkVersion: netFrameworkVersion
      alwaysOn: alwaysOn
      ftpsState: ftpsState
    }
    serverFarmId: '/subscriptions/${subscriptionId}/resourcegroups/${serverFarmResourceGroup}/providers/Microsoft.Web/serverfarms/${hostingPlanName}'
    clientAffinityEnabled: true
    httpsOnly: true
    publicNetworkAccess: 'Enabled'
  }
  dependsOn: [
    hostingPlan
  ]
}

resource appSettings 'Microsoft.Web/sites/config@2022-09-01' = {
  name: 'appsettings'
  kind: 'string'
  parent: webApp
  properties: {
    'mm-db-connection-string': asDbConnectionString
  }
}

// resource name_web 'Microsoft.Web/sites/sourcecontrols@2020-12-01' = {
//   parent: webApp
//   name: 'web'
//   properties: {
//     repoUrl: repoUrl
//     branch: branch
//     isManualIntegration: false
//     deploymentRollbackEnabled: false
//     isMercurial: false
//     isGitHubAction: true
//     gitHubActionConfiguration: {
//       generateWorkflowFile: true
//       workflowSettings: {
//         appType: 'webapp'
//         publishType: 'code'
//         os: 'windows'
//         runtimeStack: 'dotnet'
//         workflowApiVersion: '2020-12-01'
//         slotName: 'production'
//         variables: {
//           runtimeVersion: '8.x'
//         }
//       }
//     }
//   }
// }

resource hostingPlan 'Microsoft.Web/serverfarms@2018-11-01' = {
  name: hostingPlanName
  location: location
  kind: ''
  tags: {
    app: 'menumaker'
  }
  properties: {
    name: hostingPlanName
    workerSize: workerSize
    workerSizeId: workerSizeId
    numberOfWorkers: numberOfWorkers
    zoneRedundant: false
  }
  sku: {
    tier: sku
    name: skuCode
  }
  dependsOn: []
}
