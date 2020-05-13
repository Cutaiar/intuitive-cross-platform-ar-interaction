# Intuitive Cross Platform Interaction in Augmented Reality
In spring of 2020, this research was conducted by Dillon Cutaiar to generate example code and documentation for the 'pull out of screen' interaction pattern in augmented reailty. This interaction technique can be seen [here](https://twitter.com/ptcrealitylab/status/1154375767956119554?lang=en), whos paper can be found [here](https://dl.acm.org/doi/10.1145/3306449.3328812).

This project is a replication of the results discussed in that paper. I use ARFoundation with ARKit under the hood for AR, Normcore to handle network communications, a custom shader to clip the object as it appears to pass though the computer screen, and custom object manipulation code to allow the user to move the object. Once the user has pulled the object out of the screen, they can apply physics which casues it to fall to surface below it -- usually a keyboard.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine. 

### Download
Just clone this repo and open with the Unity verison found in `ProjectVersion.txt`.

### Building & Testing
Build the project to iOS using XCode. Remember, we're using Normcore so we have to remember to add `libz.tbd` to the Link with Libraries section in the Build Phases of the Unity Platform Target.

## How it Works

## Future Work

## Credit

### Models

Suzanne from blener

### Marker
Amazing optimized tracker generator from @evryone_XR
https://codepen.io/staus/full/oEOJpq

### Icons
<div>Icons made by <a href="https://www.flaticon.com/authors/freepik" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>

Icons made by <a href="https://www.flaticon.com/authors/smashicons" title="Smashicons">Smashicons</a> from <a href="https://www.flaticon.com/" title="Flaticon"> www.flaticon.com</a>