param location string = 'northeurope'
param administratorLogin string = ''

@secure()
param postgresqlAdminPassword string = ''

resource postgreSql 'Microsoft.DBforPostgreSQL/flexibleServers@2022-12-01' = {
  name: 'postgresqlmm'
  location: location
  sku: {
    name: 'Standard_B1ms'
    tier: 'Burstable'
  }
  properties: {
    administratorLogin: administratorLogin
    administratorLoginPassword: postgresqlAdminPassword
    createMode: 'Default'
    authConfig: {
      activeDirectoryAuth: 'Disabled'
      passwordAuth: 'Enabled'
    }
    storage: {
      storageSizeGB: 512
    }
    version: '14'
  }
}

resource menuMakerDb 'Microsoft.DBforPostgreSQL/flexibleServers/databases@2022-12-01' = {
  name: 'mm_db'
  parent: postgreSql
  properties: {
    charset: 'utf8'
    collation: 'en_US.utf8'
  }
}
