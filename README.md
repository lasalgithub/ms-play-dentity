# Play Identity
Play Hub Identity MS

### Build docker image - windows
```powershell
$version=1.0.0
$env:GH_OWNER="playhuborg"
$env:GH_PAT="[GithubPersonalToken]"
docker build --secret id=GH_OWNER --secret id=GH_PAT -t play.identity:$version
```

### Build docker image - linux
```s
VERSION=1.0.1
export GH_OWNER="playhuborg"
export GH_PAT="[GithubPersonalToken]"
docker build --no-cache --progress=plain --secret id=GH_OWNER --secret id=GH_PAT   -t play.identity:$VERSION .
```

### Run the docker image
```s
ADMIN_PASSWORD=[Admin Pwd]
COSMOS_DB_CONN_STRING=[Conn String]
docker run -it --rm -p 5002:5002 --name identity -e MongoDbSettings__ConnectionString=$COSMOS_DB_CONN_STRING -e IdentitySettings__AdminUserPassword=$ADMIN_PASSWORD --network playinfra_default play.identity:$VERSION
```