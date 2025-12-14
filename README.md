# Unity Lua Level Scripting (MoonSharp)

Unity에서 **Lua 스크립트로 레벨 구성을 정의**하는 구조를 실험한 프로젝트입니다.  
C#은 엔진/오브젝트 제어를 담당하고, Lua는 **자주 바뀌는 레벨 로직**을 담당하도록 역할을 분리했습니다.

> Reference: https://www.youtube.com/watch?v=3nTGOefc1AA

---

## 핵심 아이디어

- **C#**: Unity API, GameObject 생성, 데이터 관리  
- **Lua**: 레벨 배치 규칙, 로직 정의
- Lua는 *무엇을 할지*만 결정하고, *어떻게 실행할지*는 C#이 담당

---

## 주요 구조 요약

- ScriptRunner : Lua VM 초기화 및 Unity 타입 바인딩
- InitializeLevel : Lua 레벨 스크립트 로드/실행
- LevelPieces : Lua에 노출되는 프리팹 데이터
- Editor Tool : Lua 파일 생성 메뉴 제공

---

## 장점

- Lua 수정만으로 레벨 변경 가능
- 엔진 코드와 게임 로직 분리

---

## 사용 기술

- Unity / C#
- Lua (MoonSharp)
- ScriptableObject
- Singleton
