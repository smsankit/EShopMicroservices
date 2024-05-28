# EShopMicroservices

**1. Code repository link -** https://github.com/smsankit/EShopMicroservices

**2. Docker hub url for docker image -** https://hub.docker.com/repository/docker/smsankit/catalogapi/general

**3. API service url -** http://35.232.26.10/products

**4. Screen recording video link -**  TODO


**=> <ins>Used below command to start load-generator pod for load testing:</ins>**</br>
kubectl run -i --tty load-generator --rm --image=busybox:1.28 --restart=Never -- /bin/sh -c "while sleep 0.01; do wget -q -O- http://35.232.26.13/products;done"
