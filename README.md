# Play Identity
Play Hub Identity MS

### Build docker image - windows
```powershell
$version=1.0.0
$env:GH_OWNER="playhuborg"
$env:GH_PAT="[GithubPersonalToken]"
docker build --secret id=GH_OWNER --secret id=GH_PAT -t play.identity:$version
```

### Build docker image - windows
```s
VERSION=1.0.0
export GH_OWNER="playhuborg"
export GH_PAT="[GithubPersonalToken]"
docker build --no-cache --progress=plain --secret id=GH_OWNER --secret id=GH_PAT   -t play.identity:$VERSION .
```