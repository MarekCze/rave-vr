# Rave VR - A Beat Saber Clone Done In Unity

Link to video:
https://youtu.be/62ZXlHiN7DI

## How To Play
1. Run the exe file
2. Select "Play" from the game menu screen
3. Hit the blue and red ball objects to the beat of the song. Each object you hit increases your score by 10, the higher your combo the more points you get for each ball.
4. As of right now there is no exit functionality so the only way to leave the game is through pressing Alt + F4.

## How It Works
The game is based around one core concept - automatic beat detection. Everything expands from that:
Audiovisualizer effects, spawning game objects and the speakers on both sides of the player.

This allows for drag and drop addition of songs
to which the game instantly adapts, no further modification of the game is required to make it work with the song of your choosing.

### Getting Audio Data
Unity's built in spectrum data API reads in the song data in real time with the addition of the Blackman window function which minimizes spectral leakage.
This data is saved into an array of frequencies (can be between 64 and 8192, must be a power of 2).
In my case I have used 512 frequency bands as this gives a good balance of granularity and performance.

Array of the whole song spectrum & the function that gets the spectrum data:
![array image](https://github.com/LIT-IDM/rythm-slasher-MarekCze/blob/rave/images/512array.PNG "array")
![function image](https://github.com/LIT-IDM/rythm-slasher-MarekCze/blob/rave/images/getspectrumdata.PNG "spectrum data function")

The audio data is handled in two seperate scripts, AudioData and DelayedAudioData. There are two songs playing when the game starts, the one that plays on awake is muted and is used purely to supply the data needed for the creation of game objects that move towards the player. The delayed song is played just after the first (1.6469 seconds to be exact), that is the one the player can hear and its' data is used to calculate the visual aspects of the game. This is done to allow time for the spawned objects to travel towards the player and get within range in sync with the beat.

### Using This Data To Create The Game Environment
#### 1. Beat Detection & Spawning Game Objects
The trickiest part of this project was finding a way to detect beats. The audiovisualizers used in this game are a simple visual representation of the audio data, however getting objects to spawn requires precise detection of an audible beat, like a bass kick or drum. Simply setting a threshold after which objects are spawned does not do the trick, as a frequency can stay above a certain level for relatively long periods of time which would spawn too many objects at once, or there could be an audible beat but the overall amplitude is too low to reach the threshold. Also, if there is a lot going on in a song adjacent frequencies leak in and raise the amplitude of frequencies around them, which further adds to the inaccuracies.

I have resorted to getting a sample of the first 64 frequencies which give me flexibility with what frequency I want to use for beat detection, normalizing these frequencies to get a value between 0-1 and comparing each updated frequency with the previous one. If the difference between the two is large enough, even if the amplitude of the song is low as is often the case at the beginning of a song, then a beat is recorded and an object is spawned.

Normalizing the data:
![normalize data function](https://github.com/LIT-IDM/rythm-slasher-MarekCze/blob/rave/images/normalizespectrumsample.PNG "normalize data")

Arrays for this data:
![arrays for spectrum sample](https://github.com/LIT-IDM/rythm-slasher-MarekCze/blob/rave/images/arraysforgameobjects.PNG "arrays for spectrum sample")

Object spawn when a beat is detected:
![spawn object](https://github.com/LIT-IDM/rythm-slasher-MarekCze/blob/rave/images/spawn.PNG "spawn object")

#### 2. Visualizing The Data
There are two ways in which the player can not only hear the music, but also see it through the use of visual objects that move in sync with the beat.

The first is an array of speakers on both sides of the player. Each speaker represents a frequency band and changes size depending on the data supplied by the spectrum data API. The second is two columns of rotating squares at the end of the room the player is in. Each square represents a frequency band and changes rotation speed based on the data from the array. All these objects are instantiated through scripts at runtime:

![speakers code](https://github.com/LIT-IDM/rythm-slasher-MarekCze/blob/rave/images/speakersinstantiation.PNG "speakers")
![columns code](https://github.com/LIT-IDM/rythm-slasher-MarekCze/blob/rave/images/avinstantiation.PNG "columns")

Here are the respective functions that scale and rotate the speakers and columns:
![speakers movement](https://github.com/LIT-IDM/rythm-slasher-MarekCze/blob/rave/images/speakermovement.PNG "speakers movement")
![columns movement](https://github.com/LIT-IDM/rythm-slasher-MarekCze/blob/rave/images/avmovement.PNG "columns movement")
