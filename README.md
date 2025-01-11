# Room Furnisher  
Room Furnisher to zaawansowana aplikacja VR/MR stworzona w Unity 3D, która pozwala użytkownikom projektować wnętrza w wirtualnej rzeczywistości. Aplikacja wykorzystuje dane z rzeczywistego pomieszczenia do generowania jego wirtualnego modelu, który można swobodnie aranżować według własnych potrzeb i pomysłów.

## Przygotowanie sprzętu  

Aby korzystać z aplikacji Room Furnisher, należy przygotować urządzenie Meta Quest 3 i połączyć je z komputerem za pomocą Oculus Link.  

### Instrukcja konfiguracji Oculus Link:  
1. **Zainstaluj aplikację Meta Quest na komputerze**  
   Pobierz aplikację Meta Quest z [oficjalnej strony Meta](https://www.meta.com/quest/setup/) i zainstaluj ją na komputerze.  

2. **Połącz Meta Quest 3 z komputerem**  
   - Użyj kabla USB-C do połączenia gogli Meta Quest 3 z komputerem.  
   - Zaakceptuj komunikat w goglach, który pyta o zezwolenie na przesyłanie danych.  

3. **Włącz Oculus Link**  
   - W menu głównym gogli wybierz opcję „Quick Settings” (Szybkie ustawienia), a następnie kliknij ikonę „Oculus Link”.  
   - Wybierz swój komputer z listy dostępnych urządzeń.  

Twoje gogle są teraz połączone z komputerem i gotowe do działania z Unity 3D.  

## Jak uruchomić aplikację w Unity 3D  

Aby uruchomić aplikację Room Furnisher w środowisku Unity 3D, wykonaj poniższe kroki:  

1. **Pobierz Unity 3D**  
   - Zainstaluj Unity 3D w wersji 2022.3.37f1 (zalecana wersja). Możesz ją pobrać z [Unity Hub](https://unity.com/download).  

2. **Sklonuj repozytorium**  
   - Sklonuj repozytorium z kodem źródłowym aplikacji,
   - Otwórz folder projektu w Unity.  

3. **Skonfiguruj projekt**  
   - Upewnij się, że w ustawieniach projektu ("Project Settings") w sekcji "XR Plug-in Management" jest włączona obsługa Oculus.  
   - W zakładce "Player Settings" skonfiguruj opcję „Virtual Reality Supported”.

4. **Połącz Unity z Meta Quest 3**  
   - Podłącz Meta Quest 3 do komputera i uruchom Oculus Link.  

5. **Uruchomienie aplikacji**  
   - Aby uruchomić aplikację w goglach VR należy wyeksportuj projekt jako aplikację APK. Aby stworzyć build należy wejść w zakładkę "Files -> Build Settings". Następnie wybrać główną scenę w sekcji "Scenes in Build". Z listy dostępnych platform wybrać "Android". Przed uruchomieniem aplikacji przyciskiem "Build and Run", upewnij się, że w polu "Run Device" znajduje się nazwa twojego urządzenia.
