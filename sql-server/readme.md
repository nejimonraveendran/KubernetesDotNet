### SQL Server in Kubernetes Demo

This yaml file demonstrates the following:
- stateful set deployment
- host path volumes and volume mounts
- services (load balancer)

Deploy the yaml with the following command:

```bash
kubectl apply -f sqlserver-statefulset.yml
```

To access SQL Server from Management Studio, use:
- Server: 127.0.0.1,1433
- User: sa
- Password: Admin@123 

For pod operations, use: 
```bash
kubectl get pods #make a note of the pod name returned

#shell into pod
kubectl exec <pod-name> -it -- sh 

#view logs
kubectl logs <pod-name>

```

