<p align="center">
  
  <img src="https://github.com/ddun2/The-I-Among-E-s/assets/67744902/6b561b0b-c121-48fc-8a1e-ec4afb9f7cb8" width="400" height="500">
</p>

# 🎮The I Among E's
"하루 종일 집에 있고 싶어!"

집으로 찾아온 외향인들의 연락을 피해 살아남기
<p align="center">
<img src="https://github.com/ddun2/The-I-Among-E-s/assets/67744902/7c7b47a6-b7d3-4a3a-8b6c-b0e58b495e4e" width="400" height="300">

<img src="https://github.com/ddun2/The-I-Among-E-s/assets/67744902/cd70fdbe-afe4-4260-a822-cc13ed905a50" width="400" height="300">
</p>

# 📢프로젝트 소개
Unity를 활용한 2D TopDownView 슈팅 게임

고전 게임인 '닷지'를 리메이크하여 적의 공격을 피해하고 물리치는 방식의 슈팅 게임
# 📅개발 기간
- 24.05.16 - 24.05.23
# 📝개발 환경
- Engine : Unity 2022.3.17f1
- IDE : Visual Studio 2022
- Language : C#
- Framwork : .NET 6.0
# 🏃팀원 구성
- 차성호(팀장) - 플레이어 조작 및 애니메이션
- 김서영 - 몬스터 행동 및 애니메이션
- 김유민 - 시작 화면, 게임 화면, UI 구성, 이미지
- 박성준 - 몬스터 소멸 및 생성, 전반적인 충돌 처리
# 🛠️주요 기능
- ## 캐릭터
  - 조작
  - 공격
  - 피격
- ## 몬스터
  - 이동
  - 공격
- ## 전투 관련
  - [충돌 처리](https://github.com/ddun2/The-I-Among-E-s/wiki/%EC%B6%A9%EB%8F%8C-%EC%B2%98%EB%A6%AC)
  - [생성 및 소멸](https://github.com/ddun2/The-I-Among-E-s/wiki/%EB%AA%AC%EC%8A%A4%ED%84%B0-%EC%83%9D%EC%84%B1-%EB%B0%8F-%EC%86%8C%EB%A9%B8)
- ## UI
  - [시작 화면](https://github.com/wow245/The-I-Among-E-s/wiki/%EA%B2%8C%EC%9E%84-%EA%B0%9C%EB%B0%9C-%EC%9E%85%EB%AC%B8-%ED%8C%80%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8-%E2%80%90-The%E2%80%90I%E2%80%90Among%E2%80%90E%E2%80%90s) -> mbti 입력하고 판별하는부분
  - [게임 화면](https://github.com/wow245/The-I-Among-E-s/wiki/%EB%A9%94%EC%9D%B8-%EC%94%AC-%EB%A7%8C%EB%93%A4%EA%B8%B0) -> 점수 계산 및 표시
  - [게임오버](https://github.com/wow245/The-I-Among-E-s/wiki/%EA%B2%8C%EC%9E%84%EC%98%A4%EB%B2%84%EC%B0%BD,-%EC%8A%A4%ED%86%A0%EB%A6%AC%EC%B0%BD,-%ED%98%84%EC%9E%AC,-%EC%B5%9C%EA%B3%A0-%EC%A0%90%EC%88%98%EA%B5%AC%ED%98%84) -> 재시작 종료

# ⚙️주요 기술
- Singleton
  - UI 관련 처리나 플레이어의 정보 등을 모든 스크립트에서 공유하기 위해 GameManager 생성시 활용
- Scriptable Object
  - 플레이어와 몬스터가 가지는 공격 관련 정보를 관리하기 위해 활용
  - 다수의 몬스터가 생성되지만 가지고 있는 정보를 중복 생성하지 않는 장점을 가짐
- Object Pool
  - 지속적으로 생성되고 소멸되는 몬스터와 발사체를 효율적으로 관리하기 위해 활용

# 🔔링크
[팀 노션 페이지](https://teamsparta.notion.site/I-9-a05dec2947684e5985128c1bb04ab16e)

UML 와이어 프레임 등등 추가
