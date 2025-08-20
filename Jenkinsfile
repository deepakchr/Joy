pipeline {
    agent any

    environment {
        DOTNET_ROOT = "C:\\Program Files\\dotnet"
        TARGET_SERVER = "DV-ITApps" // Change to your Windows Server
        APP_PATH = "C:\Applications\ADAFSAAPI"
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main',
                    credentialsId: 'github-creds',
                    url: 'https://github.com/your-username/your-dotnet-repo.git'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore YourProject.sln'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build YourProject.sln -c Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test YourProject.sln --no-build'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish YourProject.csproj -c Release -o publish'
            }
        }

        stage('Deploy') {
            steps {
                script {
                    // Copy files to IIS server
                    bat """
                    xcopy /Y /E publish\\* \\\\${TARGET_SERVER}\\${APP_PATH}
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
