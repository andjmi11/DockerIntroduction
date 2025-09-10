# Uvod u Dcoker
## Sadržaj

1. [Šta je Docker?](#šta-je-docker)
2. [Osnovne komponente Dockera](#osnovne-komponente-dockera)
3. [Kako Docker radi?](#kako-docker-radi)
4. [Prednosti korišćenja Dockera](#prednosti-korišćenja-dockera)
5. [Primer praktične upotrebe Dockera (.NET Blazor + ASP.NET Core)](#primer-praktične-upotrebe-dockera-net-blazor--aspnet-core)
6. [Zaključak](#zaključak)

## Šta je Docker?

Docker je platforma otvorenog koda koja omogućava programerima da automatizuju proces razvijanja, isporuke i pokretanja aplikacija unutar kontejnera. Kontejneri su lagaai, prenosiva i izolovana okruženja koja sadrže sve potrebne komponente za rad aplikacije, uključujući kod, biblioteke, zavisnosti i sistemske alate. To znači da aplikacija pokrenuta u Docker kontejneru radi isto bez obzira na okruženje – lokalni računar, serverski klaster ili cloud.
---

### Osnovna ideja Docker-a

Tradicionalno, aplikacije su se razvijale direktno na operativnom sistemu ili u virtualnim mašinama. To je često dovodilo do problema kao što su:
- Različite verzije biblioteka ili kernela sistema između okruženja (developerov računar, testni server, produkcija)
- Velika potrošnja resursa kod virtualnih mašina, jer svaka VM zahteva kompletan OS
- Teškoće u skaliranju i automatskom raspoređivanju aplikacija

Docker rešava ove probleme tako što koristi kontejnere, koji:
- **Izoluju aplikaciju i njene zavisnosti** – svaka aplikacija radi u sopstvenom kontejneru bez konflikta sa drugim aplikacijama
- **Deljenje resursa operativnog sistema** – svi kontejneri dele isti OS kernel, što štedi memoriju i CPU
- **Prenosivost i doslednost** – kontejneri rade identično na bilo kom sistemu gde je instaliran Docker

---

### Kratka istorija Docker-a
Docker je nastao **2013. godine** u kompaniji dotCloud (kasnije Docker, Inc.) kao projekat otvorenog koda. Njegov razvoj je inspirisan postojećim tehnologijama virtualizacije i Linux kontejnerima (LXC). Cilj je bio da se pojednostavi proces distribucije aplikacija i eliminiše problem **„radi kod mene“** – kada aplikacija radi na jednom računaru, ali ne i na drugom.

Od tada, Docker je postao standard u svetu **DevOps-a**, cloud infrastrukture i mikroservisne arhitekture, i njegova upotreba se širi u svim industrijama koje koriste softver.

---

### Docker vs. tradicionalna virtualizacija

| Karakteristika | Virtualna mašina (VM) | Docker kontejner |
|----------------|----------------------|-----------------|
| OS             | Svaka VM ima svoj OS  | Deli OS kernel sa host-om |
| Veličina       | Teške, zahtevaju gigabajte | Lagane, često samo stotine MB |
| Startovanje    | Sporo, nekoliko minuta | Brzo, često u sekundama |
| Izolacija      | Potpuna izolacija    | Izolacija aplikacije |
| Prenosivost    | Teža za prenos       | Veoma prenosivi i dosledni |

---

Docker je **revolucionarna tehnologija** koja pojednostavljuje razvoj, testiranje i implementaciju aplikacija. Njegova snaga leži u kontejnerskoj tehnologiji koja omogućava:
- Bržu isporuku softvera  
- Bolju upotrebu resursa  
- Veću fleksibilnost u radu sa različitim okruženjima
  
## Osnovne komponente Dockera

Docker kao platforma se sastoji od nekoliko ključnih komponenti koje zajedno omogućavaju razvoj, distribuciju i pokretanje aplikacija unutar kontejnera. Razumevanje ovih komponenti je ključno za efikasno korišćenje Dockera.

---

### 1. Docker Engine

Docker Engine je **srce Docker platforme**. To je klijent-server aplikacija koja omogućava kreiranje i upravljanje kontejnerima. Sastoji se od tri glavna dela:
- **Docker Daemon (dockerd)** – radi u pozadini i upravlja Docker objektima poput kontejnera, imidža, mreža i volumena. Komunicira sa Docker API-jem i izvršava komande.  
- **Docker Client (docker CLI)** – korisnički interfejs kroz koji korisnici unose komande, npr. `docker run`, `docker build`, `docker ps`.  
- **REST API** – omogućava komunikaciju između Docker klijenta i daemona, kao i integraciju sa spoljnim aplikacijama ili alatima.

Docker Engine je dostupan na **Linux**, **Windows** i **macOS** sistemima i omogućava dosledno pokretanje kontejnera na različitim platformama.

---

### 2. Docker Images (Imidži)

Docker imidž je statički, nepromenljiv fajl koji sadrži sve potrebne komponente za pokretanje aplikacije – kod, biblioteke, zavisnosti i konfiguraciju.

**Karakteristike Docker imidža:**
- **Slojeviti sistem** – svaki imidž se sastoji od slojeva, što omogućava efikasno skladištenje i deljenje.  
- **Prenosivost** – imidž se može preuzeti na bilo koji sistem sa Dockerom i odmah pokrenuti.  
- **Nezavisnost od host sistema** – aplikacija unutar imidža radi isto bez obzira na okruženje.

**Primer korišćenja:**

```bash
docker pull nginx
docker run -d -p 80:80 nginx
```
Ovim komandama preuzimamo zvanični imidž web servera Nginx i pokrećemo ga u kontejneru.

### 3. Docker Containers (Kontejneri)

Docker kontejner je pokrenuti instanca Docker imidža. Dok je imidž statičan, kontejner je dinamičan i omogućava izvršavanje aplikacije.

Karakteristike kontejnera:
- **Izolacija** – kontejneri rade izolovano jedni od drugih, što smanjuje konflikte između aplikacija.
- **Brzo pokretanje** – kontejneri se startuju gotovo instantno jer koriste kernel host sistema.
- **Privremenost** – kontejneri se mogu kreirati, koristiti i brisati bez uticaja na host sistem.

Primer:

```bash
docker ps      # Prikazuje aktivne kontejnere
docker stop <container_id>  # Zaustavlja kontejner
docker rm <container_id>    # Briše kontejner
```

### 4. Docker Hub

Docker Hub je zvanični cloud repozitorijum za deljenje Docker imidža. Omogućava korisnicima:
- Preuzimanje zvaničnih i korisničkih imidža (docker pull).
- Postavljanje svojih imidža i njihovo deljenje sa zajednicom (docker push).
- Praćenje verzija imidža i automatizaciju build procesa.
  
Korišćenje Docker Huba omogućava programerima da brzo započnu projekte bez potrebe da kreiraju sve imidže od nule, što značajno ubrzava razvoj softvera.

Osnovne komponente Dockera – Docker Engine, imidži, kontejneri i Docker Hub – zajedno čine moćan ekosistem za razvoj i isporuku aplikacija. Razumevanje svake od ovih komponenti je ključno za efikasno korišćenje Dockera, kako u manjim projektima, tako i u velikim produkcionim okruženjima.

Razumevanje Docker-a je ključni korak za svakog programera ili DevOps inženjera koji želi da radi sa modernim softverskim arhitekturama.

## Kako Docker radi?

Docker omogućava aplikacijama da se pokreću u **izolovanim, laganim kontejnerima**. Za razliku od tradicionalnih virtualnih mašina, Docker kontejneri ne emuliraju ceo operativni sistem, već koriste **kernel host sistema** i sadrže samo ono što je potrebno za rad aplikacije. Ovo omogućava:
- Brže pokretanje  
- Manju potrošnju resursa  
- Jednostavnu prenosivost aplikacija između različitih okruženja
  ### Dockerfile – recept za kontejner

**Dockerfile** je tekstualni fajl koji definiše kako se gradi Docker imidž. On opisuje:
- Koje komponente uključiti  
- Kako konfigurisati aplikaciju  
- Koje komande izvršiti  

**Primer jednostavnog Dockerfile-a za .NET  aplikaciju:**

```dockerfile
# Bazni imidž sa .NET 7 SDK za build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Postavljanje radnog direktorijuma
WORKDIR /app

# Kopiranje csproj i restore zavisnosti
COPY *.csproj ./
RUN dotnet restore

# Kopiranje ostatka koda i build aplikacije
COPY . ./
RUN dotnet publish -c Release -o out

# Bazni imidž za runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Komanda koja se izvršava kada se kontejner pokrene
ENTRYPOINT ["dotnet", "MojaAplikacija.dll"]
```
Ovaj fajl definiše sve što je potrebno da aplikacija radi u izolovanom kontejneru.

### Osnovne Docker komande za .NET aplikacije

**Kreiranje imidža iz Dockerfile-a**

``` bash
docker build -t moja-dotnet-aplikacija .
```

**Pokretanje kontejnera iz imidža**
```bash
docker run -d -p 5000:80 moja-dotnet-aplikacija
```

**Prikaz aktivnih kontejnera**
```bach
docker ps
```

**Zaustavljanje i brisanje kontejnera**

```bash
docker stop <container_id>
docker rm <container_id>
```

**Preuzimanje i postavljanje imidža na Docker Hub**

```bash
docker pull mcr.microsoft.com/dotnet/aspnet:7.0
docker push moja-dotnet-aplikacija
```

### Kako sve funkcioniše zajedno?

- Programer kreira .NET aplikaciju i napiše Dockerfile.
- Komandom docker build se kreira Docker imidž.
- Imidž se može pokrenuti kao kontejner na lokalnom računaru ili serveru.
- Kontejner je izolovan i sadrži sve zavisnosti aplikacije.
- Ako je potrebno, imidž se može postaviti na Docker Hub i koristiti na drugim sistemima bez dodatne konfiguracije.

Ovim pristupom Docker omogućava jednostavnu i brzu isporuku .NET aplikacija, eliminišući probleme povezane sa različitim okruženjima i konfiguracijama.

## Prednosti korišćenja Dockera

Docker je postao standard u razvoju softvera i DevOps praksama zahvaljujući svojim brojnim prednostima u odnosu na tradicionalne metode distribucije i pokretanja aplikacija.

---

### 1. Brža implementacija i testiranje aplikacija

Jedna od najvećih prednosti Dockera je **brzina pokretanja kontejnera**. Za razliku od virtualnih mašina, koje zahtevaju pokretanje celog operativnog sistema, Docker kontejneri startuju u sekundama jer koriste kernel host sistema.

**Primer:**

- Pokretanje lokalnog web servera u Docker kontejneru traje samo nekoliko sekundi.  
- Programeri mogu brzo testirati kod i integrisati ga u veće sisteme.

---

### 2. Prenosivost i doslednost okruženja

Docker kontejneri sadrže sve potrebne zavisnosti aplikacije, što znači da aplikacija radi identično na različitim okruženjima – lokalni računar, testni server ili cloud platforma.

**Praktičan primer:**

- Ako aplikacija radi na developerovom računaru u Docker kontejneru, ista konfiguracija se može odmah pokrenuti na serveru bez dodatnog podešavanja.  
- Ovo eliminiše problem **„radi kod mene, ali ne radi na serveru“**.

---

### 3. Efikasno korišćenje resursa

Kontejneri dele kernel host sistema i koriste samo potrebne resurse, što ih čini znatno lakšim od virtualnih mašina.

**Primer:**

- Na jednom serveru mogu istovremeno raditi desetine kontejnera, dok bi isti broj VM zahtevao znatno više memorije i procesorske snage.

---

### 4. Skalabilnost i automatizacija

Docker se lako integriše sa alatima za orkestraciju kao što su **Kubernetes** i **Docker Swarm**, što omogućava:

- Automatsko skaliranje aplikacija prema opterećenju  
- Upravljanje stotinama ili hiljadama kontejnera u produkcionom okruženju  
- Jednostavno kreiranje i raspoređivanje mikroservisnih arhitektura

---

### 5. Bolja izolacija i sigurnost

Kontejneri omogućavaju izolaciju aplikacija i njihovih zavisnosti:

- Problemi u jednom kontejneru ne utiču na druge aplikacije  
- Moguće je ograničiti resurse (CPU, memorija) koje kontejner koristi  
- Ovo povećava sigurnost i stabilnost sistema

---

### 6. Jednostavno verzionisanje i deljenje

Docker imidži omogućavaju **verzionisanje aplikacija**:

- Svaka promena koda ili konfiguracije može biti sačuvana kao nova verzija imidža  
- Programeri mogu brzo vratiti staru verziju aplikacije ako dođe do greške  
- Imidži se lako dele preko Docker Huba ili privatnih repozitorijuma, što olakšava timski rad

---
Prednosti Dockera se ogledaju u **brzini, efikasnosti, prenosivosti, izolaciji i skalabilnosti**. Zahvaljujući ovim karakteristikama, Docker je postao ključni alat u modernom razvoju softvera, posebno u okruženjima koja koriste **mikroservise, cloud infrastrukturu i DevOps prakse**.

## Primer praktične upotrebe Dockera (.NET Blazor + ASP.NET Core)

U ovom primeru prikazujemo kako se **.NET aplikacija** sastavljena od Blazor frontend-a i ASP.NET Core backend-a može kontejnerizovati u dva odvojena Docker Compose projekta, dok oba servisa dele zajedničku mrežu.

---

### 1. Struktura projekta

- **BlogAPI** – ASP.NET Core Web API koji komunicira sa SQL Server bazom  
- **BlogApp** – Blazor aplikacija koja koristi API  
- **SQL Server** – baza podataka za backend API  
- **Mreža `blog-network`** – omogućava međusobnu komunikaciju kontejnera iz različitih Compose projekata  

---

### 2. Dockerfile za BlogAPI

Dockerfile koristi **multi-stage build** strategiju:

- **Base stage** – `mcr.microsoft.com/dotnet/aspnet:9.0` runtime  
- **Build stage** – SDK za build i restore zavisnosti  
- **Publish stage** – optimizuje aplikaciju za produkciju  
- **Final stage** – kopira publishovane fajlove i pokreće aplikaciju  

**Ključne komande:**
```dockerfile
COPY ["/BlogAPI.csproj", "./"]
RUN dotnet restore "./BlogAPI.csproj"
RUN dotnet build "./BlogAPI.csproj" -c Release -o /app/build
RUN dotnet publish "./BlogAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false
ENTRYPOINT ["dotnet", "BlogAPI.dll"]
```
Kontejner izlaže port 8080, mapiran na host port 9090
Servis koristi mrežu blog-network za komunikaciju sa drugim kontejnerima

### 3. Dockerfile za BlogApp

BlogApp takođe koristi multi-stage build:
**Build stage** – SDK za kompilaciju i publish
**Final stage** – ASP.NET runtime za pokretanje Blazor aplikacije

**Ključne komande:**

```dockerfile
COPY ["/BlogApp.csproj", "./"]
RUN dotnet restore "./BlogApp.csproj"
RUN dotnet build "./BlogApp.csproj" -c Release -o /app/build
RUN dotnet publish "./BlogApp.csproj" -c Release -o /app/publish /p:UseAppHost=false
ENTRYPOINT ["dotnet", "BlogApp.dll"]
```
Kontejner izlaže port 8080, mapiran na host port 8081
Koristi environment varijablu API_URL=http://blogapi:8080 da poveže frontend sa backend API-jem preko mreže blog-network

### 4.Docker Compose za BlogAPI (docker-compose-api.yml)
```docker-compose
services:
  sqlserver:
    image: mcr.microsoft.com/mssql/server:2022-latest
    container_name: sqlserver
    environment:
      SA_PASSWORD: "YourStrong!Passw0rd"
      ACCEPT_EULA: "Y"
    ports:
      - "1433:1433"

  blogapi:
    container_name: blogapi
    build:
      context: ./BlogAPI
      dockerfile: Dockerfile
    ports:
      - "9090:8080"
    depends_on:
      - sqlserver
    environment:
      - ASPNETCORE_ENVIRONMENT=Development

networks:
  default:
    external: true
    name: blog-network
```
- depends_on osigurava da SQL Server startuje pre API-ja
- Servis deli mrežu sa BlogApp kontejnerom

### 5. Docker Compose za BlogApp (docker-compose-app.yml)
```docker-compose
services:
  blogapp:
    container_name: blogapp
    build:
      context: ./BlogApp
      dockerfile: Dockerfile
    ports:
      - "8081:8080"
    environment:
      - API_URL=http://blogapi:8080
      - ASPNETCORE_ENVIRONMENT=Development

networks:
  default:
    external: true
    name: blog-network
```
- BlogApp koristi istu mrežu blog-network, što omogućava da API bude dostupan po imenu kontejnera blogapi
- Odvojeni Compose projekat omogućava frontend da se razvija i deploy-uje nezavisno od backend-a

### 6. Pokretanje servisa
**Kreirajte eksternu mrežu (ako već nije):**
```bash
docker network create blog-network
```
**Pokrenite backend i bazu podataka:**
```bash
docker-compose -f docker-compose-api.yml up --build
```
**Pokrenite frontend:**
```bash
docker-compose -f docker-compose-app.yml up --build
```
**Nakon startovanja:**
Backend API: http://localhost:9090
Blazor frontend: http://localhost:8081
Frontend automatski komunicira sa API-jem koristeći API_URL i mrežu blog-network.

### 7. Prednosti ovog pristupa

Odvojeni projekti – Frontend i backend se mogu razvijati i deploy-ovati nezavisno
Zajednička mreža – Omogućava komunikaciju između kontejnera iz različitih Compose projekata
Prenosivost i izolacija – Svaki servis radi u svom kontejneru, bez konflikata sa drugim aplikacijama
Fleksibilnost – Moguće je koristiti različite konfiguracije, testirati frontend bez pokretanja backend-a lokalno i obrnuto

## Zaključak

Docker predstavlja moćan alat u modernom razvoju softvera, omogućavajući razvoj, testiranje i implementaciju aplikacija u **izolovanim i laganim kontejnerima**.  

Kroz praktični primer **Blazor frontend-a** i **ASP.NET Core backend-a**, demonstrirano je kako se različiti servisi mogu kontejnerizovati i povezati pomoću **Docker Compose-a**, a da pri tome ostanu potpuno nezavisni.

---

### Ključne prednosti Dockera

Jedna od najvažnijih prednosti je **nezavisnost kontejnera**. Svaki kontejner sadrži sve potrebne zavisnosti za rad aplikacije i može da se koristi samostalno ili u kombinaciji sa drugim aplikacijama. To omogućava:

- Jednostavno testiranje i razvoj pojedinačnih servisa  
- Ponovno korišćenje kontejnera u drugim projektima bez dodatnih konfiguracija  
- Brzu implementaciju i skaliranje aplikacija u različitim okruženjima, uključujući lokalni razvoj, testne servere i cloud  

---

### Fleksibilnost u praktičnom primeru

U našem primeru:

- **BlogAPI** i **BlogApp** rade kao odvojeni Docker Compose projekti  
- Oba servisa dele zajedničku mrežu `blog-network`, što omogućava međusobnu komunikaciju  
- Svaki servis i dalje može da se koristi nezavisno, što predstavlja fleksibilan pristup u razvoju modernih softverskih arhitektura  

---
Docker kontejneri omogućavaju:

- Bržu i efikasniju isporuku softvera  
- Smanjenje problema sa različitim okruženjima  
- Povećanu održivost i sigurnost aplikacija  

Njihova **prenosivost i izolacija** čine ih nezamenljivim alatom za timove koji razvijaju **mikroservise**, **cloud aplikacije** ili aplikacije koje zahtevaju **kontinuiranu integraciju i isporuku**.  

Zaključno, Docker ne samo da pojednostavljuje tehnički aspekt razvoja aplikacija, već i značajno doprinosi **produktivnosti, fleksibilnosti i skalabilnosti** softverskih rešenja, što ga čini ključnom tehnologijom u modernom IT ekosistemu.
