# Room Furnisher  
Room Furnisher to zaawansowana aplikacja VR/MR stworzona w Unity 3D, która pozwala użytkownikom projektować wnętrza w wirtualnej rzeczywistości. Aplikacja wykorzystuje dane z rzeczywistego pomieszczenia do generowania jego wirtualnego modelu, który można swobodnie aranżować według własnych potrzeb i pomysłów.

![demov3](https://github.com/user-attachments/assets/2fb0b112-584e-4cf1-9b6d-52db970c333b)
![demov4](https://github.com/user-attachments/assets/0d037af4-c5d4-420d-b2ae-4e1b25383a7c)

![demov1](https://github.com/user-attachments/assets/b82718bd-f8c8-4dd4-923e-c3306c744afd)
![demov2](https://github.com/user-attachments/assets/2d4030cb-095b-45fa-8d9f-c2bc02d04960)


## Przygotowanie sprzętu  

Aby korzystać z aplikacji Room Furnisher, należy przygotować urządzenie Meta Quest 3 i połączyć je z komputerem za pomocą Oculus Link.  

### Instrukcja konfiguracji Oculus Link:  
1. **Zainstaluj aplikację Meta Quest na komputerze**  
   Pobierz aplikację Meta Quest z [oficjalnej strony Meta](https://www.meta.com/quest/setup/) i zainstaluj ją na komputerze.  

2. **Połącz Meta Quest 3 z komputerem**  
   - Użyj kabla USB-C do połączenia gogli Meta Quest 3 z komputerem;  
   - Zaakceptuj komunikat w goglach, który pyta o zezwolenie na przesyłanie danych.  

3. **Włącz Oculus Link**  
   - W menu głównym gogli wybierz opcję „Quick Settings”, a następnie kliknij ikonę „Oculus Link”;
   - Wybierz swój komputer z listy dostępnych urządzeń.  

Twoje gogle są teraz połączone z komputerem i gotowe do działania z Unity 3D.  

## Jak uruchomić aplikację w Unity 3D  

Aby uruchomić aplikację Room Furnisher w środowisku Unity 3D, wykonaj poniższe kroki:  

1. **Pobierz Unity 3D**  
   - Zainstaluj Unity 3D w wersji 2022.3.37f1 (zalecana wersja). Możesz ją pobrać z [Unity Hub](https://unity.com/download).  

2. **Sklonuj repozytorium**  
   - Sklonuj repozytorium z kodem źródłowym aplikacji;
   - Otwórz folder projektu w Unity.  

3. **Skonfiguruj projekt**  
   - Upewnij się, że w ustawieniach projektu ("Project Settings") w sekcji "XR Plug-in Management" jest włączona obsługa Oculus.  

4. **Połącz Unity z Meta Quest 3**  
   - Podłącz Meta Quest 3 do komputera i uruchom Oculus Link.  

5. **Uruchomienie aplikacji**  
Aby uruchomić aplikację na goglach VR, należy wyeksportować projekt jako plik APK. W tym celu:
   - Otwórz zakładkę Files -> Build Settings.
   - W sekcji Scenes in Build dodaj główną scenę projektu.
   - Z listy dostępnych platform wybierz Android.
   - Upewnij się, że w polu Run Device znajduje się nazwa Twojego urządzenia.
   - Na koniec kliknij przycisk Build and Run, aby wygenerować i uruchomić aplikację na podłączonych goglach VR.
