---
Title:    Data Structures Repository
Author:   Chinwendu (Chin) Okoronkwo  
Date:     September 12, 2018  
Comment:  A collection of abstract  
          data structures which are non-native  
          to most programming languages.
---
# Data Structures
A collection of abstract data structures which are non-native to most programming languages.

## Table of Contents
<details>
<summary>Click to expand</summary>

[Getting Started](#getting-started)
[Generic Graph](#generic-graph)
</details>

## Getting Started
This documentation is intended to serve as a brief explaination of the implementation used for each data structure.  Each implementation language is indicated by the name of the parent folder that the code has been placed in.

## Generic Graph
The graph has been implemented as a collection of three classes:
1. [Graph](#graph)
2. [Permutations](#permutations)
3. [Algorithms](#algorithmsa)


### Graph
The parameter accepting constructor, expects a collection of generic IEnumerable vertice and their associated edges - represented as a collection of tuple generic object pairs.  This implementation assumes bi-directional edges.

The AdjacencyList object is a list of adjacent vertice represented as a dictionary (a collection of key/value pairs) which stores an instance of the generic object represented in the graph and a hash set(unique set) of all adjacent vertice.

The AddVertex method accepts a vertext to add to the instant graph object - simultaneously creating an empty hashset for each vertex (to represent the adjacent vertice).

The AddEdge method expects a tuple of generic objects representing the possible bidirectional relationship of each vertex.  For each vertex in the accepted tuple pair, a check is made as to whether an edge (relationship) exists between the pair of vertex.

The Print method represents the graph as might be expected:

```
[vertex]: [adjacent vertext], [adjacent vertext], [adjacent vertext] ...
```