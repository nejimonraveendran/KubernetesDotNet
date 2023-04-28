### Alpine NGINX Demo

This yaml file demonstrates the following:
- deployment
- liveness and readiness probes
- volumes and volume mounts
- storage class, persistent volume, persistent volume claim
- services (load balancer)

To access NGINX home page, open in browser:  http://localhost:8080
To shell into the Alpine pod, use: ``` kubectl delete service my-nginx-service ```

