pipeline {
    agent any

    environment {
        SOLUTION_NAME = 'AdfsaLabAPI.sln'
        PROJECT_DIR = 'AdfsaLabAPI'
        BUILD_CONFIG = 'Release'
        DEPLOY_PATH = 'C:\\inetpub\\wwwroot\\AdfsaLabAPI'
        MSBUILD_PATH = 'C:\\Program Files (x86)\\Microsoft Visual Studio\\2022\\BuildTools\\MSBuild\\Current\\Bin\\MSBuild.exe'
        NUGET_PATH = 'C:\\Tools\\nuget\\nuget.exe'
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
                bat "\"${env.NUGET_PATH}\" restore ${env.SOLUTION_NAME} -NonInteractive -Verbosity detailed"
            }
        }

        stage('Build Solution') {
            steps {
                bat "\"${env.MSBUILD_PATH}\" ${env.SOLUTION_NAME} /p:Configuration=${env.BUILD_CONFIG} /p:Platform=\"Any CPU\" /t:Rebuild /v:m /p:ErrorReport=prompt"
            }
        }

        stage('Deploy') {
            steps {
                bat """
                if not exist \"${env.DEPLOY_PATH}\" mkdir \"${env.DEPLOY_PATH}\"
                robocopy \"${env.WORKSPACE}\\${env.PROJECT_DIR}\\bin\\${env.BUILD_CONFIG}\" \"${env.DEPLOY_PATH}\" *.* /E /NFL /NDL /NJH /NJS /NC /NS
                """
            }
        }

        stage('Run with IIS Express') {
            steps {
                bat "start \"IIS Express\" \"${env.IIS_EXPRESS_PATH}\" /path:\"${env.DEPLOY_PATH}\" /port:${env.PORT} /clr:v4.0"
                sleep 5
            }
        }

        stage('Test Application') {
            steps {
                powershell '''
                $maxRetries = 5
                $retry = 0
                $success = $false
                while (-not $success -and $retry -lt $maxRetries) {
                    try {
                        $response = Invoke-WebRequest -Uri http://localhost:$env:PORT -UseBasicParsing
                        if ($response.StatusCode -eq 200) {
                            Write-Output "Application deployed and running successfully!"
                            $success = $true
                        } else {
                            throw "HTTP status $($response.StatusCode)"
                        }
                    } catch {
                        Write-Output "Waiting for IIS Express to start..."
                        Start-Sleep -Seconds 5
                        $retry++
                    }
                }
                if (-not $success) { throw "Site is not accessible after $maxRetries attempts" }
                '''
            }
        }
    }

    post {
        always {
            echo 'Cleaning up IIS Express...'
            bat """
            tasklist /FI "IMAGENAME eq iisexpress.exe" | findstr iisexpress.exe >nul
            if %ERRORLEVEL%==0 taskkill /IM iisexpress.exe /F
            """
        }
        success {
            echo 'Build, deploy, and test completed successfully!'
        }
        failure {
            echo 'Pipeline failed. Check build logs for details.'
        }
    }
}

