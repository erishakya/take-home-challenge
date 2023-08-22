# take-home-challenge
Assumptions:

1. Both balls start with the same speed, weight, and how gravity affects them.
2. The paths you type in should only have 'S', 'U', and 'D' characters.
3. Each step of the way – straight, up, or down – matches a letter's distance.
4. Figuring out the time for each bit uses easy equations for speed and up-and-down motion.
5. We're going with a perfect situation and not thinking about any outside stuff that could change things up.
6. After we do the math for each piece, we'll change it a bit based on how heavy each ball is.
7. If adjustedTotalTimeA is less than adjustedTotalTimeB, the plan is ball A beats ball B to the finish.
8. When adjustedTotalTimeA and adjustedTotalTimeB are the same, both balls hit the finish together.


Outcome Explanation:
Now, let's break it down. We're clocking how much time it takes for each ball (A and B) to go through their paths:

1. Straight parts get figured out by counting 'S' letters.
2. Same idea for 'U' and 'D' letters – we're adding them up.
3. Then we're mixing it up a bit with how hefty each ball is by using their mass's square root.
4. Next, we're comparing the adjusted total times for both balls.
5. Whoever's got the shorter time wins. But if those times are the same, we're calling it a tie – both balls hit the finish together.
5. We're thinking about how fast they kick off, how heavy they are, and how gravity's pulling them in.
