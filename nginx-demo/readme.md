### Alpine NGINX Demo

This yaml file demonstrates the following:
- deployment
- liveness and readiness probes
- volumes and volume mounts
- storage class, persistent volume, persistent volume claim
- services (load balancer)

To access NGINX home page, open in browser:  http://localhost:8080

To shell into the Alpine pod, use: 
```bash
kubectl get pods #make a note of the pod name returned

kubectl exec <pod-name> -it -- sh 

```

