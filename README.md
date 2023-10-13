# copdemo

//create az ad spn
az ad sp create-for-rbac --name "norlysdemo" --role contributor --scopes /subscriptions/edccd614-120e-4738-9be5-e63d2c6b7b10/resourceGroups/rg-apim