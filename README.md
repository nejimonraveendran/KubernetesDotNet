# Kubernetes .NET Development Using Docker Desktop

### Concepts
- **Node**: The physical or virtual worker machine that runs the workloads.
- **Master**: One or more nodes that control the nodes.
- **Pod**: An ephemeral wrapper around one or more containers.  Pods can be scaled in or out.  
- **Service**: A more permanent IP address as well as load balancer that can work as an entrypoint into the pods.
- **Ingress**: A DNS entry that routes traffic to a service so that the pod can be referenced using DNS.
- **ConfigMap**: Confguration data such as URLs, connection string, etc.
- **Secrets**: Same as config map but meant for storing secrets such as DB credentials, certificates, etc.
- **Volume**: Storage for persistence of data outside K8s cluster (host, NFS, cloud, etc.)
- **StatefulSet**: A pod intended for stateful workloads like database that can be scaled up or down.
- **Deployment**: Pod deployment object.

### K8s Web UI Dashboard
setup: https://github.com/DanWahlin/DockerAndKubernetesCourseCode/tree/main/samples/dashboard-security
localhost:8001

### General K8s commands
```bash
#linux command for less typing: 
alias k=kubectl

kubectl version

kubectl cluster-info

#list everything on the cluster
kubectl get all 

#list all pods
kubectl get pods

#describe pod
kubectl describe pod <pod-name>

#get pod info in yaml format
kubectl get pod <pod-name> -o yaml

#run shell on the pod interatively
kubectl exec <pod-name> -it -- sh

#view container/pod logs
kubectl logs <pod-name>

#delete pod
kubectl delete pod my-nginx

#run a pod out of an image (imperative approach)
kubectl run my-nginx --image=nginx:alpine
kubectl port-forward my-nginx 8080:80

#deploy yaml
kubectl apply -f <yaml-file-name.yml>

#get deployments
kubectl get deployments --show-labels

#describe deployment:
kubectl describe deployment <deployment-name>

#get specific deployment by label
kubectl get deployment -l deployment-name=<deployment-name> 

#imperatively scale in/out pods (eg. scale to 3 pods):
kubectl scale deployment <deployment-name> --replicas=3

#delete deployment
kubectl delete -f nginx-deployment.yml

#get and describe service
kubectl get service <service-name>
kubectl describe service <service-name>

#get and describe persistent volume
kubectl get pv <persistent-volume-name>
kubectl describe pv <persistent-volume-name>

#get and describe persistent volume claim
kubectl get pvc <persistent-volume-claim-name>
kubectl describe pvc <persistent-volume-claim-name>

#get and describe storage class
kubectl get sc <storage-class-name>
kubectl describe sc <storage-class-name>

```











