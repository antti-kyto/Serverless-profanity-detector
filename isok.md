# IsOk

Detects profanities in a input and returns *OK!* or *NOT OK!* 

**URL** : `/isok`

**Method** : `POST`

**Auth required** : NO

**Data example**

```json
{
    "body": "creator of this was a little brick",
}
```

## Success Response

**Code** : `200 OK`

**Example**

```json
{"statusCode":200,"body":"NOT OK!","isBase64Encoded":false}
```

## Error Response

**Condition** : No body/input provided

**Code** : `400 BAD REQUEST`

**Example** :

```json
{"statusCode":400,"body":"No input provided","isBase64Encoded":false}
```