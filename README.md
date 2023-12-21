# AR-VR-Guidance-of-Continuum-Manipulator
**Device: Quest3
Unity Version: 2022.3.14f1
OpenXR Plugin: 1.9.1**

## 1. Medical Background​
- Osteonecrosis disrupts blood supply to the femoral head leading to collapse of the subchondral bone. ​

- Core decomposition refers to the removal of diseased tissue from the inside of the bone in treatment of osteonecrosis.
![](/imgs/medical%20background.png)

## 2.Surgical Techniqes and Challenges​
- Surgical Techniques:​

    - Use a continuum manipulator with a steerable drill tip.​

    - Achieve minimally-invasive surgeries.​

- Problem!!:​

    - A guidance strategy for continuum manipulator is needed to guide surgeons. 

![](/imgs/surgical%20tech.png)

## 3. Motivation​
- Continuum manipulators are robots characterized by high flexibility and two degrees of freedom​

- Continuum manipulators are guided using multiple CT scans of the body ​

- Multiple CT scans bring radiation to surgeons and patients​

- A guidance strategy without multiple CT scans minimize radiation​

- An augmented reality visualization of a manipulator with a virtual model is an ideal situation​

​![](/imgs/motivation.png)

## 4. Solution

- **Project Overview:**
  - Development of a VR application for continuum manipulator guidance.
  - Utilization of Unity as the primary development platform.

- **Hardware Utilized:**
  - Use of Quest3 as the VR headset for control.

- **Software and Tools:**
  - Implementation of OpenXR toolkit for basic interaction.
  - Enabling controller-based movement and rotation of the virtual manipulator.

- **Virtual Environment Setup:**
  - Creation of a virtual patient body.
  - Establishment of guiding points within the VR environment.

- **User Interface Features:**
  - Integration of a dashboard in the VR application.
  - Inclusion of a radar, direction indicator, and distance indicator.

![](/imgs/architecture.png)

## 5. Implementation
- **Results Achieved:**
  - Successful completion of the majority of the VR guidance system:
    - Bend manipulator using Quest3 controller
    - Route the tool tip using Quest3 controller
    - Visual guidance for insert point
    - Radar guidance for drilling route.
  - Three level of difficulty for the user to choose from.

- **Future Developments:**
  - Implementation of marker tracking for real patients.
  - Attachment of sensors to an actual continuum manipulator.
  - Complete AR guidance system for real scenario
  - Development of an algorithm to automatically calculate the manipulator's trajectory.
  
![](/imgs/Menu.png)
![](/imgs/demo.png)

