pipeline {
    agent any

    environment {
        IMAGE_NAME = 'melike1051/hello-ziraat:latest'
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/melike1051/hello-ziraat1.git'
            }
        }

        stage('Build') {
            steps {
                dir('Backend') {
                    sh 'docker build -t $IMAGE_NAME .'
                }
            }
        }

        stage('Login') {
            steps {
                withCredentials([usernamePassword(
                    credentialsId: 'dockerhub-credentials-id',
                    usernameVariable: 'DOCKER_USERNAME',
                    passwordVariable: 'DOCKER_PASSWORD'
                )]) {
                    sh '''
                        echo "$DOCKER_PASSWORD" | docker login -u "$DOCKER_USERNAME" --password-stdin
                    '''
                }
            }
        }

        stage('Push') {
            steps {
                sh 'docker push $IMAGE_NAME'
            }
        }
    }
}
