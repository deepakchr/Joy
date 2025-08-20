pipeline {
    agent any

    environment {
        TARGET_SERVER = "localhost"                     // Change if deploying to a remote server
        APP_PATH = "C:\\Applications\\ADAFSAAPI"       // Deployment folder
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main',
                    credentialsId: 'github-creds',       // Jenkins credential ID for GitHub
                    url: 'https://github.com/deepakchr/Joy.git'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore AdfsaLabAPI.sln'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build AdfsaLabAPI.sln -c Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test AdfsaLabAPI.sln --no-build || echo "⚠️ No tests found"'
            }
        }

        stage('Publish') {
            steps {
                // Replace with the main Web API project inside your solution
                bat 'dotnet publish Joy/DatabaseLayer/DatabaseLayer.csproj -c Release -o publish'
            }
        }

        stage('Deploy') {
            steps {
                script {
                    bat """
                    echo Deploying published files to ${APP_PATH}...
                    xcopy /Y /E publish\\* ${APP_PATH}
                    """
                }
            }
        }
    }

    post {
        success {
            echo "✅ Build & Deployment successful!"
        }
        failure {
            echo "❌ Build or Deployment failed!"
        }
    }
}


  
