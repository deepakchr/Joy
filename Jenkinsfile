pipeline {
    agent any

    environment {
        DOTNET_ROOT = "C:\\Program Files\\dotnet"
        TARGET_SERVER = "DV-ITApps"                  // Your Windows Server
        APP_PATH = "Applications\\ADAFSAAPI"        // Shared folder on target
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main',
                    credentialsId: 'github-creds',
                    url: 'https://github.com/deepakchr/Joy.git'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore Joy.sln'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build Joy.sln -c Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test Joy.sln --no-build'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish Joy.csproj -c Release -o publish'
            }
        }

        stage('Deploy') {
            steps {
                script {
                    bat """
                    echo Copying published files to \\\\${TARGET_SERVER}\\${APP_PATH}...
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

  
