# Serverless profanity detector
This application implements a simple profanity detector that uses [AWS Lambda](https://aws.amazon.com/lambda/), [Amazon API Gateway](https://aws.amazon.com/api-gateway/) 

## Live Demos/Examples
``` bash
curl -X POST --data-binary "creator of this was a little brick" https://e50v8kw0ki.execute-api.eu-central-1.amazonaws.com/dev/isok
```
``` bash
curl -X POST --data-binary "creator of this was a little shit" https://e50v8kw0ki.execute-api.eu-central-1.amazonaws.com/dev/censor
```

## Requirements
- .NET Core 3.1
- Serverless

## Dependencies
- [Amazon.Lambda.APIGatewayEvents](https://www.nuget.org/packages/Amazon.Lambda.APIGatewayEvents/)
- [Amazon.Lambda.Core](https://www.nuget.org/packages/Amazon.Lambda.Core/)
- [Amazon.Lambda.Serialization](https://www.nuget.org/packages/Amazon.Lambda.Serialization.SystemTextJson/)
- [Profanity.Detector](https://www.nuget.org/packages/Profanity.Detector/)

## Endpoints

[IsOk](isok.md) : `POST /isok`

[Login](censor.md) : `POST /censor`


## Supported languages
- EN
- FI (enable or disable in dev.yml & prod.yml files)

## Development

### deploying **dev**
Windows
``` cmd 
    ./build.cmd
    sls deploy -s dev
```
Linux/macOS
``` bash 
    ./build.sh
    sls deploy -s dev
```

### deploying **prod**
Windows
``` cmd 
    ./build.cmd
    sls deploy -s prod
```
Linux/macOS
``` bash 
    ./build.sh
    sls deploy -s prod
```

### Invoking locally

**testFiles** folder contains a file you can use to invoke functions locally
```
    serverless invoke local -f detect -s dev -p ./testFiles/test.json
```

