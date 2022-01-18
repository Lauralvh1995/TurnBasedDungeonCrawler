# Selecting Multiplication Tables

To facilitate the practice of the different multiplication tables from 1 to 10, I created a simple system using Unity Events.

Tables hold 10 equations or multiplications, for a base number, so 1 \* X to 10 \* X.

An EquationController knows which Table is currently active, and knows each possible answer in that Table. It selects an equation at random once it gets the signal to do so from the game. The game only needs to know the current equation and the possible answers.

Each Table is attached to a GameObject in the hierarchy, and is disabled by default. Via the UI of choice, a Table can be activated. If it’s activated, it sends an event to the EquationController, which adds the Table to the list. Multiple Tables can be activated this way.

A separate button clears the current selection, and deactivates all Table objects.

For this small prototype, I used a Unity GUI, but the way the actual selection is triggered can be changed, into NFC or via QR code for example.

![](https://lh6.googleusercontent.com/JnkqmApEPwdRE3ViiAbA8Xe8m7vlp4RmA3NDSpEkl8Iu60Qc6HFwJTgB\_VOdhHxbRWjqjpdS8v21zQVqHO-NFjyXcrbFTMQZMuEUWcgz8PBn34bHPKaobvbe5c1\_55Nrmn78uGBh)

![](https://lh5.googleusercontent.com/SNLhmBjL861X5rnHoA5Igmn0FIvGtukcJUIx0zy5Xd2xAXMqMUX3Ox7ATeL9NhldxZaOpaeZOmDFZMptsxw-wscT2CUh6miPhtsCOW3T81JCSnfpsE63aUNfVOr721spIo0tOIHk)

source code: [https://github.com/Lauralvh1995/AnnemariaKoekoek/tree/TableSelection](https://github.com/Lauralvh1995/AnnemariaKoekoek/tree/TableSelection)
