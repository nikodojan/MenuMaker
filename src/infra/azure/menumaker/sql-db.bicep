param administratorLogin string = ''

@secure()
param administratorLoginPassword string = ''
param collation string = 'SQL_Latin1_General_CP1_CI_AS'
param databaseName string = 'mm_db'
param tier string = 'GeneralPurpose'
param skuName string = 'GP_S_Gen5_2'
param location string = 'northeurope'
param maxSizeBytes int = 34359738368
param serverName string = 'free-tier-sql-db-server'
param sampleName string = ''
param zoneRedundant bool = false
param licenseType string = ''
param readScaleOut string = 'Disabled'
param numberOfReplicas int = 0
param autoPauseDelay int = 60
param allowAzureIps bool = true
param databaseTags object = {'app': 'menumaker'}
param serverTags object = {'app': 'menumaker'}

param allowClientIp bool = true
param clientIpRuleName string = 'ClientIp-ND-2023-11-29_11-19-11'
param clientIpValue string = '147.78.30.245'
param publicNetworkAccess string = 'Enabled'
param requestedBackupStorageRedundancy string = 'Local'

resource server 'Microsoft.Sql/servers@2021-05-01-preview' = {
  location: location
  tags: serverTags
  name: serverName
  properties: {
    version: '12.0'
    minimalTlsVersion: '1.2'
    publicNetworkAccess: publicNetworkAccess
    administratorLogin: administratorLogin
    administratorLoginPassword: administratorLoginPassword
  }
}

resource serverName_database 'Microsoft.Sql/servers/databases@2022-08-01-preview' = {
  parent: server
  location: location
  tags: databaseTags
  name: '${databaseName}'
  properties: {
    collation: collation
    maxSizeBytes: maxSizeBytes
    sampleName: sampleName
    zoneRedundant: zoneRedundant
    licenseType: licenseType
    readScale: readScaleOut
    highAvailabilityReplicaCount: numberOfReplicas
    autoPauseDelay: autoPauseDelay
    requestedBackupStorageRedundancy: requestedBackupStorageRedundancy
    isLedgerOn: false
    availabilityZone: 'NoPreference'
    useFreeLimit: true
    freeLimitExhaustionBehavior: 'BillOverUsage'
  }
  sku: {
    name: skuName
    tier: tier
  }
}

resource serverName_AllowAllWindowsAzureIps 'Microsoft.Sql/servers/firewallrules@2021-11-01' = if (allowAzureIps) {
  parent: server
  location: location
  name: 'AllowAllWindowsAzureIps'
  properties: {
    endIpAddress: '0.0.0.0'
    startIpAddress: '0.0.0.0'
  }
}

resource serverName_Default 'Microsoft.Sql/servers/connectionPolicies@2014-04-01' = {
  parent: server
  location: location
  name: 'Default'
  properties: {
    connectionType: 'Default'
  }
}

resource serverName_clientIpRule 'Microsoft.Sql/servers/firewallrules@2021-11-01' = if (allowClientIp) {
  parent: server
  location: location
  name: clientIpRuleName
  properties: {
    endIpAddress: clientIpValue
    startIpAddress: clientIpValue
  }
}
