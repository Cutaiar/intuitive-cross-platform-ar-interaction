# Intuitive Cross Platform Interaction in Augmented Reality
In spring of 2020, this research was conducted by Dillon Cutaiar to generate example code and documentation for the 'pull out of screen' interaction pattern in augmented reailty. This interaction technique can be seen [here](https://twitter.com/ptcrealitylab/status/1154375767956119554?lang=en), whos paper can be found [here](https://dl.acm.org/doi/10.1145/3306449.3328812).

This project is a replication of the results discussed in that paper. I use ARFoundation with ARKit under the hood for AR, Normcore to handle network communications, a custom shader to clip the object as it appears to pass though the computer screen, and custom object manipulation code to allow the user to move the object. Once the user has pulled the object out of the screen, they can apply physics which casues it to fall to surface below it -- usually a keyboard.

As computing intereactions become more spatial (hold devices close to share files, connect headphones, etc.) and AR becomes more prevalent and practicle, the moving of digital content via space will become more normal as well. Rather than sharing content, documents, or models with a share button, we will simply "move" the content through space and onto the target device. Think every scifi movie ever.

This project aims to capture an early prototype of what moving content this way might feel like.

Here's a [demo](https://youtu.be/AGNKFUgsUr4).

## Getting Started
These instructions will get you a copy of the project up and running on your local machine. 

### Download
Just clone this repo and open with the Unity verison found in `ProjectVersion.txt`.

### Building & Testing
Build the project to iOS using XCode. Remember, we're using Normcore so we have to remember to add `libz.tbd` to the Link with Libraries section in the Build Phases of the Unity Platform Target.

## How it Works
There is only one "shared" object. You can imagine there is only one and its position and rotation synced with Normcore. The only issue is that the coordinate system between the phone and desktop dont match up. We solve this using a detected image.

On Detected Image:
We know where the computer is now. Use some math to make our 0,0,0, the 0,0,0 on the desktop. Usually, this is right in the center of the screen, on the plane of the screen. This is done via `MakeContentAppearAt()` from ARFoundation. Calling this method with a placeholder object at the world origin can have the effect of "resetting the AR session origin" to whatever spot you want. In this case, we reset the world origin to the center of the desktop screen as this is where it is on the desktop version itself.

Once the coordinate systems are lined up, all thats left to do is pull the object out of the screen. When the user holds their finger on the phone screen, the object follows their position -- you 'pull' the object about 10cm towards you and out through the screen. The object can also be manipulated on the desktop viewport using the mouse.

Once the object is out in space, pressing the 'apple with arrows' button will add a rigidbody to the object, letting it fall to land on any planes detected thusfar.

## Future Work & Ideas

Generate (room id, recognition image) pairs for any model. Upload the pair to a database. Mobile users recognize image, then join room. This would enable the use of multiple models and a generally more 'real' app.

Overcome physical sizing issues: It's very important that the physical size of the recognition image be as accurate as possible when defined in the image recognition library. ARkit uses this size to guess how far the image is from the camera and this app uses that distance to place the "clipping plane". It's important that this plane is as flush with the actual computer screen as possible. A non-flush clipping plane will result in a disolving of the illusion of pulling the object out of the screen. Vertical plane detection could be used to strengthen the estimate of the screens location.

Use sound, animation, and other UX to provide even more feedback about what’s going on.

Build to web to make accessible. Use QR code as recognition image to decrease steps for the user to take. The QR code would open the WebAR site and then use the same QR code as a refernece image. This makes it so that the only action the user needed to take was point their camera at the screen.

Use viewport images as recognition images in dynamic networked image library. Note that the rotation of the viewport via mouse will be interpereted as a rotation of the recognition image if not dealt with properly. Also note that the quality of the viewport as a reference image is likely to be lower than the quality given by an optimized tracker like the one I used. However, if these problems can be overcome, a markerless experience would be better.

## Credit

For the original paper and idea:

Christian Vazquez, Benjamin Reynolds, Hisham Bedri, Anna Fusté, and Valentin Heun. 2019. Air: augmented intersection of realities. In ACM SIGGRAPH 2019 Virtual, Augmented, and Mixed Reality (SIGGRAPH ’19). Association for Computing Machinery, New York, NY, USA, Article 14, 1. DOI:https://doi.org/10.1145/3306449.3328812


### Models
Suzanne from Blender ;)

### Marker
Amazing optimized tracker generator from @evryone_XR:
https://codepen.io/staus/full/oEOJpq

### Icons
<div>Icons made by <a href="https://www.flaticon.com/authors/freepik" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>

Icons made by <a href="https://www.flaticon.com/authors/smashicons" title="Smashicons">Smashicons</a> from <a href="https://www.flaticon.com/" title="Flaticon"> www.flaticon.com</a>