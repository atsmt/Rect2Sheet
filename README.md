# Rect2Sheet Dataset - Rectangles to Sheet-Metal Solutions

## Description

A synthetic dataset of **19,231 sheet-metal designs** pairing rectangle layouts with their
sheet-metal solutions, plus a parallel set of discarded examples.

Built for training and evaluating models that turn tabs into bent parts. Generated with the
SheetGen repository: https://github.com/chriswitt77/SheetGen

The full dataset release is available on Zenodo: https://doi.org/10.5281/zenodo.20834240

This repository contains test subsets of the dataset:
- `dataset_test_1`: 74 designs
- `dataset_test_2`: 610 designs

## Contents

| Folder | Contents |
|--------|----------|
| `dataset_json` | Accepted **rectangle / solution / metadata** JSON triples |
| `dataset_discarded_json` | Rejected solutions as JSON |
| `dataset_fs` | Same solutions in FeatureScript form |
| `dataset_discarded_fs` | Rejected solutions as FeatureScript |

Each design is a zero-padded triple:

```text
00001_rectangle.json   # input: rectangle tabs (corner points A/B/C, optional mounts)
00001_solution.json    # target: fold sequence, bends (tabs/points/direction), folded tabs
00001_metadata.json    # id, rectangle_id, num_rectangles, has_mounts, allow_non_90, has_split_tabs
```

## How it was generated

Synthetic pipeline in `src/dataset`, configured via `config/config.yaml`:

1. **Rectangles**: Random connected layouts of 2-4 tabs with varied sizes, gaps, angles
   (including non-90 degrees), and optional mount holes.
2. **Solutions**: The SheetGen engine explores fold topologies and produces candidates;
   manufacturability filters (tool collision, unfolding overlap, thin segments) split them into
   **accepted** vs **discarded**; up to 12 diverse solutions per design are kept. For solutions
   with mounts, input rectangles can also be split into two.
3. **Verification**: The author manually inspected all generated solutions and discarded edge cases.
4. **Packaging**: Pairs accepted solutions with their rectangles, strips simulation-only fields,
   and emits clean JSON triples plus FeatureScript.

## Credits

Generated with SheetGen: https://github.com/chriswitt77/SheetGen

Please cite the Rect2Sheet dataset (Zenodo DOI: https://doi.org/10.5281/zenodo.20834240) and the
SheetGen repository when used.
