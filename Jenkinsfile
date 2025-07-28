pipeline {
    agent any
    environment {
        DOCKER_IMAGE = 'melike1051/hello-ziraat:latest'
        DOCKER_REGISTRY = 'docker.io'  // Docker Hub için
        // Registry login bilgilerini Jenkins Secret olarak tanımlamalısın.
        DOCKER_CREDENTIALS_ID = 'dockerhub-credentials-id'
    }
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                script {
                    docker.build(env.DOCKER_IMAGE)
                }
            }
        }
        stage('Login') {
            steps {
                script {
                    docker.withRegistry("https://${env.DOCKER_REGISTRY}", env.DOCKER_CREDENTIALS_ID) {
                        // Bu blok içinde push işlemi yapılacak
                    }
                }
            }
        }
        stage('Push') {
            steps {
                script {
                    docker.withRegistry("https://${env.DOCKER_REGISTRY}", env.DOCKER_CREDENTIALS_ID) {
                        docker.image(env.DOCKER_IMAGE).push()
                    }
                }
            }
        }
    }
}
