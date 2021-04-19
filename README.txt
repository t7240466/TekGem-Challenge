DISCLAIMER
-I do not suggest that my implementation is anywhere near the optimal solution.
-The output for the program is significantly slower than the algorithm and as such should not be used as an indication of its speed.

CURRENT IMPLEMENTATION
-The program at current calls the CityFinder object when a user presses a valid letter or digit key, search can be cancelled or reset typing 1 and 2 respectively.
-Records currently consists of over 1 million records in csv format loaded into a sorted dictionary with each letter as a key with a list of related cities.

KNOWN ISSUES
-Characters aren't recognised unless they match exactly (e.g "a" != "á") this would be something that could possibly need managing in a real world solution either depending on the use case.

THOUGHTS ON IMPROVEMENTS
-Although I checked online for operational efficiency of data structures and sorting algorithms, I'm no expert and they could likely be updated to further improve efficiency depending on exact function.
-Updating the application to cache the previous search terms results could improve efficiency by reducing look-up function calls however, this could dramtically increase memory usage depending on individual search usage and session duration.
-It may be of use to sort the city data in to a tree of next letters with each city being a node at the end of a chain of nodes that are its individual characters, this would mean each node has a set of its available next letters as keys, and you could store the valid cities at each node which should lead to increased performance. However this would lead to repetition of stored data and therefore memory bloat.