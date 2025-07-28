pipeline {
    agent any
    environment {
        DOCKER_IMAGE = 'melike1051/hello-ziraat:latest'
        DOCKER_REGISTRY = 'docker.io'
    }
    stages {
        stage('Build') {
            steps {
                sh 'docker build -t $DOCKER_IMAGE .'
            }
        }
        stage('Login') {
            steps {
                withCredentials([usernamePassword(credentialsId: 'dockerhub-credentials-id', usernameVariable: 'DOCKER_USERNAME', passwordVariable: 'DOCKER_PASSWORD')]) {
                    sh 'echo $DOCKER_PASSWORD | docker login -u $DOCKER_USERNAME --password-stdin'
                }
            }
        }
        stage('Push') {
            steps {
                sh 'docker push $DOCKER_IMAGE'
            }
        }
    }
}
