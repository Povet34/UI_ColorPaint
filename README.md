# UI_ColorPaint

### UI_Gradient
1. Unity UI에 Bloom 효과 넣기
2. Gradiant 넣기

### Result
![image](https://github.com/user-attachments/assets/e5fb52c2-2829-400e-8d4c-9e9665b3f723)

-----
### Palette에서 Color 선택 후, 색칠하기
1. 중간의 Palette panel에서, brush 색상 선택
2. 아래의 Paint panel에서 Image에 현재 brush의 색상으로 SetColor
3. 위의 Summation panel에서 색칠된 Paint panel에 맞게 색상 동기화
4. Summation Panel에 동기화시, AllPaint/RegionPaint mode 선택

### Result
![image](https://github.com/user-attachments/assets/dd6947d0-2151-45aa-a36f-9daef3c62c79)

-----
### Gradient Time Flow
1. Gradient를 Time에 맞게, End Color가, 서서히 Start Color로 변화하기.
2. Start/End Color가 Offset X로 계속 이동하기.

### Result
![flow](https://github.com/user-attachments/assets/27dc91a2-5442-455e-98f7-e7dff7eca14b)


### 색상을 0~1이 아니라 -1 ~ 1의 값으로 Gradient를 표현할 수 있도록 변경
![flow](https://github.com/user-attachments/assets/eebf39cf-db17-448c-b3b0-d1a0c2cf316e)



### Gradient값을 이용하여 Lerp
![image](https://github.com/user-attachments/assets/f15537ff-d8a3-439a-94e9-4a4a53967f18)
![flow](https://github.com/user-attachments/assets/7b1fb861-efb6-44b5-af94-f6e03a2f14e9)


### Sequence Group
1.  Sequence Group이란, 하나 이상의 Channel을 가지고, 특정 방향성으로 재정렬된 채널들의 그룹을 말함.
2.  


------
참고할 내용
- https://www.youtube.com/watch?v=mGd3nYXj1Oc&t=54s
- https://www.youtube.com/watch?v=OAfpDaAKVSE
- https://www.youtube.com/watch?v=S6eRVwAtfOM
- https://www.youtube.com/watch?v=O62Iio-Qvjs
