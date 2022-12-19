# Test your own oEmbed link!

oEmbed tester 프로젝트에 오신것을 환영합니다.

이 프로젝트는 oEmbed의 프로퍼티들을 확인할 수 있는 서비스의 구성인 Web App'과 API를 포함하고 있습니다.


# oEmbed 테스트하기

이 항목에서는 oEmbed 테스트하는 방법에 대해 설명합니다.

먼저, 아래 [프로젝트 실행 및 종료](#프로젝트-실행-및-종료) 항목에서 소개하는 프로젝트 [실행 방법](#프로젝트를-실행하는-방법)에 따라, `web`과 `api`를 실행합니다.

그 다음, `http://localhost:5176` 주소로 이동해 다음과 같은 화면을 확인합니다.

<img src="https://user-images.githubusercontent.com/110667795/208405443-e49d812b-9a7b-4c49-892b-c6f2a3d40081.png" width="800px">

## oEmbed 주소 입력

### 화면 구성

먼저 화면 구성에 대해 간략하게 설명합니다. 프로젝트의 화면은 `[1]: url 입력`과 `[2]:oEmbed Property 출력` 요소들로 구성되어 있습니다.

<img src="https://user-images.githubusercontent.com/110667795/208409533-c5aeaf1d-0ebb-4416-a1f1-bf5f613e18af.png" width="800px">

### 링크 입력

`[1]: url 입력` 항목에 테스트할 url을 입력합니다.

여기서 `url`은 youtube, vimeo 등에서 서비스하는 콘텐츠의 주소를 의미합니다. 예를 들어 youtube의 콘텐츠 url은 `https://www.youtube.com/watch?v=3JsMQXQCRdY`이 됩니다.

`url`을 input box에 잘 입력했다면 Test 버튼을 눌러 [프로퍼티를 확인](#프로퍼티-확인)합니다.

### 참고 사항 

instagram 혹은 facebook에 있는 콘텐츠인 경우, meta의 open api 폐지 정책으로 인해 사용이 불가합니다. 

meta 제품의 oembed api를 사용하기 위해서는 application 검수가 필요한데, 3 ~ 5일정도의 시간이 소요됩니다. 과제 기간 내에 검수가 완료되지 않아 적용이 불가했습니다.

자세한 내용은 [여기](https://happist.com/576181/페이스북-oembed-개방형-api를-포기-이유와-인스타그램-삽입)를 참조해주세요.


## 프로퍼티 확인

`url`이 oEmbed Provider의 유효한 url이라면, 다음과 같은 oEmbed 프로퍼티들을 확인할 수 있습니다.

<img src="https://user-images.githubusercontent.com/110667795/208412408-26f13eb8-3009-4bfa-977a-3aa7464570b9.png" width="800px">

### 지원하는 oEmbed 속성

이 프로젝트에서는 [oEmbed 공식 문서](https://oembed.com)의 `2.3.4. Response parameters` 항목에 명시되어 있는 프로퍼티를 지원합니다.

자세한 내용은 [여기](https://oembed.com/#section2.3)를 참조해 주세요.



# 프로젝트 실행 및 종료

이 항목에서는 프로젝트를 실행 및 종료하고, 로그를 확인하는 방법에 대해 설명합니다.

## 사전 요구사항

이 프로젝트는 `.NET 7.0` 환경에서 제작되었습니다. 

프로젝트 실행을 위해서는 `.NET 7.0 SDK`가 설치되어 있습니다.

SDK 설치를 위해 [여기](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.101-macos-x64-installer)를 클릭해주세요.


## 프로젝트를 실행하는 방법
레포지토의 메인 디렉토리에서 /script 디렉터리에 있는 [launcher-for-mac.sh 스크립트](scripts/launcher-for-mac.sh)를 실행합니다.
```shell
./scripts/launcher-for-mac.sh
```

스크립트를 실행하면 다음과 같은 로그를 확인할 수 있습니다.
```shell
Start launching.
Starting oEmbedTester API...
Starting oEmbedTester Web...
now web is listening on: http://localhost:5176
Launching completed.
```

스크립트를 실행한 후 상기 로그에서 찾을 수 있는 `http://localhost:5176` 주소로 이동합니다.

프로젝트가 정상적으로 실행되고 있다면, 아래와 같은 페이지를 확인하실 수 있습니다.

<img src="https://user-images.githubusercontent.com/110667795/208405443-e49d812b-9a7b-4c49-892b-c6f2a3d40081.png" width="800px">


## 실행 로그를 확인하는 방법

레포지토의 메인 디렉토리에서 /script 디렉터리로 이동합니다.

launcher에 의해 프로젝트가 정상적으로 실행되었다면 `logs` 디렉터리를 찾을 수 있습니다.

디렉터리의 구조는 다음과 같으며, Web과 API 중 본인이 확인하고자 하는 프로젝트의 폴더로 이동해 로그를 확인하면 됩니다.

```shell
logs
|
|-- api
|-- web
```

## 프로젝트 실행을 종료하는 방법

레포지토의 메인 디렉토리에서 /script 디렉터리에 있는 [exit_for_mac.sh 스크립트](scripts/exit-for-mac.sh)를 실행합니다.
```shell
./scripts/exit-for-mac.sh
```

스크립트를 실행하면 다음과 같은 로그를 확인할 수 있습니다.
```shell
Start exit launcher.
Identified api pid: 61037
Stopping API...
Identified web pid: 61050
Stopping Web...
exit finished.
```
