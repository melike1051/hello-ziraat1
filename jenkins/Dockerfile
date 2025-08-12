FROM jenkins/jenkins:lts

USER root

# Kubectl yükle
RUN curl -LO "https://dl.k8s.io/release/v1.30.1/bin/linux/amd64/kubectl" && \
    chmod +x kubectl && mv kubectl /usr/local/bin/

# Docker CLI kur
RUN apt-get update && \
    apt-get install -y docker.io && \
    usermod -aG docker jenkins

# Helm yükle (örneğin v3.14.0)
RUN curl -fsSL https://get.helm.sh/helm-v3.14.0-linux-amd64.tar.gz -o helm.tar.gz \
    && tar -zxvf helm.tar.gz \
    && mv linux-amd64/helm /usr/local/bin/helm \
    && chmod +x /usr/local/bin/helm \
    && rm -rf linux-amd64 helm.tar.gz

USER jenkins
