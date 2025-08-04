FROM jenkins/jenkins:lts

USER root

# Kubectl yükle
RUN curl -LO "https://dl.k8s.io/release/v1.30.1/bin/linux/amd64/kubectl" && \
    chmod +x kubectl && mv kubectl /usr/local/bin/

USER jenkins
