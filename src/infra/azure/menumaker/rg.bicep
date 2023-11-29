targetScope='subscription'

param resourceGroupName string = 'rg-menumaker-dev'
param resourceGroupLocation string = 'northeurope'

resource mmRecourceGroup 'Microsoft.Resources/resourceGroups@2022-09-01' = {
  name: resourceGroupName
  location: resourceGroupLocation
}
