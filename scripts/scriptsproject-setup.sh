Set-Location "infrastructure\helm\hello-ziraat"
helm dependency update
helm install hello-ziraat .
