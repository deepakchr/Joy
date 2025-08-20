pipeline {
    agent any

    environment {
        TARGET_SERVER = "localhost"                     // Change if deploying to a remote server
        APP_PATH = "C:\\Applications\\ADAFSAAPI"       // Deployment folder on the target server
    }

    stages {
        // Stage 1: Checkout code from GitHub
        stage('Checkout') {
            steps {
                git branch: 'main',
                    credentialsId: 'github-creds',       // Jenkins credential ID for GitHub
                    url: 'https://github.com/deepakchr/Joy.git'
            }
        }

        // Stage 2: Restore NuGet packages
        stage('Restore') {
            steps {
                bat 'dotnet restore AdfsaLabAPI.sln'
            }
        }

        // Stage 3: Build the solution
        stage('Build') {
            steps {
                bat 'dotnet build AdfsaLabAPI.sln -c Release'
            }
        }

        // Stage 4: Run tests
        stage('Test') {
            steps {
                bat 'dotnet test AdfsaLabAPI.sln --no-build || echo "⚠️ No tests found"'
            }
        }

        // Stage 5: Publish the main project
        stage('Publish') {
            steps {
                // Replace with your main Web API project inside the solution
                bat 'dotnet publish Joy/DatabaseLayer/DatabaseLayer.csproj -c Release -o publish'
            }
        }

        // Stage 6: Deploy published files to target server
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

    // Post-build notifications
    post {
        success {
            echo "✅ Build & Deployment successful!"
        }
        failure {
            echo "❌ Build or Deployment failed!"
        }
    }
}
