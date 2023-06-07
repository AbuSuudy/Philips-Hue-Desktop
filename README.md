# Philips Hue UWP App

Often times when I'm on my desktop and the blinding light of the screen in a darkroom is huring my eyes 👀. My phone that's able to control the philips hue light is on the opposite of my room. The simple answer would be to pick it up my phone to control my lights or just use the light switch. Nope, that would be too easy let me develop a UWP app that would allow me do this from the comfort of my Herman Miller throne 💺

https://github.com/AbuSuudy/Philips-Hue-Desktop/assets/15980314/affee508-0b9b-4101-8375-9b3b6d596040

# Set up 

In the philipsHueService.cs you would need to populate philipsHueBrigeIp with ip of you bridge which could be found on  https://discovery.meethue.com/ if it's connected on your local network. 

```c#
        private static string philipsHueBridgeIp = "";               
```
You would need to generate a username that would be used on all the endpoint you use. You could use https://{**philipsHueBridgeIp**}/debug/clip.html as playground to set up the user. Once you press the button on your bridge and call this endpoint on the playground you would get the username generated. If you need more information go to https://developers.meethue.com/develop/get-started-2/ 
  
![SuccessResponse-1](https://github.com/AbuSuudy/Philips-Hue-Desktop/assets/15980314/0c64839f-02bd-461d-bff0-87f9c02eca21)

You would populate the  philipsHueService.cs generatedUsername with the returned result.
```c#
        private static string generatedUsername = "";               
```





