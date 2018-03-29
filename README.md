# Projet REST and SOAP WS Lab

### Alexis Deslandes

#### 1 - MVP of the project

Le MVP du projet est accessible dans la solution "**SOAP_VELIB**",
au nom de "**Client**" pour le client Console et au nom de "**SOAP_VELIB**" pour le web
service intermédiaire qui communique avec le Web service.

### 2 - Choose your extensions

J'ai décidé de prendre les extensions "**Graphical User Interface for the client**",
laquelle est accessible par le biais du projet "**Client_graphique**", ainsi que
l'extension "**Monitoring**", laquelle est accessible par "**Monitoring_Client**"
pour la partie client et affichage de chart pour le Monitoring.

Il y a également des **modifications** sur le **Web service intermédiaire** avec cette extension
(création d'une interface et une classe de plus pour gérer les requêtes des clients
sur la partie Monitoring).

### 3 - Step to test

- Importer la solution "**SOAP_VELIB.sln**" depuis **Visual Studio**.
- Click droit sur le projet "**SOAP_VELIB**", "**Deboguer**","**Démarrer une nouvelle instance**",
vous venez de lancer le Web Service intermédiaire.
- Click droit sur le projet "**Client**", "**Deboguer**","**Démarrer une nouvelle instance**",
vous avez maintenant une console ouverte pour discuter avec le Web service intermédiaire.
- Click droit sur le projet "**Client_graphique**", "**Deboguer**","**Démarrer une nouvelle instance**", vous venez de lancer le client graphique pour discuter avec le Web service intermédiaire.
- Click droit sur le projet "**Monitoring_Client**", "**Deboguer**","**Démarrer une nouvelle instance**", vous venez de lancer le client graphique responsable de l'étude du monitoring sur le serveur.
