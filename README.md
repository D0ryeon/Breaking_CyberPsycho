# 사이버사이코가 되고싶어(A03팀)

고전게임인 벽돌깨기를 리빌딩해서 구현했습니다.


## 시연 영상

https://github.com/D0ryeon/Breaking_CyberPsycho/assets/70641418/a09c5e57-23fe-4337-b532-6c7c3fb75e78

<br/>

## 팀원 / 담당 파트


|이름|담당 업무|깃허브 링크|
|------|---|---|
|김명식|팀장|[링크](https://github.com/D0ryeon)|
|송승훈|팀원|[링크](https://github.com/DoDokang318)|
|차요한|팀원|[링크](https://github.com/HOHOJO)|
|김준범|팀원|[링크](https://github.com/IAK0401)|
|임전혁|팀원|[링크](https://github.com/yarogono)|


<br/>


## 프로젝트 설계


### 다이어그램

<img src="https://github.com/D0ryeon/Breaking_CyberPsycho/assets/70641418/bbae9cbc-8b07-40b5-8f55-f7036c320ea6">


<br/>
<br/>

### 패키지 구조도

<img src="https://github.com/D0ryeon/Breaking_CyberPsycho/assets/70641418/798e8e44-8ccf-4c86-ac50-51468377096b">

<br/>
<br/>

### 와이어 프레임(Figma)

<img src="https://github.com/D0ryeon/Breaking_CyberPsycho/assets/70641418/b08f475c-d50b-4bb3-a28b-6de398b9c433">

<br/>

## 문제에 대한 고민과 해결 과정


<details>
<summary>[김명식] UI 디자인 배치와 UIController 부분 구현에 대한 고민</summary>
<div markdown="1">

</div>
</details>

<details>
<summary>[임전혁] 팝업 UI 관련 로직 분리와 자동화 관련 고민</summary>
<div markdown="1">

</div>
</details>

<details>
<summary>[임전혁] 플레이어 스코어 저장 형식(ex. json, csv)과 어떻게 데이터를 가져올지에 대한 고민</summary>
<div markdown="1">

</div>
</details>

<details>
<summary>[차요한] 공과 패들 충돌 시 어떻게 게임 물리를 적용할지에 대한 고민</summary>
<div markdown="1">

- Rigidbody 2D 활용, 충돌 내장 함수 사용
- 
</div>
</details>


<details>
<summary>[차요한] 공 움직임의 일관성 문제( 느려지거나 빨라짐)</summary>
<div markdown="1">

- AddForce →velocity 으로 속도 적용방식 변경

</div>
</details>

<details>
<summary>[김준범] 사운드 매니저에 대한 구현과 어떤 사운드 데이터를 사용할 것인지에 대한 고민</summary>
<div markdown="1">

</div>
</details>


<details>
<summary>[송승훈] 다수의 블럭 오브젝트 메모리 최적화에 대한 고민</summary>
<div markdown="1">

- 메모리에 데이터 사본만을 저장하고 이를 참조하는 방식으로 작동하는 스크럽터블 오브젝트 를이용하여 해결

</div>
</details>


<details>
<summary>다수의 사용자가 하나의 씬을 수정하며 발생하는 씬 충돌</summary>
<div markdown="1">

- 따로 테스트Scene 을만들어 작업진행

</div>
</details>