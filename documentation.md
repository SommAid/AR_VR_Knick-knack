# AR Knick-knack: Project Documentation

## Overview & Motivation
**AR Knick-knack** is an Augmented Reality application built using Unity and Vuforia. The motivation behind this project was to create an interactive, multi-faceted AR experience that connects physical objects to specific geographic locations and their real-time data. 

For this project, I chose to highlight **San Diego, California**. The application serves as a digital souvenir—a "knick-knack"—that brings a physical cube to life with information and visuals related to the area, specifically focusing on local landmarks like Legoland.

## Design & Visual Elements
The core of the application revolves around an AR MultiTarget (a physical cube). Each side of the cube triggers a different digital augmentation:

*   **Top Side (The Knick-knack):** Displays a custom 3D model (`lego_land.blend`). This model represents Legoland, a major attraction in the San Diego area. *(Note: Describe here how you created this in Blender or where you sourced the assets).*
*   **Left Side (Information):** Displays localized text and titles providing context about the knick-knack being viewed.
*   **Right Side (Live Data):** Features a live, functioning clock (`SanDiegoTime` / `SanDiegoClock` scripts) that displays the current real-time in San Diego, California.

*[Insert Screenshot 1: The physical target cube]*
*[Insert Screenshot 2: The AR view showing the Legoland model on top]*
*[Insert Screenshot 3: The AR view showing the live San Diego time on the side]*

## Development Process
### Tools & Libraries
*   **Game Engine:** Unity
*   **AR SDK:** Vuforia Engine (used for MultiTarget tracking)
*   **3D Modeling:** Blender (for the Legoland knick-knack)
*   **Languages:** C# (for custom time/clock scripts)

### Code Structure & Execution
The project is structured around a main Unity scene (`SampleScene`). The Vuforia MultiTarget behavior is the parent object, with child GameObjects assigned to specific sides (`cube.Top`, `cube.Left`, `cube.Right`). 
*   Custom C# scripts (`SanDiegoTime.cs`, `SanDiegoClock.cs`) are attached to UI elements to fetch and format the correct time zone data.
*   The Vuforia configuration handles the image recognition for the cube's faces.

**How to run it:**
To run this application, you will need Unity installed with the Vuforia Engine package. Clone the repository, open the project in Unity, print out the MultiTarget cube faces, assemble the physical cube, and press Play in the editor (using a webcam) or build it to a mobile device.

*   **Repository Link:** [Insert GitHub Link Here]
*   **Live Application:** [Insert App Store/Play Store/Web Link if applicable]

## Challenges & Future Work
**Challenges:**
One of the primary technical difficulties encountered during this project was managing Unity version control between different operating systems (Mac and Windows desktop). Ensuring that scenes, metafiles, and Vuforia configurations synced correctly without breaking references required careful repository management and troubleshooting. Specifically, ensuring that the child objects (text, time scripts, and 3D models) stayed parented to the correct MultiTarget faces across platforms took some debugging.

**Future Work:**
In the future, I would like to expand the knick-knack concept to include multiple locations. I envision having several different physical targets, each loading a unique city with its own custom 3D landmark, live local weather data, and interactive animations. 

## AI Usage & Collaboration
**AI Usage:**
AI tools (like Gemini) were utilized during the development process primarily for debugging Unity scene configurations and resolving version control conflicts. For example, AI helped analyze the `.unity` scene file structure to fix broken parent-child hierarchies on the Vuforia MultiTarget that occurred when switching between Mac and Windows. 

**Collaboration:**
*(Note: Please list any peers who helped you brainstorm, debug, or playtest your application here).*

---

## Demo Video
*(Please view the 2-3 minute demo video below to see the AR Knick-knack in action, featuring a voiceover explanation of the components and functionality.)*

[**Watch the Demo Video Here**] *(Insert YouTube or local video link)*