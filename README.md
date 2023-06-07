# Philips Hue Desktop

<p align="center">
<img alt="Square44x44Logo altform-unplated_targetsize-256" src="https://github.com/AbuSuudy/Philips-Hue-Desktop/assets/15980314/24557688-10ec-495b-b963-fbb96cb6f7e3">


</p>
Often times when I'm on my desktop and the blinding lights of the screen in a darkroom is hurting my eyes 👀. My phone that's able to control the Philips hue light is on the opposite of my room. The simple answer would be to pick up my phone to control my lights or just use the light switch. Nope, that would be too easy so let me develop a desktop application app that uses the Philips hue API so it would allow me do this from the comfort of my Herman Miller throne 💺 <br> <br>  <br> 

https://github.com/AbuSuudy/Philips-Hue-Desktop/assets/15980314/65f0c5a0-5c06-4943-882b-248eaf0453ff

## Set up 
In the philipsHueService.cs you would need to populate philipsHueBrigeIp with ip of you bridge which could be found on  https://discovery.meethue.com/ if it's connected on your local network. 

```c#
        private static string philipsHueBridgeIp = "";               
```
You would need to generate a username that would be used on all the endpoint you use. You could use https://{**philipsHueBridgeIp**}/debug/clip.html as playground to set up the user. Once you press the button on your bridge and call the endpoint below on the playground you would get the username generated. <br> <br> 

![SuccessResponse-1](https://github.com/AbuSuudy/Philips-Hue-Desktop/assets/15980314/5a68e67f-b12b-452c-88a1-6760908fa1aa)


You would populate the  philipsHueService.cs generatedUsername with the returned result.  If you need more information go to https://developers.meethue.com/develop/get-started-2/ 

```c#
        private static string generatedUsername = "";               
```

## Patterns used
Model-View-ViewModel (MVVM) is a UI architectural design pattern for decoupling UI and non-UI code. With MVVM, you define your UI declaratively in XAML and use data binding markup to link it to other layers containing data and commands. The data binding infrastructure provides a loose coupling that keeps the UI and the linked data synchronized and routes user input to the appropriate commands.

When using the MVVM pattern, an app is divided into the following layers:

* The model layer defines the types that represent your business data. 
* The view layer defines the UI using XAML markup. 
* The view-model layer provides data binding targets for the view.  <br> <br>

## Kelvin to RGB background 
The algorithm used to change the background colour by mapping Kelvin values to RGB values could be found here https://tannerhelland.com/2012/09/18/convert-temperature-rgb-algorithm-code.html 

