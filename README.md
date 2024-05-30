# EShopMicroservices

**1. Code repository link -** https://github.com/smsankit/EShopMicroservices

**2. Docker hub url for api service docker image -** https://hub.docker.com/r/smsankit/catalogapi  **(smsankit/catalogapi:latest)**

**3. Dockerhub url for postgres DB -** https://hub.docker.com/_/postgres  **(postgres:13 )**

**4. API service url -** (GET) http://34.42.35.63/products

**5. Screen recording video link -**  https://drive.google.com/drive/folders/1oVYDhK1PACgI9uYsHJsMh4cvNiq8JSjf?usp=sharing

**6. All K8s YAML files are in k8s-yml directory of the repo.**

**7. Docker image file is in src/Services/Catalog/Catalog.API directory of the repo.**


**8. <ins>Used below command to start load-generator pod to test HPA:</ins>**</br>
kubectl run -i --tty load-generator --rm --image=busybox:1.28 --restart=Never -- /bin/sh -c "while sleep 0.01; do wget -q -O- http://34.42.35.63/products;done"
