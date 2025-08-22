pipeline {
    agent any

    environment {
        SOLUTION_NAME = 'AdfsaLabAPI.sln'
        PROJECT_DIR = 'AdfsaLabAPI'
        BUILD_CONFIG = 'Release'
        DEPLOY_PATH = 'C:\\inetpub\\wwwroot\\AdfsaLabAPI'
        MSBUILD_PATH = 'C:\\Program Files (x86)\\Microsoft Visual Studio\\2022\\BuildTools\\MSBuild\\Current\\Bin\\MSBuild.exe'
        NUGET_PATH = 'C:\\Tools\\nuget\\nuget.exe' // path to nuget.exe
        IIS_EXPRESS_PATH = 'C:\\Program Files\\IIS Express\\iisexpress.exe'
        PORT = '8081'
    }

    stages {
        stage('Checkout Code') {
            steps {
                git branch: 'main',
                    url: 'https://github.com/deepakchr/Joy.git'
            }
        }

        stage('Restore NuGet Packages') {
            steps {
                bat "\"${env.NUGET_PATH}\" restore ${env.SOLUTION_NAME}"
            }
        }

        stage('Build Solution') {
            steps {
                bat "\"${env.MSBUILD_PATH}\" ${env.SOLUTION_NAME} /p:Configuration=${env.BUILD_CONFIG} /p:Platform=\"Any CPU\" /t:Rebuild"
            }
        }

        stage('Deploy') {
            steps {
                bat """
                if not exist ${env.DEPLOY_PATH} mkdir ${env.DEPLOY_PATH}
                xcopy /E /I /Y \"${env.WORKSPACE}\\${env.PROJECT_DIR}\\bin\\${env.BUILD_CONFIG}\\*\" \"${env.DEPLOY_PATH}\\\"
                """
            }
        }

        stage('Run with IIS Express') {
            steps {
                bat "\"${env.IIS_EXPRESS_PATH}\" /path:\"${env.DEPLOY_PATH}\" /port:${env.PORT} /clr:v4.0"
            }
        }

        stage('Test Application') {
            steps {
                powershell '''
                try {
                    $response = Invoke-WebRequest -Uri http://localhost:8080 -UseBasicParsing
                    if ($response.StatusCode -eq 200) {
                        Write-Output "Application deployed and running successfully!"
                    } else {
                        throw "Deployment failed: HTTP status $($response.StatusCode)"
                    }
                } catch {
                    throw "Site is not accessible: $_"
                }
                '''
            }
        }
    }
}
