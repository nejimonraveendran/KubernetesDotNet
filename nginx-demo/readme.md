### Alpine NGINX Demo

This yaml file demonstrates the following:
- pod deployment
- liveness and readiness probes
- volumes and volume mounts (empty dir, host path, persistent)
- storage class, persistent volume, persistent volume claim
- services (load balancer)

Deploy the yaml with the following command:

```bash
kubectl apply -f nginx-deployment.yml
```

To access NGINX home page, open in browser:  http://localhost:8080

To shell into the Alpine pod, use: 
```bash
kubectl get pods #make a note of the pod name returned

kubectl exec <pod-name> -it -- sh 

```

