pipeline {
    agent any
 
    stages {
        stage('Checkout') {
            steps {
                git branch: 'main',
                    credentialsId: 'github-creds',
                    url: 'https://github.com/jbiswas306/AdfsaLabAPI.git'
            }
        }
 
        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }
 
        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }
 
        stage('Test') {
            steps {
                bat 'dotnet test --no-build --verbosity normal'
            }
        }
 
        stage('Publish') {
            steps {
                bat 'dotnet publish -c Release -o published'
            }
        }
    }
 
    post {
        success {
            echo 'Build, tests, and publish succeeded!'
        }
        failure {
            echo 'Pipeline failed – check logs!'
        }
    }
}
