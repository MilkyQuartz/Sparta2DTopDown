# Sparta TopDown 2D Game
## 과제개요
#### 1. Unity 를 이용해 ZEP과 같은 시점의 게임을 모방해 만드는 과제입니다.
#### 2. 타일맵을 이용해 배경을 꾸밉니다.
#### 3. 기본 UI 들을 활용해 적용하는 연습이 포함됩니다.
## 기능소개
### 필수요구사항
    1. 캐릭터 만들기
       - 한가지 이상의 캐릭터를 선택하여 캐릭터를 선택합니다.
       - Join을 하면 플레이어 프리팹스에 이름과 캐릭터 프리팹이름이 저장됩니다.
       - 선택하지 않을 시 Join X
        
    2. 캐릭터 이동
       - 키보드 A/W/S/D 를 이용하여 캐릭터가 움직입니다.
       - 캐릭터는 상하좌우(대각방향은 이동은 하지만 애니메이션은 Up, Down) 애니메이션을 통해 보는 방향을 정할 수 있습니다.
       - 현재 마우스로 보는 방향 전환은 잠깐 주석처리 해뒀습니다. (관련 기능이 없기때문에)
        
    3. 방 만들기    
       - 키보드 A/W/S/D 를 이용하여 캐릭터가 움직입니다.
            
    4. 카메라 따라가기
       - 카메라는 움직임에 따라 캐릭터를 따라갑니다.
        
    5. 캐릭터 애니메이션 추가
       - 실행하면 캐릭터가 애니메이션을 반복합니다.
       - 가만히 서있을때와 움직일때 애니메이션
        
    6. 이름 입력 시스템
       - 실행시 글자를 입력을 받을 수 있는 UI 를 만듭니다.
            - 2~10 글자 사이
                - 아니라면 Join 버튼이 눌리지 않습니다.
       - Join 을 누르면 맵으로 이동하여 캐릭터 위에 이름표가 나타납니다.
            - 이름표는 캐릭터가 움직이면 따라 다닙니다.
            
    7. 캐릭터 선택 시스템
       - 맵으로 들어가기 전 캐릭터가 표시되는 UI 가 나타납니다.
       - 캐릭터를 클릭하면 캐릭터 선택 팝업이 나타납니다.
       - 캐릭터를 선택하면 팝업이 닫힙니다.
       - 선택했던 캐릭터가 표시됩니다.
     
### 선택요구사항
    1. 시간 표시
       - 참석인원 UI 하단에 시간을 볼 수 있는 텍스트가 표시됩니다.
    
    2. 인게임 이름 바꾸기
        - 환경설정창에서 변경가능합니다.  
        - 입력하면 캐릭터 프리팹스에 저장된 이름이 바뀌면서 캐릭터 머리위에 붙어있는 이름이 바뀌게됩니다.
        
    3. 참석 인원 UI
       - UI 는 캐릭터가 움직여도 화면에 고정됩니다.
       - 화면 왼쪽에 스크롤뷰로 현재 맵에 있는 사람의 목록을 보여줍니다.
           - NPC 를 더 추가한다면 이 목록에 이름이 추가됩니다. (NPC태그를 달고있어야함)
           - x 버튼을 누르면 UI 가 꺼집니다.
           
    4. 인게임 캐릭터 선택 
           - 환경설정창에서 변경가능합니다.      
           - 캐릭터 선택시 게임화면의 캐릭터가 바로 반영 됩니다.

## 실행 화면
- 이미지 클릭시 구현 영상으로 이동합니다.
  
[![Main](https://github.com/MilkyQuartz/Sparta2DTopDown/assets/141620531/e9edfe3a-3678-4c70-8f1e-6e6de238ed27)](https://youtu.be/Lqt-DijFhXo)
