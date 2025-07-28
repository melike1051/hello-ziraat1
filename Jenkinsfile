pipeline {
    agent {
        label 'docker-host' // <-- "docker-host" node etiketi atanmış olmalı
    }

    environment {
        DOCKER_IMAGE = 'melike1051/hello-ziraat:latest'
        DOCKER_REGISTRY = 'docker.io'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build') {
            steps {
                echo "Building Docker image..."
                sh 'docker build -t $DOCKER_IMAGE .'
            }
        }

        stage('Login') {
            steps {
                echo "Logging in to DockerHub..."
                withCredentials([usernamePassword(
                    credentialsId: 'dockerhub-credentials-id',
                    usernameVariable: 'DOCKER_USERNAME',
                    passwordVariable: 'DOCKER_PASSWORD'
                )]) {
                    sh 'echo $DOCKER_PASSWORD | docker login -u $DOCKER_USERNAME --password-stdin'
                }
            }
        }

        stage('Push') {
            steps {
                echo "Pushing Docker image to registry..."
                sh 'docker push $DOCKER_IMAGE'
            }
        }
    }
}
