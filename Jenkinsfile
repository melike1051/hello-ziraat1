pipeline {
    agent any
    environment {
        DOCKER_IMAGE = 'melike1051/hello-ziraat:latest'
        DOCKER_REGISTRY = 'docker.io'
    }
    stages {
        stage('Checkout') {
            steps {
                sh 'rm -rf hello-ziraat1' // varsa temizle
                sh 'git clone https://github.com/melike1051/hello-ziraat1.git'
            }
        }
        stage('Build') {
            steps {
                dir('hello-ziraat1/Backend') {
                    sh "docker build -t $DOCKER_IMAGE ."
                }
            }
        }
        stage('Login') {
            steps {
                withCredentials([usernamePassword(credentialsId: 'dockerhub-credentials-id', usernameVariable: 'DOCKER_USERNAME', passwordVariable: 'DOCKER_PASSWORD')]) {
                    sh "echo $DOCKER_PASSWORD | docker login -u $DOCKER_USERNAME --password-stdin"
                }
            }
        }
        stage('Push') {
            steps {
                sh "docker push $DOCKER_IMAGE"
            }
        }
    }
}
