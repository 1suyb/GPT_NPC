# GPT_NPC
**Unity 에서 사용자 음성을 입력으로 받아 출력으로 아바타의 응답과 행동을 생성하는 프로젝트**

### 언어 및 통신방법
- Front-end : Unity (C#)
- Back-end : Python
- 통신 : Socket

### 사용 모델
- Pre-trained model: Whisper-base
- Fine-tuning하여 사용

### API
- OpenAI API - GPT3.5 turbo

### 사용법
```
- server 폴더에 pyserver 파일의 port를 자신에 맞게 수정
- Model파일의 whisper 모델 path도 알맞게 수정

- Unity의 ServerManager 파일의 ip와 port를 자신에 맞게 수정

- server 폴더의 Run.py 실행
- Unity 게임 실행

- ws로 전진후진
- ad로 좌우회전
- 여자 케릭터(릴리) 근처에서 F키를 누르는동안 음성을 입력받음.
- F키를 누르면서 이야기하고 말이 끝나면 F키를 뗌.

- 기다리면 NPC의 반응을 확인가능.
```

### 종속성
transformer와 openai api사용으로인한 가상환경 사용권장.
필요라이브러리 : numpy, openai, transformers, torch

### 시연영상
![AI융합프로젝트영상](https://github.com/1suyb/GPT_NPC/assets/89519957/857f063d-8f8b-4532-8a02-228d4bbc5e3b)
