## 🧑‍💼 OutOfWork
Unity 숙련 주차 팀프로젝트 4라가기 힘들조의 팀프로젝트 입니다.

## 💁‍♂️ 소개
### 제한 시간안에 퇴근을 막는 로봇들을 물리치고 1층에 도달하여 퇴근에 성공하자

## ⏰ 개발 기간
- 24.02.08 ~ 24.02.16

## 👨‍👨‍👧‍👦 멤버
- 송상화(팀장) : GameManager
- 김유원 : SkllTree, Sound
- 김상민 : UI
- 신채윤 : Unit , MainStage

## 💻 개발 환경
- Engine : Unity 2022.3.2f1
- Language : C#

## 📑 구성
### StartScene
![image](https://github.com/Amberjack10/OutOfWork/assets/154484912/c84d206f-bca4-454a-b528-92a894f382d4)
-------
### LoadingScene
![image](https://github.com/Amberjack10/OutOfWork/assets/154484912/1ac44d43-8aa7-47c7-91c0-38b904140570)
-------
### SelectStageScene
![image](https://github.com/Amberjack10/OutOfWork/assets/154484912/cecbea48-190d-417c-91af-f3bc9abfebe2)
-------
### SkillTreeScene
![image](https://github.com/Amberjack10/OutOfWork/assets/154484912/c41e2aa0-f025-4537-906d-324f198038ae)
-------
### MainStageScene
![image](https://github.com/Amberjack10/OutOfWork/assets/154484912/a4e65285-7ad6-4fd8-935e-c3d6c6979093)
-------
### EndingScene
![image](https://github.com/Amberjack10/OutOfWork/assets/154484912/6eeac099-8b05-44e0-a8ad-dc910f64e94a)
-------
## 구현사항
#### 1. 게임 맵 생성 및 배치
- Timlemap을 사용하여 게임 맵을 생성하고, 맵 경로를 지정하여 적들과 플레이어 유닛의 이동경로를 설정합니다.
#### 2. 플레이어 유닛 생성 버튼
- 플레이어 유닛을 만들고, 플레이어가 버튼을 생성하면 플레이어 유닛이 지정된 위치에 스폰이 되어 엘리베이터를 향해 나아갑니다.
#### 3. 적의 움직임과 스폰
- 적 캐릭터 오브젝트를 만들고 경로를 따라 이동시키는 로직을 구현했습니다. 일정한 시간 간격에 따라 적을 스폰하고 난이도 별 등장하는 적 유닛의 개체수, 종류가 달라집니다.
#### 4. 플레이어의 스킬
- 플레이어가 배울 수 있는 스킬이 있습니다. 스킬은 클리어시 얻는 재화로 지정된 트리에 따라 강화할 수 있습니다.
#### 5. 적과 플레이어 유닛의 체력 및 공격력
- 등장하는 적, 플레이어 유닛의 공격력을 지정하고 데미지 계산 및 체력 감소 로직을 구현했습니다.
#### 6. 자원 관리
- MainStage에서 플레이어는 일정 간격으로 Gold를 얻거나 적 유닛을 처치하면 소량의 Gold를 얻게됩니다. 획득한 Gold는 플레이어 유닛을 생성하는 Cost로 활용됩니다.
- 게임 클리어시 플레이어는 리워드로 스킬강화코인을 얻게됩니다. 플레이어는 코인을 소모하여 자신의 스킬을 좀 더 강력하게 업그레이드 시킬 수 있습니다.
#### 7. 게임 진행 상태 표시
- MainStage에서 플레이어는 자신에게 남은 시간 획득한 Gold 엘리베이터 체력을 화면의 상단에 위치해 있는 UI로 확인할 수 있습니다.
#### 8. 게임 오버 및 승리 조건
- OutofWalk의 스테이지 클리어 조건은 엘리베이터 체력을 모두 닳게하여 엘리베이터 문을 열면 클리어하게 됩니다.
- OutofWalk의 게임오버 조건은 화면 상단의 제한시간이 0초가 되게되면 게임오버가 됩니다.
#### 9. 엔딩
- Player가 1층을 클리어하여 퇴근에 성공하게 되면 EndingScene으로 넘어가게 되며 전체적으로 게임이 종료되게 됩니다.
## 🖌️ 와이어프레임
![image](https://github.com/Amberjack10/OutOfWork/assets/154484912/a9d3460e-974e-44cf-809c-1976d5232781)

## 🪄 Asset
#### 사용 에셋 및 이미지 :
- Penusbmic https://itch.io/s/115069/sci-fi-tiny-alchemist-more-bundle
- zneeke https://zneeke.itch.io/
- gabry https://gabry-corti.itch.io/plague-crow
- Pupkin https://trevor-pupkin.itch.io/tech-dungeon-roguelite
- https://bdragon1727.itch.io/free-smoke-fx-pixel-2 (효과 이펙트)
- https://bdragon1727.itch.io/retro-impact-effect-pack-5 (효과 이펙트)
- https://assetstore.unity.com/packages/templates/tutorials/2d-roguelike-29825 (폰트만 따로 사용)
- https://assetstore.unity.com/packages/2d/gui/icons/2d-simple-ui-pack-218050
- https://kenney-assets.itch.io/rpg-urban-kit (배경 타일 사용)
- https://assetstore.unity.com/packages/2d/environments/free-2d-adventure-beach-background-82090(StartScene BackGround로 사용)
- https://assetstore.unity.com/packages/2d/gui/icons/simple-free-pixel-art-styled-ui-pack-165012
- https://kor.pngtree.com/freepng/elevator-door-with-up-and-down-button_8619899.html(엘리베이터 이미지)
- https://opengameart.org/content/ui-sound-effects-pack (Some of the sounds in this project were created by David McKee (ViRiX)
[soundcloud.com/virix](http://soundcloud.com/virix) 크레딧 입력 필요)
- https://www.pinterest.co.kr/pin/992691942836188889/ (엔딩 배경 이미지)




